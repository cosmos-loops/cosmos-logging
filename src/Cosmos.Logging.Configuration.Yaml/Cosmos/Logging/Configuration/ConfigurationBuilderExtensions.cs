using System;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configuration {
    /// <summary>
    /// Extensions for logging configuration builder
    /// </summary>
    public static class YamlConfigurationBuilderExtensions {
        /// <summary>
        /// Add yaml format configuration file by the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggingConfigurationBuilder AddYamlFile(this LoggingConfigurationBuilder builder, string path) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            return builder.Configure(b => b.AddYamlFile(path, true, true));
        }
    }
}