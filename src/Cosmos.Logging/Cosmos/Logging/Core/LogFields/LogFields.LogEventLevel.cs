using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Log event level field
    /// </summary>
    public class LogEventLevelField : ILogField<LogEventLevel> {
        /// <summary>
        /// Create a new instance of <see cref="LogEventLevelField"/>.
        /// </summary>
        /// <param name="level"></param>
        public LogEventLevelField(LogEventLevel level) => Value = level;

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.LogEventLevel;

        /// <inheritdoc />
        public LogEventLevel Value { get; }

        /// <inheritdoc />
        public int Sort { get; set; } = 1;
    }
}