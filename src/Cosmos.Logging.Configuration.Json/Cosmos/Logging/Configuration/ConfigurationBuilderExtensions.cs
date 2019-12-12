using System;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configuration {
    /// <summary>
    /// Extensions for logging configuration builder
    /// </summary>
    public static class JsonConfigurationBuilderExtensions {
        /// <summary>
        /// Add json format configuration file by the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddJsonFile(this IConfigurationBuilder builder, string path) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            builder.AddJsonFile(path, true, true);
        }

        /// <summary>
        /// Add json format configuration file by the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggingConfigurationBuilder AddJsonFile(this LoggingConfigurationBuilder builder, string path) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            return builder.Configure(b => b.AddJsonFile(path, true, true));
        }
    }
}