using System;

namespace Cosmos.Logging.Core {
    public static class StaticServiceResolver {
        private static ILoggingServiceProvider _loggingServiceProvider;

        public static void SetResolver(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            if (_loggingServiceProvider == null) {
                _loggingServiceProvider = loggingServiceProvider;
            }
        }

        public static ILoggingServiceProvider Instance
            => _loggingServiceProvider ?? throw new NullReferenceException($"Instance of {nameof(ILoggingServiceProvider)} has not been initialized.");
    }
}