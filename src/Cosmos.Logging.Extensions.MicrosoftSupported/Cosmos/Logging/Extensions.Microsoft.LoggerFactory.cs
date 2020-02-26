using System;
using Cosmos.Logging.Extensions.MicrosoftSupported;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Cosmos logger factory
    /// </summary>
    public static class CosmosLoggerFactoryExtensions {
        /// <summary>
        /// Add Cosmos support
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="loggingServiceProvider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILoggerFactory AddCosmos(this ILoggerFactory factory, ILoggingServiceProvider loggingServiceProvider) {
            if (factory is null) throw new ArgumentNullException(nameof(factory));
            if (loggingServiceProvider is null) throw new ArgumentNullException(nameof(loggingServiceProvider));

            factory.AddProvider(new MicrosoftLoggerProviderAdapter(loggingServiceProvider));

            return factory;
        }
    }
}