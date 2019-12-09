using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging {
    public partial interface ILogger {
        LogEventLevel MinimumLevel { get; }

        LogEventSendMode SendMode { get; }

        bool IsEnabled(LogEventLevel level);

        IDisposable BeginScope<TState>(TState state);

        void Write(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate,
            LogEventSendMode sendMode, ILogCallerInfo callerInfo, LogEventContext context = null,
            params object[] messageTemplateParameters);

        void Write(LogEvent logEvent);

        void Write(FutureLogEventDescriptor descriptor);

        void SubmitLogger();

        IFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);
    }
}