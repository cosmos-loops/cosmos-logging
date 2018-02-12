using System;

namespace Cosmos.Logging.RunsOn.AspNetCore.Core {
    internal class StaticServiceResolveInitialization {
        public StaticServiceResolveInitialization(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            Logging.Core.StaticServiceResolver.SetResolver(loggingServiceProvider);
        }

        public static bool UsingSecInitializingActivation { get; set; } = true;
    }
}