using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Sinks {
    public static class LogEventSinkFilterExtensions {
        public static IEnumerable<LogEvent> Where(this IEnumerable<LogEvent> logEvents, SinkConfiguration loggingConfiguration) {
            return LogEventSinkFilter.Filter(logEvents, loggingConfiguration);
        }
    }
}