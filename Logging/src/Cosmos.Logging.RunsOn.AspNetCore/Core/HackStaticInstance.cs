using System;

namespace Cosmos.Logging.RunsOn.AspNetCore.Core {
    internal class HackStaticInstance {
        public HackStaticInstance(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            Logging.Core.StaticInstanceOfLoggingServiceProvider.SetInstance(loggingServiceProvider);
        }

        public static bool UsingSecInitializingActivation { get; set; } = true;
    }
}