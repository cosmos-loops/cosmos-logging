using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.RunsOn.NancyFX {
    /// <summary>
    /// Nancy simple logger
    /// </summary>
    public sealed class NancySimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal NancySimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}