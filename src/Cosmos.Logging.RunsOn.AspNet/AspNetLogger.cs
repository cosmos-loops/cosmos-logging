using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Web;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.AspNet {
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class AspNetLogger : LoggerBase, IFutureableLogger<AspNetFutureLogger> {
        public AspNetLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, RenderingConfiguration renderingOptions, ILogPayloadSender logPayloadSender, HttpContext context)
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

#pragma warning disable 1066,4024,4025,4026
        AspNetFutureLogger IFutureableLogger<AspNetFutureLogger>.ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
#pragma warning restore 1066,4024,4025,4026
            return new AspNetFutureLogger(this, memberName, filePath, lineNumber);
        }
    }
}