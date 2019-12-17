using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging.RunsOn.AspNet {
    /// <summary>
    /// ASP.NET simple Logger
    /// </summary>
    public sealed class AspNetSimpleLogger : SimpleLoggerBase {

        /// <inheritdoc />
        internal AspNetSimpleLogger(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, logPayloadSender) { }
    }
}