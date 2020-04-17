using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Optionals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    /// <summary>
    /// NancyFX Log service collection
    /// </summary>
    public class NancyLogServiceCollection : ILogServiceCollection {
        private LoggingConfigurationBuilder _configurationBuilder;
        private readonly bool _configurationBuilderLockedStatus;
        private readonly IServiceCollection _serviceCollection;
        private LoggingConfiguration _loggingConfiguration { get; set; }
        private ILoggingOptions _settings { get; set; }
        private readonly Dictionary<string, ILoggingSinkOptions> _sinkSettings;
        private object _sinkUpdateLock = new object();
        private Action<IConfigurationRoot> _originConfigAction;
        private readonly List<Func<ILogEventEnricher>> _additionalEnricherProviders;

        /// <summary>
        /// Create a new instance of <see cref="NancyLogServiceCollection"/>
        /// </summary>
        protected internal NancyLogServiceCollection() {
            _configurationBuilder = new LoggingConfigurationBuilder();
            _configurationBuilderLockedStatus = false;
            _serviceCollection = new ServiceCollection();
            _settings = new LoggingOptions();
            _sinkSettings = new Dictionary<string, ILoggingSinkOptions>();
            _additionalEnricherProviders = new List<Func<ILogEventEnricher>>();

            BeGivenConfigurationBuilder = _configurationBuilder.InitializedByGivenBuilder;
            BeGivenConfigurationRoot = false;
        }

        /// <inheritdoc />
        public bool BeGivenConfigurationBuilder { get; }

        /// <inheritdoc />
        public bool BeGivenConfigurationRoot { get; }

        /// <inheritdoc />
        public IServiceCollection ExposeServices() => _serviceCollection;

        /// <inheritdoc />
        public ILoggingOptions ExposeLogSettings() => _settings;

        /// <inheritdoc />
        public LoggingConfiguration ExposeLoggingConfiguration() => _loggingConfiguration;

        /// <summary>
        /// Replace settings
        /// </summary>
        /// <param name="newSettings"></param>
        public void ReplaceSettings(ILoggingOptions newSettings) {
            if (newSettings != null) _settings = newSettings;
        }

        /// <inheritdoc />
        public ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction) {
            dependencyAction?.Invoke(_serviceCollection);
            return this;
        }

        /// <inheritdoc />
        public ILogServiceCollection AddEnricher(Func<ILogEventEnricher> enricherProvider) {
            _additionalEnricherProviders.Add(enricherProvider);
            return this;
        }

        private Action<object> AddSinkSettingsAction { get; set; }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public ILogServiceCollection AddOriginalConfigAction(Action<IConfiguration> configAction) {
            if (configAction != null) {
                _originConfigAction += configAction;
            }

            return this;
        }

        /// <inheritdoc />
        public ILogServiceCollection ModifyConfigurationBuilder(Action<LoggingConfigurationBuilder> builderAct) {
            if (!_configurationBuilderLockedStatus) {
                builderAct?.Invoke(_configurationBuilder);
            }

            return this;
        }

        /// <inheritdoc />
        public ILogServiceCollection PreheatMessageTemplates(Action<MessageTemplateCachePreheater> preheatAct) {
            _configurationBuilder.PreheatMessageTemplates(preheatAct);
            return this;
        }

        /// <summary>
        /// Build configuration
        /// </summary>
        protected internal void BuildConfiguration() {
            _loggingConfiguration = _configurationBuilder.Build(_settings);
        }

        /// <summary>
        /// Active sink settings
        /// </summary>
        protected internal void ActiveSinkSettings() {
            _settings.Sinks?.Clear();
            _settings.Sinks = _sinkSettings;
            AddSinkSettingsAction?.Invoke(_sinkUpdateLock);
            AddExtraSinkSettingsAction?.Invoke(_sinkUpdateLock);
        }

        /// <summary>
        /// Active original configuration
        /// </summary>
        protected internal void ActiveOriginConfiguration() {
            _originConfigAction?.Invoke(_loggingConfiguration.Configuration);
        }

        /// <summary>
        /// Active log event enrichers
        /// </summary>
        protected internal void ActiveLogEventEnrichers() {
            foreach (var provider in _additionalEnricherProviders) {
                _loggingConfiguration.SetEnricher(provider.Invoke().Maybe());
            }
        }
    }
}