using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Navigators;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging {
    /// <summary>
    /// Logging configuration
    /// </summary>
    public partial class LoggingConfiguration {
        private readonly Dictionary<string, SinkConfiguration> _sinkConfigurations = new Dictionary<string, SinkConfiguration>();
        private readonly object _sinkConfigurationsLock = new object();

        /// <summary>
        /// Gets default minimum level for the given sink
        /// </summary>
        /// <param name="sinkName"></param>
        /// <returns></returns>
        public LogEventLevel GetSinkDefaultMinimumLevel(string sinkName) => NavigationFilterProcessor.GetDefault(sinkName);

        /// <summary>
        /// Sets sink configuration
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="settings"></param>
        /// <param name="additionalAct"></param>
        /// <typeparam name="TSinkConfiguration"></typeparam>
        /// <typeparam name="TSinkSettings"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetSinkConfiguration<TSinkConfiguration, TSinkSettings>(
            string sectionName, TSinkSettings settings, Action<IConfiguration, TSinkConfiguration> additionalAct = null)
            where TSinkConfiguration : SinkConfiguration, new() where TSinkSettings : class, ILoggingSinkOptions, new() {
            if (string.IsNullOrWhiteSpace(sectionName)) throw new ArgumentNullException(nameof(sectionName));
            if (settings is null) throw new ArgumentNullException(nameof(settings));
            var section = _loggingConfiguration.GetSection($"Logging:{sectionName}");
            var configuration = section.Get<TSinkConfiguration>() ?? new TSinkConfiguration();
            additionalAct?.Invoke(section, configuration);

            SetSinkConfiguration(configuration, settings);
        }

        /// <summary>
        /// Sets sink configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="settings"></param>
        /// <typeparam name="TSinkConfiguration"></typeparam>
        /// <typeparam name="TSinkSettings"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetSinkConfiguration<TSinkConfiguration, TSinkSettings>(TSinkConfiguration configuration, TSinkSettings settings)
            where TSinkConfiguration : SinkConfiguration, new() where TSinkSettings : class, ILoggingSinkOptions, new() {
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));
            if (settings is null) throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrWhiteSpace(configuration.Name)) throw new ArgumentNullException(nameof(configuration.Name));
            if (!_sinkConfigurations.ContainsKey(configuration.Name)) {
                lock (_sinkConfigurationsLock) {
                    if (!_sinkConfigurations.ContainsKey(configuration.Name)) {
                        configuration.BeforeProcessing(settings);
                        configuration.ProcessLogLevel(settings);
                        configuration.ProcessRenderingOptions(settings);
                        configuration.PostProcessing(settings);
                        _sinkConfigurations.Add(configuration.Name, configuration);
                    }
                }
            }
        }

        /// <summary>
        /// Sets extra sink configuration
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="settings"></param>
        /// <param name="additionalAct"></param>
        /// <typeparam name="TExtraSinkConfiguration"></typeparam>
        /// <typeparam name="TExtraSinkSettings"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetExtraSinkConfiguration<TExtraSinkConfiguration, TExtraSinkSettings>(
            string sectionName, TExtraSinkSettings settings,
            Action<IConfiguration, TExtraSinkConfiguration, LoggingConfiguration> additionalAct = null)
            where TExtraSinkSettings : class, ILoggingSinkOptions, new()
            where TExtraSinkConfiguration : SinkConfiguration, new() {
            if (string.IsNullOrWhiteSpace(sectionName)) throw new ArgumentNullException(nameof(sectionName));
            if (settings is null) throw new ArgumentNullException(nameof(settings));
            var section = _loggingConfiguration.GetSection($"Logging:{sectionName}");
            var configuration = section.Get<TExtraSinkConfiguration>() ?? new TExtraSinkConfiguration();
            additionalAct?.Invoke(section, configuration, this);

            SetSinkConfiguration(configuration, settings);
        }


        /// <summary>
        /// Gets sink configuration
        /// </summary>
        /// <typeparam name="TSinkConfiguration"></typeparam>
        /// <returns></returns>
        public TSinkConfiguration GetSinkConfiguration<TSinkConfiguration>() where TSinkConfiguration : SinkConfiguration, new() {
            var temp = new TSinkConfiguration();
            return GetSinkConfiguration<TSinkConfiguration>(temp.Name);
        }

        /// <summary>
        /// Gets sink configuration
        /// </summary>
        /// <param name="name"></param>
        /// <typeparam name="TSinkConfiguration"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TSinkConfiguration GetSinkConfiguration<TSinkConfiguration>(string name) where TSinkConfiguration : SinkConfiguration, new() {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return _sinkConfigurations[name] as TSinkConfiguration;
        }

        /// <summary>
        /// Gets sink configuration
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public SinkConfiguration GetSinkConfiguration(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return _sinkConfigurations[name];
        }
    }
}