using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Sinks {
    public static class LogEventSinkFilter {
        public static IEnumerable<LogEvent> Filter(IEnumerable<LogEvent> logEvents, LogEventLevel? level) {
            if (logEvents == null) return Enumerable.Empty<LogEvent>();
            var realLevel = level ?? LogEventLevel.Verbose;
            return realLevel == LogEventLevel.Off ? Enumerable.Empty<LogEvent>() : FilterAfterChecking(logEvents, realLevel);
        }

        private static IEnumerable<LogEvent> FilterAfterChecking(IEnumerable<LogEvent> logEvents, LogEventLevel realLevel) {
            return logEvents.Where(logEvent => logEvent.Level != LogEventLevel.Off && (int) logEvent.Level >= (int) realLevel);
        }
    }
}