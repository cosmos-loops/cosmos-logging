using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Configuration {
    public class ConsoleLogServiceCollection : ILogServiceCollection {
        private readonly IServiceCollection _serviceCollection;
        private ILoggerSettings _settings { get; set; }
        internal readonly Dictionary<string, ILogSinkSettings> _sinkSettings;
        private object _sinkUpdateLock = new object();

        private ConsoleLogServiceCollection() { }

        internal ConsoleLogServiceCollection(IServiceCollection services) {
            _serviceCollection = services;
            _settings = new LoggingSettings();
            _sinkSettings = new Dictionary<string, ILogSinkSettings>();
        }

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

        internal void ActiveSinkSettings() {
            _settings.Sinks?.Clear();
            _settings.Sinks = _sinkSettings;
        }
    }
}