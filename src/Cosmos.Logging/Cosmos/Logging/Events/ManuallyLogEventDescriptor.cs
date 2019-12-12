using System;
using Cosmos.Logging.Core.Callers;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Manually log event descriptor
    /// </summary>
    public struct ManuallyLogEventDescriptor {
        /// <summary>
        /// Create a new instance of <see cref="ManuallyLogEventDescriptor"/>.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="callerInfo"></param>
        /// <param name="context"></param>
        /// <param name="messageTemplateParameters"></param>
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

        /// <summary>
        /// Gets event id
        /// </summary>
        public LogEventId EventId { get; }

        /// <summary>
        /// Gets log event level
        /// </summary>
        public LogEventLevel Level { get; }

        /// <summary>
        /// Gets exception
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets message template
        /// </summary>
        public string MessageTemplate { get; }

        /// <summary>
        /// Gets caller info
        /// </summary>
        public ILogCallerInfo CallerInfo { get; }

        /// <summary>
        /// Gets context
        /// </summary>
        public LogEventContext Context { get; }

        /// <summary>
        /// Gets message template parameters
        /// </summary>
        public object[] MessageTemplateParameters { get; }
    }
}