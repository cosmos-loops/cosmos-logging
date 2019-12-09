using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters.Internals {
    internal static class FurtherEventPercolator {
        public static bool Percolate(ILogEventInfo logEventInfo, SinkConfiguration sinkConfiguration) {
            if (sinkConfiguration == null) return false;
            if (logEventInfo == null) return false;

            var defaultLevel = sinkConfiguration.GetMinimumLevel(logEventInfo.StateNamespace);
            if (defaultLevel == LogEventLevel.Off) return false;

            return (int) logEventInfo.Level >= (int) defaultLevel;
        }
    }
}