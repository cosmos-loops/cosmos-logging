using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Sinks {
    public static class LogEventSinkFilter {
        public static IEnumerable<LogEvent> Filter(IEnumerable<LogEvent> logEvents, LogEventLevel? level) {
            if (logEvents == null) return Enumerable.Empty<LogEvent>();
            if (!level.HasValue) return Enumerable.Empty<LogEvent>();
            var realLevel = level.Value;
            if (realLevel == LogEventLevel.Off) return Enumerable.Empty<LogEvent>();
            return FilterAfterChecking(logEvents, realLevel);
        }

        private static IEnumerable<LogEvent> FilterAfterChecking(IEnumerable<LogEvent> logEvents, LogEventLevel realLevel) {
            foreach (var logEvent in logEvents) {
                if (logEvent.Level == LogEventLevel.Off) continue;
                if ((int) logEvent.Level < (int) realLevel) continue;
                yield return logEvent;
            }
        }
    }
}