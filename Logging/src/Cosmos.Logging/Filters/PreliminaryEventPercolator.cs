using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters {
    internal static class PreliminaryEventPercolator {
        public static bool Percolate(LogEventLevel? level, ILogger logger, LoggingConfiguration loggingConfiguration) {
            if (logger == null) return false;
            if (loggingConfiguration == null) return false;
            if (logger.MinimumLevel == LogEventLevel.Off) return false;

            var defaultLevel = loggingConfiguration.GetDefaultMinimumLevel();
            if (defaultLevel == LogEventLevel.Off) return false;

            var realLogEventLevel = GetRealLevel(level);
            if (realLogEventLevel == LogEventLevel.Off) return false;

            if ((int) logger.MinimumLevel > (int) realLogEventLevel) return false;
            if ((int) defaultLevel > (int) realLogEventLevel) return false;

            return true;
        }

        private static LogEventLevel GetRealLevel(LogEventLevel? level) => level ?? LogEventLevel.Verbose;
    }
}