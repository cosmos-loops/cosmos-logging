using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.MessageTemplates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    public class NancyLogServiceCollection : ILogServiceCollection {
        private LoggingConfigurationBuilder _configurationBuilder;
        private readonly bool _configurationBuilderLockedStatus;
        private readonly IServiceCollection _serviceCollection;
        private LoggingConfiguration _loggingConfiguration { get; set; }
        private ILoggingOptions _settings { get; set; }
        private readonly Dictionary<string, ILoggingSinkOptions> _sinkSettings;
        private object _sinkUpdateLock = new object();
        private Action<IConfigurationRoot> _originConfigAction;
        
        protected internal NancyLogServiceCollection() {
            _configurationBuilder = new LoggingConfigurationBuilder();
            _configurationBuilderLockedStatus = false;
            _serviceCollection = new ServiceCollection();
            _settings = new LoggingOptions();
            _sinkSettings = new Dictionary<string, ILoggingSinkOptions>();

            BeGivenConfigurationBuilder = _configurationBuilder.InitializedByGivenBuilder;
            BeGivenConfigurationRoot = false;
        }

        public bool BeGivenConfigurationBuilder { get; }
        public bool BeGivenConfigurationRoot { get; }
        public IServiceCollection ExposeServices() => _serviceCollection;
        public ILoggingOptions ExposeLogSettings() => _settings;
        public LoggingConfiguration ExposeLoggingConfiguration() => _loggingConfiguration;

        public void ReplaceSettings(ILoggingOptions newSettings) {
            if (newSettings != null) _settings = newSettings;
        }

        public ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction) {
            dependencyAction?.Invoke(_serviceCollection);
            return this;
        }

        private Action<object> AddSinkSettingsAction { get; set; }

        public ILogServiceCollection AddSinkSettings<TSinkSettings, TSinkConfiguration>(
            TSinkSettings settings,
            Action<IConfiguration, TSinkConfiguration> configAct)
            where TSinkSettings : class, ILoggingSinkOptions, new()
            where TSinkConfiguration : SinkConfiguration, new() {
            if (settings != null && !_sinkSettings.ContainsKey(settings.Key)) {
                AddSinkSettingsAction += lockObj => {
                    lock (lockObj) {
                        if (!_sinkSettings.ContainsKey(settings.Key)) _sinkSettings.Add(settings.Key, settings);
                        _loggingConfiguration?.SetSinkConfiguration(settings.Key, settings, configAct);
                    }
                };
            }

            return this;
        }

        private Action<object> AddExtraSinkSettingsAction { get; set; }

        public ILogServiceCollection AddExtraSinkSettings<TExtraSinkSettings, TExtraSinkConfiguration>(
            TExtraSinkSettings settings,
            Action<IConfiguration, TExtraSinkConfiguration, LoggingConfiguration> configAct)
            where TExtraSinkSettings : class, ILoggingSinkOptions, new()
            where TExtraSinkConfiguration : SinkConfiguration, new() {
            if (settings != null && !_sinkSettings.ContainsKey(settings.Key)) {
                AddExtraSinkSettingsAction += lockObj => {
                    lock (lockObj) {
                        if (!_sinkSettings.ContainsKey(settings.Key)) _sinkSettings.Add(settings.Key, settings);
                        _loggingConfiguration?.SetExtraSinkConfiguration(settings.Key, settings, configAct);
                    }
                };
            }

            return this;
        }

        public ILogServiceCollection AddOriginConfigAction(Action<IConfiguration> configAction) {
            if (configAction != null) {
                _originConfigAction += configAction;
            }

            return this;
        }

        public ILogServiceCollection ModifyConfigurationBuilder(Action<LoggingConfigurationBuilder> builderAct) {
            if (!_configurationBuilderLockedStatus) {
                builderAct?.Invoke(_configurationBuilder);
            }

            return this;
        }

        public ILogServiceCollection PreheatMessageTemplates(Action<MessageTemplateCachePreheater> preheatAct) {
            _configurationBuilder.PreheatMessageTemplates(preheatAct);
            return this;
        }

        protected internal void BuildConfiguration() {
            _loggingConfiguration = _configurationBuilder.Build(_settings);
        }

        protected internal void ActiveSinkSettings() {
            _settings.Sinks?.Clear();
            _settings.Sinks = _sinkSettings;
            AddSinkSettingsAction?.Invoke(_sinkUpdateLock);
            AddExtraSinkSettingsAction?.Invoke(_sinkUpdateLock);
        }

        protected internal void ActiveOriginConfiguration() {
            _originConfigAction?.Invoke(_loggingConfiguration.Configuration);
        }
    }
}