using System;

namespace Cosmos.Logging.RunsOn.AspNetCore.Core {
    internal class StaticServiceResolveInitialization {
        public StaticServiceResolveInitialization(ILoggingServiceProvider loggingServiceProvider, Action additionalAction = null) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            Logging.Core.StaticServiceResolver.SetResolver(loggingServiceProvider);
            additionalAction?.Invoke();
        }

        public static bool UsingSecInitializingActivation { get; set; } = true;
    }
}