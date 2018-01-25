using System;
using System.Web;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLogger : LoggerBase {
        public AspNetLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerName,
            LogEventSendMode sendMode,
            LoggingConfiguration loggingConfiguration,
            ILogPayloadSender logPayloadSender,
            HttpContext context) : base(sourceType, minimumLevel, loggerName, sendMode, loggingConfiguration, logPayloadSender) {
            HttpContext = context;
        }

        public HttpContext HttpContext { get; }
    }
}