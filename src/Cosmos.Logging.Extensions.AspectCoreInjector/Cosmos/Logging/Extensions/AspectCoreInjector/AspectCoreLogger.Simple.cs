using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.Extensions.AspectCoreInjector {
    /// <summary>
    /// AspectCore simple Logger
    /// </summary>
    public sealed class AspectCoreSimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal AspectCoreSimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}