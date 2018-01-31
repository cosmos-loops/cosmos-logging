using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.MicrosoftExtensions.Core {
    public class CosmosLoggerProxy : LoggerBase {

        public CosmosLoggerProxy(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, logPayloadSender) { }
    }
}