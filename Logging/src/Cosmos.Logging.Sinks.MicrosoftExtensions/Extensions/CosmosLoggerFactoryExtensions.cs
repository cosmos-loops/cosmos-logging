using System;
using Cosmos.Logging.Sinks.MicrosoftExtensions;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class CosmosLoggerFactoryExtensions {
        public static ILoggerFactory AddCosmos(this ILoggerFactory factory, ILoggingServiceProvider loggingServiceProvider) {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));

            factory.AddProvider(new MicrosoftLoggerWrapperProvider(loggingServiceProvider));

            return factory;
        }
    }
}