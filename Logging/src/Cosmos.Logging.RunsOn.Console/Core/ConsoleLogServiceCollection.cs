using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.MessageTemplates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console.Core {
    public class ConsoleLogServiceCollection : ILogServiceCollection {
        private LoggingConfigurationBuilder _configurationBuilder;
        private readonly bool _configurationBuilderLockedStatus;
        private readonly IServiceCollection _serviceCollection;
        private ILoggerSettings _settings { get; set; }
        private LoggingConfiguration _loggingConfiguration { get; set; }
        private readonly Dictionary<string, ILogSinkSettings> _sinkSettings;
        private object _sinkUpdateLock = new object();
        private Action<IConfigurationRoot> _originConfigAction;

        private ConsoleLogServiceCollection() { }

        internal ConsoleLogServiceCollection(IServiceCollection services) : this(services, (IConfigurationBuilder) null) { }

        internal ConsoleLogServiceCollection(IServiceCollection services, IConfigurationBuilder builder) {
            _configurationBuilder = new LoggingConfigurationBuilder(builder);
            _configurationBuilderLockedStatus = false;
            _serviceCollection = services ?? throw new ArgumentNullException(nameof(services));
            _settings = new LoggingSettings();
            _sinkSettings = new Dictionary<string, ILogSinkSettings>();

            BeGivenConfigurationBuilder = _configurationBuilder.InitializedByGivenBuilder;
            BeGivenConfigurationRoot = false;
        }

        internal ConsoleLogServiceCollection(IServiceCollection services, IConfigurationRoot root) {
            _configurationBuilder = new DisabledConfigurationBuilder(root);
            _configurationBuilderLockedStatus = true;
            _serviceCollection = services;
            _settings = new LoggingSettings();
            _sinkSettings = new Dictionary<string, ILogSinkSettings>();

            BeGivenConfigurationBuilder = _configurationBuilder.InitializedByGivenBuilder;
            BeGivenConfigurationRoot = true;
        }

        public bool BeGivenConfigurationBuilder { get; }
        public bool BeGivenConfigurationRoot { get; }
        public IServiceCollection ExposeServices() => _serviceCollection;
        public ILoggerSettings ExposeLogSettings() => _settings;
        public LoggingConfiguration ExposeLoggingConfiguration() => _loggingConfiguration;

        public void ReplaceSettings<TLoggerSettings>(ILoggerSettings newSettings)
            where TLoggerSettings : LoggingSettings, new() {
            if (newSettings != null) _settings = newSettings;
        }

        public ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction) {
            dependencyAction?.Invoke(_serviceCollection);
            return this;
        }

        private Action<object> AddSinkSettingsAction { get; set; }

        public ILogServiceCollection AddSinkSettings<TSinkSettings, TSinkConfiguration>(TSinkSettings settings, Action<IConfiguration, TSinkConfiguration> configAct)
            where TSinkSettings : class, ILogSinkSettings, new() where TSinkConfiguration : SinkConfiguration, new() {
            if (settings != null && !_sinkSettings.ContainsKey(settings.Key)) {
                AddSinkSettingsAction += lockObj => {
                    lock (lockObj) {
                        if (!_sinkSettings.ContainsKey(settings.Key)) _sinkSettings.Add(settings.Key, settings);
                        _loggingConfiguration?.SetSinkConfiguration(settings.Key, configAct);
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

        internal void BuildConfiguration() {
            _loggingConfiguration = _configurationBuilder.Build();
        }

        internal void ActiveSinkSettings() {
            _settings.Sinks?.Clear();
            _settings.Sinks = _sinkSettings;
            AddSinkSettingsAction?.Invoke(_sinkUpdateLock);
        }

        internal void ActiveOriginConfiguration() {
            _originConfigAction?.Invoke(_loggingConfiguration.Configuration);
        }
    }
}