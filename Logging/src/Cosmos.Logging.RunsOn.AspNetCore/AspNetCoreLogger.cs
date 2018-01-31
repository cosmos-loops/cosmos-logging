using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Cosmos.Logging.RunsOn.AspNetCore.Core;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLogger : LoggerBase, Microsoft.Extensions.Logging.ILogger {

        public AspNetCoreLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, ILogPayloadSender logPayloadSender, IHttpContextAccessor httpContextAccessor)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, logPayloadSender) {

            HttpContext = httpContextAccessor?.HttpContext;
        }

        public HttpContext HttpContext { get; }

        #region Speaking as Microsoft.Extensions.Logging

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            var messageTemplate = formatter(state, exception);
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            Write(LogLevelSwitcher.Switch(logLevel), exception, messageTemplate, LogEventSendMode.Customize);
        }

        public bool IsEnabled(LogLevel logLevel) {
            return IsEnabled(LogLevelSwitcher.Switch(logLevel));
        }

        #endregion


    }
}