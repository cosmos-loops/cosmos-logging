using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Cosmos.Logging.RunsOn.AspNetCore.Core;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core Logger
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class AspNetCoreLogger : LoggerBase, IFutureableLogger<AspNetCoreFutureLogger>, Microsoft.Extensions.Logging.ILogger {

        /// <inheritdoc />
        public AspNetCoreLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, RenderingConfiguration renderingOptions, ILogPayloadSender logPayloadSender, IHttpContextAccessor httpContextAccessor)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, renderingOptions, logPayloadSender) {

            HttpContext = httpContextAccessor?.HttpContext;
        }

        /// <summary>
        /// Gets HttpContext
        /// </summary>
        public HttpContext HttpContext { get; }

        #region Speaking as Microsoft.Extensions.Logging

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            var messageTemplate = formatter(state, exception);
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            Write(eventId.ToEventId(), LogLevelSwitcher.Switch(logLevel), exception, messageTemplate,
                LogEventSendMode.Customize, NullLogCallerInfo.Instance);
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) {
            return IsEnabled(LogLevelSwitcher.Switch(logLevel));
        }

        #endregion

        /// <inheritdoc />
        public override IFutureLogger ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return new AspNetCoreFutureLogger(this, memberName, filePath, lineNumber);
        }

#pragma warning disable 1066,4024,4025,4026
        AspNetCoreFutureLogger IFutureableLogger<AspNetCoreFutureLogger>.ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
#pragma warning restore 1066,4024,4025,4026
            return new AspNetCoreFutureLogger(this, memberName, filePath, lineNumber);
        }
    }
}