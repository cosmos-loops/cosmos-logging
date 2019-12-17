using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.Extensions.Microsoft.Core {
    /// <summary>
    /// Proxy for Cosmos simple logger
    /// </summary>
    public sealed class CosmosSimpleLoggerProxy : SimpleLoggerBase {

        /// <inheritdoc />
        internal CosmosSimpleLoggerProxy(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}