using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters {
    internal static class FurtherEventPercolator {
        public static bool Percolate(LogEvent logEvent, SinkConfiguration sinkConfiguration) {
            if (sinkConfiguration == null) return false;

            var defaultLevel = sinkConfiguration.GetDefaultMinimumLevel();
            if (defaultLevel == LogEventLevel.Off) return false;

            return (int) logEvent.Level >= (int) defaultLevel;
        }
    }
}