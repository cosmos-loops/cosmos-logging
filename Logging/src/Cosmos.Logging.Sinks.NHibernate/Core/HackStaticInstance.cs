using System;

namespace Cosmos.Logging.Sinks.NHibernate.Core {
    internal class HackStaticInstance {
        public HackStaticInstance(ILoggingServiceProvider loggingServiceProvider, NhSinkOptions settings) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            Logging.Core.StaticServiceResolver.SetResolver(loggingServiceProvider);
            global::NHibernate.LoggerProvider.SetLoggersFactory(
                new NHibernateLoggerWrapperFactory(loggingServiceProvider, settings.GetRenderingOptions(), settings.Filter));
        }
    }
}