#if NET461

using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Logging {
    /// <summary>
    /// Extensions for logging builder
    /// </summary>
    public static class LoggingBuilderExtensions {
        /// <summary>
        /// Add Cosmos Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="servicesConfigure"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddCosmosLogging(this ILoggingBuilder builder, Action<ILogServiceCollection> servicesConfigure = null) {
            return builder.AddCosmosLogging(null, servicesConfigure);
        }

        /// <summary>
        /// Add Cosmos Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="root"></param>
        /// <param name="servicesConfigure"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILoggingBuilder AddCosmosLogging(this ILoggingBuilder builder, IConfigurationRoot root, Action<ILogServiceCollection> servicesConfigure = null) {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            var services = builder.Services;

            var loggingServices = services.AddCosmosLogging(root) as StandardLogServiceCollection;

            servicesConfigure?.Invoke(loggingServices);

            loggingServices.Done();

            return builder;
        }
    }
}

#endif