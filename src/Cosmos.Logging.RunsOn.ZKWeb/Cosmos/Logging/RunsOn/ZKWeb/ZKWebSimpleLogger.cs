using System;
using System.Diagnostics.CodeAnalysis;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.RunsOn.ZKWeb {
    /// <summary>
    /// ZKWeb simple logger
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public sealed class ZKWebSimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal ZKWebSimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}