using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Internals;

namespace Cosmos.Logging.Filters {
    /// <summary>
    /// Log event sink filter
    /// </summary>
    public static class LogEventSinkFilter {
        private static readonly LogEvent[] EmptyLogEvents = new LogEvent[0];

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="logEvents"></param>
        /// <param name="sinkConfiguration"></param>
        /// <returns></returns>
        public static IEnumerable<LogEvent> Filter(IEnumerable<LogEvent> logEvents, SinkConfiguration sinkConfiguration) {
            if (logEvents == null || sinkConfiguration == null) return EmptyLogEvents;
            return logEvents.Where(logEvent => FurtherEventPercolator.Percolate(logEvent, sinkConfiguration));
        }
    }
}