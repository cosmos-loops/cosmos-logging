using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.ZKWeb {
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class ZKWebLogger : LoggerBase, IFutureableLogger<ZKWebFutureLogger> {

        public ZKWebLogger(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, RendingConfiguration renderingOptions, ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, renderingOptions, logPayloadSender) { }

        public override IFutureLogger ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return new ZKWebFutureLogger(this, memberName, filePath, lineNumber);
        }
#pragma warning disable 1066
        ZKWebFutureLogger IFutureableLogger<ZKWebFutureLogger>.ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
#pragma warning restore 1066
            return new ZKWebFutureLogger(this, memberName, filePath, lineNumber);
        }
    }
}