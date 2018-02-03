using System;
using System.Web;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLogger : LoggerBase {
        public AspNetLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, MessageTemplateRenderingOptions renderingOptions, ILogPayloadSender logPayloadSender, HttpContext context)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, renderingOptions, logPayloadSender) {
            HttpContext = context;
        }

        public HttpContext HttpContext { get; }
    }
}