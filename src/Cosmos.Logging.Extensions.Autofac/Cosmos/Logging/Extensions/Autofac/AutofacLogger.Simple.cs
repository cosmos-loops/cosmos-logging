using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.Extensions.Autofac {
    /// <summary>
    /// Autofac simple Logger
    /// </summary>
    public sealed class AutofacSimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal AutofacSimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}