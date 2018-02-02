using System;
using Cosmos.Logging.Core.Callers;

namespace Cosmos.Logging.Events {
    public struct ManuallyLogEventDescriptor {
        public ManuallyLogEventDescriptor(LogEventLevel level, Exception exception, string messageTemplate,
            ILogCallerInfo callerInfo, AdditionalOptContext context = null, params object[] messageTemplateParameters) {
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate;
            CallerInfo = callerInfo;
            Context = context;
            MessageTemplateParameters = messageTemplateParameters;
        }

        public LogEventLevel Level { get; }
        public Exception Exception { get; }
        public string MessageTemplate { get; }
        public ILogCallerInfo CallerInfo { get; }
        public AdditionalOptContext Context { get; }
        public object[] MessageTemplateParameters { get; }

        public void Deconstruct(out LogEventLevel level, out Exception exception, out string messageTemplate, out LogEventSendMode sendMode,
            out ILogCallerInfo callerInfo, out AdditionalOptContext context, out object[] messageTemplateParameters) {
            level = Level;
            exception = Exception;
            messageTemplate = MessageTemplate;
            sendMode = LogEventSendMode.Manually;
            callerInfo = CallerInfo;
            context = Context;
            messageTemplateParameters = MessageTemplateParameters;
        }
    }
}