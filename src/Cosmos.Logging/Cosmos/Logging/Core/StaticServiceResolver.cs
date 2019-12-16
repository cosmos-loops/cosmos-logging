using System;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Static service resolver
    /// </summary>
    public static class StaticServiceResolver {
        private static ILoggingServiceProvider _loggingServiceProvider;

        /// <summary>
        /// Set a new resolver ro replace the original one.
        /// </summary>
        /// <param name="loggingServiceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetResolver(ILoggingServiceProvider loggingServiceProvider) {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            if (_loggingServiceProvider == null) {
                _loggingServiceProvider = loggingServiceProvider;
            }
        }

        /// <summary>
        /// Get current logging service provider
        /// </summary>
        public static ILoggingServiceProvider Instance
            => _loggingServiceProvider ?? throw new NullReferenceException($"Instance of {nameof(ILoggingServiceProvider)} has not been initialized.");
    }
}