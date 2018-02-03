using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public partial interface ILogger {
        LogEventLevel MinimumLevel { get; }

        LogEventSendMode SendMode { get; }

        bool IsEnabled(LogEventLevel level);

        IDisposable BeginScope<TState>(TState state);

        void Write(LogEventId? eventId, LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, ILogCallerInfo callerInfo,
            AdditionalOptContext context = null, params object[] messageTemplateParameters);

        void Write(LogEvent logEvent);

        void SubmitLogger();
    }
}