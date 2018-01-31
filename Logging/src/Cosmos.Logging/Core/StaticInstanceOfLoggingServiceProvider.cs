using System;

namespace Cosmos.Logging.Core {
    public static class StaticInstanceOfLoggingServiceProvider {
        private static ILoggingServiceProvider _loggingServiceProvider;

        public static void SetInstance(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            if (_loggingServiceProvider == null) {
                _loggingServiceProvider = loggingServiceProvider;
            }
        }

        public static ILoggingServiceProvider Instance
            => _loggingServiceProvider ?? throw new NullReferenceException("Instance of ILoggingServiceProvider has not been initialized.");
    }
}