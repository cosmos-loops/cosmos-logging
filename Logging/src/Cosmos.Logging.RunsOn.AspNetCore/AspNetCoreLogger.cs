using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;
using Microsoft.AspNetCore.Http;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLogger : LoggerBase {

        public AspNetCoreLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerName,
            LogEventSendMode sendMode,
            ILogPayloadSender logPayloadSender,
            IHttpContextAccessor httpContextAccessor)
            : base(sourceType, minimumLevel, loggerName, sendMode, logPayloadSender) {

            HttpContext = httpContextAccessor?.HttpContext;

        }

        public HttpContext HttpContext { get; }
    }
}