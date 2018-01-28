using System;
using System.Web;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLogger : LoggerBase {
        public AspNetLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, LogEventSendMode sendMode,
            ILogPayloadSender logPayloadSender, HttpContext context)
            : base(sourceType, minimumLevel, loggerStateNamespace, sendMode, logPayloadSender) {
            HttpContext = context;
        }

        public HttpContext HttpContext { get; }
    }
}