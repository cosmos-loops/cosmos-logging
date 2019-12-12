using System;

namespace Cosmos.Logging.Extensions.NHibernate.Core {
    internal class StaticServiceResolveInitialization {
        public StaticServiceResolveInitialization(ILoggingServiceProvider loggingServiceProvider, NhEnricherOptions settings) {
            if (loggingServiceProvider is null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            if (settings is null) throw new ArgumentNullException(nameof(settings));
            Logging.Core.StaticServiceResolver.SetResolver(loggingServiceProvider);
            global::NHibernate.NHibernateLogger.SetLoggersFactory(
                new NHibernateLoggerWrapperFactory(loggingServiceProvider, settings.GetRenderingOptions(), settings.Filter));
        }
    }
}