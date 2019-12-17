using System;
using System.Threading;

namespace Cosmos.Logging.Trace {
    /// <summary>
    /// Log trace id generator helper
    /// </summary>
    public static class LogTraceIdGenerator {
        private static AsyncLocal<ILogTraceIdGenerator> _currentTraceIdGenerator = new AsyncLocal<ILogTraceIdGenerator>();

        /// <summary>
        /// Scoped update
        /// </summary>
        /// <param name="logTraceIdGenerator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ScopedUpdate(ILogTraceIdGenerator logTraceIdGenerator) {
            if (logTraceIdGenerator is null)
                throw new ArgumentNullException(nameof(logTraceIdGenerator));
            _currentTraceIdGenerator.Value = logTraceIdGenerator;
        }

        /// <summary>
        /// Gets current trace id generator
        /// </summary>
        public static ILogTraceIdGenerator Current => _currentTraceIdGenerator.Value ?? SystemTraceIdGenerator.Fallback;
    }
}