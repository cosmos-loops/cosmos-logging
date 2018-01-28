using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Navigators;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging {
    public partial class LoggingConfiguration {
        private readonly Dictionary<string, SinkConfiguration> _sinkConfigurations = new Dictionary<string, SinkConfiguration>();
        private readonly object _sinkConfigurationsLock = new object();

        public LogEventLevel GetSinkDefaultMinimumLevel(string sinkName) => NavigationFilterProcessor.GetDefault(sinkName);

        public void SetSinkConfiguration<TSinkConfiguration, TSinkSettings>(
            string sectionName, TSinkSettings settings, Action<IConfiguration, TSinkConfiguration> addtionalAct = null)
            where TSinkConfiguration : SinkConfiguration, new() where TSinkSettings : class, ILoggingSinkOptions, new() {
            if (string.IsNullOrWhiteSpace(sectionName)) throw new ArgumentNullException(nameof(sectionName));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var section = _loggingConfiguration.GetSection($"Logging:{sectionName}");
            var configuration = section.Get<TSinkConfiguration>() ?? new TSinkConfiguration();
            addtionalAct?.Invoke(section, configuration);

            SetSinkConfiguration(configuration, settings);
        }

        public void SetSinkConfiguration<TSinkConfiguration, TSinkSettings>(TSinkConfiguration configuration, TSinkSettings settings)
            where TSinkConfiguration : SinkConfiguration, new() where TSinkSettings : class, ILoggingSinkOptions, new() {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrWhiteSpace(configuration.Name)) throw new ArgumentNullException(nameof(configuration.Name));
            if (!_sinkConfigurations.ContainsKey(configuration.Name)) {
                lock (_sinkConfigurationsLock) {
                    if (!_sinkConfigurations.ContainsKey(configuration.Name)) {
                        configuration.ProcessLogLevel(settings);
                        _sinkConfigurations.Add(configuration.Name, configuration);
                    }
                }
            }
        }

        public TSinkConfiguration GetSinkConfiguration<TSinkConfiguration>() where TSinkConfiguration : SinkConfiguration, new() {
            var temp = new TSinkConfiguration();
            return GetSinkConfiguration<TSinkConfiguration>(temp.Name);
        }

        public TSinkConfiguration GetSinkConfiguration<TSinkConfiguration>(string name) where TSinkConfiguration : SinkConfiguration, new() {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return _sinkConfigurations[name] as TSinkConfiguration;
        }

        public SinkConfiguration GetSinkConfiguration(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return _sinkConfigurations[name];
        }
    }
}