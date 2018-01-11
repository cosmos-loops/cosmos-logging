using System;
using System.Collections.Generic;
using Cosmos.Logging.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console.Settings {
    public class ConsoleLogServiceCollection : ILogServiceCollection {
        private LoggingConfigurationBuilder _configurationBuilder;
        private readonly bool _configurationBuilderLockedStatus;
        private readonly IServiceCollection _serviceCollection;
        private ILoggerSettings _settings { get; set; }
        private readonly Dictionary<string, ILogSinkSettings> _sinkSettings;
        private object _sinkUpdateLock = new object();
        private Action<IConfigurationRoot> _originConfigAction;

        private ConsoleLogServiceCollection() { }

        internal ConsoleLogServiceCollection(IServiceCollection services) : this(services, (IConfigurationBuilder) null) { }

        internal ConsoleLogServiceCollection(IServiceCollection services, IConfigurationBuilder builder) {
            _configurationBuilder = new LoggingConfigurationBuilder(builder);
            _configurationBuilderLockedStatus = false;
            _serviceCollection = services;
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

        public void ReplaceSettings<TLoggerSettings>(ILoggerSettings newSettings)
            where TLoggerSettings : LoggingSettings, new() {
            if (newSettings != null) _settings = newSettings;
        }

        public ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction) {
            dependencyAction?.Invoke(_serviceCollection);
            return this;
        }

        public ILogServiceCollection AddSinkSettings<TSinkSettings>(TSinkSettings settings) where TSinkSettings : class, ILogSinkSettings, new() {
            if (settings != null && !_sinkSettings.ContainsKey(settings.Key)) {
                lock (_sinkUpdateLock) {
                    if (!_sinkSettings.ContainsKey(settings.Key))
                        _sinkSettings.Add(settings.Key, settings);
                }
            }

            return this;
        }

        public ILogServiceCollection AddOriginConfigAction(Action<IConfigurationRoot> configAction) {
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

        internal IConfigurationRoot ConfigurationRoot { get; private set; }

        internal void BuildConfiguration() {
            ConfigurationRoot = _configurationBuilder.Build();
        }

        internal void ActiveSinkSettings() {
            _settings.Sinks?.Clear();
            _settings.Sinks = _sinkSettings;
        }

        internal void ActiveOriginConfiguration() {
            _originConfigAction?.Invoke(ConfigurationRoot);
        }
    }
}