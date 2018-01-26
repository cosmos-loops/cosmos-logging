using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.RunsOn.Console {
    public class ConsoleLogger : LoggerBase {

        public ConsoleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerName,
            LogEventSendMode sendMode,
            LoggingConfiguration loggingConfiguration,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerName, sendMode, loggingConfiguration, logPayloadSender) { }
    }
}