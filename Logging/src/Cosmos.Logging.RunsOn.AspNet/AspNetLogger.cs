using System;
using System.Runtime.CompilerServices;
using System.Web;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLogger : LoggerBase, IFutureableLogger<AspNetFutureLogger> {
        public AspNetLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, RendingConfiguration renderingOptions, ILogPayloadSender logPayloadSender, HttpContext context)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, renderingOptions, logPayloadSender) {
            HttpContext = context;
        }

        public HttpContext HttpContext { get; }

        public override IFutureLogger ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return new AspNetFutureLogger(this, memberName, filePath, lineNumber);
        }

        AspNetFutureLogger IFutureableLogger<AspNetFutureLogger>.ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return new AspNetFutureLogger(this, memberName, filePath, lineNumber);
        }
    }
}