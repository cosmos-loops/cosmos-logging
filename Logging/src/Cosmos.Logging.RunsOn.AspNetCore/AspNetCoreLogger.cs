using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Cosmos.Logging.RunsOn.AspNetCore.Core;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLogger : LoggerBase, Microsoft.Extensions.Logging.ILogger {

        public AspNetCoreLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode,MessageTemplateRenderingOptions renderingOptions, ILogPayloadSender logPayloadSender, IHttpContextAccessor httpContextAccessor)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode,renderingOptions, logPayloadSender) {

            HttpContext = httpContextAccessor?.HttpContext;
        }

        public HttpContext HttpContext { get; }

        #region Speaking as Microsoft.Extensions.Logging

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            var messageTemplate = formatter(state, exception);
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            Write(eventId.ToEventId(), LogLevelSwitcher.Switch(logLevel), exception, messageTemplate,
                LogEventSendMode.Customize, NullLogCallerInfo.Instance);
        }

        public bool IsEnabled(LogLevel logLevel) {
            return IsEnabled(LogLevelSwitcher.Switch(logLevel));
        }

        #endregion


    }
}