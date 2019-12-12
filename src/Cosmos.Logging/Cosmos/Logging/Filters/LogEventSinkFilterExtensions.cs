using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters {
    /// <summary>
    /// Extensions for log event sink filter
    /// </summary>
    public static class LogEventSinkFilterExtensions {
        /// <summary>
        /// Where
        /// </summary>
        /// <param name="logEvents"></param>
        /// <param name="loggingConfiguration"></param>
        /// <returns></returns>
        public static IEnumerable<LogEvent> Where(this IEnumerable<LogEvent> logEvents, SinkConfiguration loggingConfiguration) {
            return LogEventSinkFilter.Filter(logEvents, loggingConfiguration);
        }
    }
}