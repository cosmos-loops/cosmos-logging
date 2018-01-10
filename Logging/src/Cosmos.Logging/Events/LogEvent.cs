using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Events {
    public class LogEvent {
        private readonly AdditionalOptContext _additionalOptContext;

        public LogEvent(
            DateTimeOffset timestamp,
            LogEventLevel level,
            string messageTemplate,
            Exception exception,
            LogEventSendMode sendMode,
            AdditionalOptContext context = null) {

            if (string.IsNullOrWhiteSpace(messageTemplate))
                throw new ArgumentNullException(nameof(messageTemplate));

            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate;
            SendMode = sendMode;

            _additionalOptContext = context ?? new AdditionalOptContext();
        }

        public DateTimeOffset Timestamp { get; }
        public LogEventLevel Level { get; }
        public LogEventSendMode SendMode { get; }
        public Exception Exception { get; }
        public string MessageTemplate { get; }

        public string RenderMessage(IFormatProvider provider) {
            return MessageTemplate;
        }

        public IEnumerable<IAdditionalOperation> GetAdditionalOperations(Type flagType, AdditionalOperationTypes optType)
            => LogAdditionalOperationFilter.Filter(_additionalOptContext, flagType, optType);
    }
}