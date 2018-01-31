using System;

namespace Cosmos.Logging.Sinks.MicrosoftExtensions.Core {
    internal class HackStaticInstance {
        public HackStaticInstance(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            Logging.Core.StaticInstanceOfLoggingServiceProvider.SetInstance(loggingServiceProvider);
        }
    }
}