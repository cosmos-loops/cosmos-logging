using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging {
    public class LoggingConfiguration {
        private readonly IConfigurationRoot _loggingConfiguration;
        private readonly Dictionary<string, SinkConfiguration> _sinkConfigurations = new Dictionary<string, SinkConfiguration>();
        private readonly object _sinkConfigurationsLock = new object();

        internal LoggingConfiguration() { }

        public LoggingConfiguration(IConfigurationRoot loggingConfiguration) {
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
            SetSelf(loggingConfiguration.GetSection("Logging").Get<LoggingConfiguration>());
        }

        public bool IncludeScopes { get; set; }

        public Dictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();

        public DestructureConfiguration Destructure { get; set; }

        public IConfigurationRoot Configuration => _loggingConfiguration;

        public void SetSinkConfiguration<TSinkConfiguration>(string sectionName, Action<IConfiguration, TSinkConfiguration> addtionalAct = null)
            where TSinkConfiguration : SinkConfiguration, new() {
            if (string.IsNullOrWhiteSpace(sectionName)) throw new ArgumentNullException(nameof(sectionName));
            var section = _loggingConfiguration.GetSection(sectionName);
            var configuration = section.Get<TSinkConfiguration>() ?? new TSinkConfiguration();
            addtionalAct?.Invoke(section, configuration);

            SetSinkConfiguration(configuration);
        }

        public void SetSinkConfiguration<TSinkConfiguration>(TSinkConfiguration configuration)
            where TSinkConfiguration : SinkConfiguration, new() {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (string.IsNullOrWhiteSpace(configuration.Name)) throw new ArgumentNullException(nameof(configuration.Name));
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_sinkConfigurations.ContainsKey(configuration.Name)) {
                lock (_sinkConfigurationsLock) {
                    if (!_sinkConfigurations.ContainsKey(configuration.Name)) {

                        _sinkConfigurations.Add(configuration.Name, configuration);
                    }
                }
            }
        }

        public TSinkConfiguration GetSinkConfiguration<TSinkConfiguration>(string name) where TSinkConfiguration : SinkConfiguration, new() {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return _sinkConfigurations[name] as TSinkConfiguration;
        }

        public object GetSinkConfiguration(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return _sinkConfigurations[name];
        }

        private void SetSelf(LoggingConfiguration configuration) {
            if (configuration == null) {
                IncludeScopes = false;
                LogLevel = new Dictionary<string, string> {{"Default", "Information"}};
            } else {
                IncludeScopes = configuration.IncludeScopes;
                LogLevel = configuration.LogLevel;
            }
        }
    }
}