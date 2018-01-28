using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.RunsOn.Console {
    public class ConsoleLogger : LoggerBase {

        public ConsoleLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, LogEventSendMode sendMode,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, sendMode, logPayloadSender) { }
    }
}