using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configuration {
    /// <summary>
    /// Extensions for logging configuration builder
    /// </summary>
    public static class XmlConfigurationBuilderExtensions {
        /// <summary>
        /// Add xml format configuration file by the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddXmlFile(this IConfigurationBuilder builder, string path) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            builder.AddXmlFile(path, true, true);
        }

        /// <summary>
        /// Add xml format configuration file by the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggingConfigurationBuilder AddXmlFile(this LoggingConfigurationBuilder builder, string path) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            return builder.Configure(b => b.AddXmlFile(path, true, true));
        }

#if NETCOREAPP3_1 || NETSTANDARD2_1

        /// <summary>
        /// Add xml format configuration by the given stream.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="stream"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void AddXmlStream(this IConfigurationBuilder builder, Stream stream) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (stream is null || !stream.CanRead)
                throw new ArgumentException("Stream cannot be null or cannot be read.");
            XmlConfigurationExtensions.AddXmlStream(builder, stream);
        }

        /// <summary>
        /// Add xml format configuration by the given stream.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static LoggingConfigurationBuilder AddXmlStream(this LoggingConfigurationBuilder builder, Stream stream) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (stream is null || !stream.CanRead)
                throw new ArgumentException("Stream cannot be null or cannot be read.");
            return builder.Configure(b => b.AddXmlStream(stream));
        }

#endif

        /// <summary>
        /// Add in-memory collection
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inMemoryConfig"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddXmlDictionary(this IConfigurationBuilder builder, Dictionary<string, string> inMemoryConfig) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (inMemoryConfig is null)
                throw new ArgumentNullException(nameof(inMemoryConfig));
            builder.AddInMemoryCollection(inMemoryConfig);
        }

        /// <summary>
        /// Add in-memory collection
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inMemoryConfig"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggingConfigurationBuilder AddXmlDictionary(this LoggingConfigurationBuilder builder, Dictionary<string, string> inMemoryConfig) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (inMemoryConfig is null)
                throw new ArgumentNullException(nameof(inMemoryConfig));
            return builder.Configure(b => b.AddInMemoryCollection(inMemoryConfig));
        }
    }
}