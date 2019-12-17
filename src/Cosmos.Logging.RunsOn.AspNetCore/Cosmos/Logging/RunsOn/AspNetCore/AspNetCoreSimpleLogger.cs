using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core simple Logger
    /// </summary>
    public sealed class AspNetCoreSimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal AspNetCoreSimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}