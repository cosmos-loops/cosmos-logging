using System;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Extensions.Microsoft.Core {
    internal class StaticServiceResolveInitialization {
        public StaticServiceResolveInitialization(ILoggingServiceProvider loggingServiceProvider, Action additionalAction = null) {
            if (loggingServiceProvider is null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            StaticServiceResolver.SetResolver(loggingServiceProvider);
            additionalAction?.Invoke();
        }
    }
}