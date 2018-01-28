using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Internals;

namespace Cosmos.Logging.Filters {
    public static class LogEventSinkFilter {
        private static readonly LogEvent[] EmptyLogEvents = new LogEvent[0];

        public static IEnumerable<LogEvent> Filter(IEnumerable<LogEvent> logEvents, SinkConfiguration sinkConfiguration) {
            if (logEvents == null || sinkConfiguration == null) return EmptyLogEvents;
            return logEvents.Where(logEvent => FurtherEventPercolator.Percolate(logEvent, sinkConfiguration));
        }
    }
}