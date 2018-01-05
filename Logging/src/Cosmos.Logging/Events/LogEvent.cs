using System;

namespace Cosmos.Logging.Events {
    public class LogEvent {
        public LogEvent(DateTimeOffset timestamp, LogEventLevel level, string messageTemplate, Exception exception, LogEventSendMode sendMode) {

            if (string.IsNullOrWhiteSpace(messageTemplate))
                throw new ArgumentNullException(nameof(messageTemplate));

            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate;
            SendMode = sendMode;
        }

        public DateTimeOffset Timestamp { get; }
        public LogEventLevel Level { get; }
        public LogEventSendMode SendMode { get; }
        public Exception Exception { get; }
        public string MessageTemplate { get; }
    }
}