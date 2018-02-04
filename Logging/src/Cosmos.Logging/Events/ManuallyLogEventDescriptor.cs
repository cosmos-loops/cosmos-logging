using System;
using Cosmos.Logging.Core.Callers;

namespace Cosmos.Logging.Events {
    public struct ManuallyLogEventDescriptor {
        public ManuallyLogEventDescriptor(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate,
            ILogCallerInfo callerInfo, LogEventContext context = null, params object[] messageTemplateParameters) {
            EventId = eventId;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate;
            CallerInfo = callerInfo;
            Context = context;
            MessageTemplateParameters = messageTemplateParameters;
        }

        public LogEventId EventId { get; }
        public LogEventLevel Level { get; }
        public Exception Exception { get; }
        public string MessageTemplate { get; }
        public ILogCallerInfo CallerInfo { get; }
        public LogEventContext Context { get; }
        public object[] MessageTemplateParameters { get; }
    }
}