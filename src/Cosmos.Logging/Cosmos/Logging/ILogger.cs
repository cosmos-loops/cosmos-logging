using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging {
    /// <summary>
    /// Interface for Logger
    /// </summary>
    public partial interface ILogger {
        /// <summary>
        /// Minimum level
        /// </summary>
        LogEventLevel MinimumLevel { get; }

        /// <summary>
        /// Gets send mode
        /// </summary>
        LogEventSendMode SendMode { get; }

        /// <summary>
        /// Is enable
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(LogEventLevel level);

        /// <summary>
        /// Begin a new scope
        /// </summary>
        /// <param name="state"></param>
        /// <typeparam name="TState"></typeparam>
        /// <returns></returns>
        IDisposable BeginScope<TState>(TState state);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="sendMode"></param>
        /// <param name="callerInfo"></param>
        /// <param name="context"></param>
        /// <param name="messageTemplateParameters"></param>
        void Write(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate,
            LogEventSendMode sendMode, ILogCallerInfo callerInfo, LogEventContext context = null,
            params object[] messageTemplateParameters);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="logEvent"></param>
        void Write(LogEvent logEvent);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="descriptor"></param>
        void Write(FutureLogEventDescriptor descriptor);

        /// <summary>
        /// Submit logger
        /// </summary>
        void SubmitLogger();

        /// <summary>
        /// To future logger
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// To simple logger
        /// </summary>
        /// <returns></returns>
        ISimpleLogger ToSimple();
    }
}