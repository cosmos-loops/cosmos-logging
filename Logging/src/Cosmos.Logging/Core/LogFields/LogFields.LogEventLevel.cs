using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.LogFields {
    public class LogEventLevelField : ILogField<LogEventLevel> {
        public LogEventLevelField(LogEventLevel level) => Value = level;
        public LogFieldTypes Type => LogFieldTypes.LogEventLevel;
        public LogEventLevel Value { get; }
    }
}