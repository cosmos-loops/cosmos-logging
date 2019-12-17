using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.RunsOn.Console {
    /// <summary>
    /// Console simple logger
    /// </summary>
    public sealed class ConsoleSimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal ConsoleSimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}