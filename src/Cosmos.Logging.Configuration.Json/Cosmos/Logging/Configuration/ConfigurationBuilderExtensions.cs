using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

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

#if NETCOREAPP3_1 || NETSTANDARD2_1

        /// <summary>
        /// Add json format configuration by the given stream.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="stream"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void AddJsonStream(this IConfigurationBuilder builder, Stream stream) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (stream is null || !stream.CanRead)
                throw new ArgumentException("Stream cannot be null or cannot be read.");
            JsonConfigurationExtensions.AddJsonStream(builder, stream);
        }

        /// <summary>
        /// Add json format configuration by the given stream.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static LoggingConfigurationBuilder AddJsonStream(this LoggingConfigurationBuilder builder, Stream stream) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (stream is null || !stream.CanRead)
                throw new ArgumentException("Stream cannot be null or cannot be read.");
            return builder.Configure(b => b.AddJsonStream(stream));
        }

#endif

        /// <summary>
        /// Add in-memory collection
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="inMemoryConfig"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddJsonDictionary(this IConfigurationBuilder builder, Dictionary<string, string> inMemoryConfig) {
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
        public static LoggingConfigurationBuilder AddJsonDictionary(this LoggingConfigurationBuilder builder, Dictionary<string, string> inMemoryConfig) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (inMemoryConfig is null)
                throw new ArgumentNullException(nameof(inMemoryConfig));
            return builder.Configure(b => b.AddInMemoryCollection(inMemoryConfig));
        }
    }
}