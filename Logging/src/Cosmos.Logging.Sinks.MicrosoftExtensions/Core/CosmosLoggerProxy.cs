using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Sinks.MicrosoftExtensions.Core {
    public class CosmosLoggerProxy : LoggerBase, IFutureableLogger<CosmosFutureLoggerProxy> {

        public CosmosLoggerProxy(Type sourceType, LogEventLevel minimumLevel, string loggerStateNamespace, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode, MessageTemplateRenderingOptions renderingOptions, ILogPayloadSender logPayloadSender)
            : base(sourceType, minimumLevel, loggerStateNamespace, filter, sendMode, renderingOptions, logPayloadSender) { }

        public override IFutureLogger ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return new CosmosFutureLoggerProxy(this, memberName, filePath, lineNumber);
        }

        CosmosFutureLoggerProxy IFutureableLogger<CosmosFutureLoggerProxy>.ToFuture(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return new CosmosFutureLoggerProxy(this, memberName, filePath, lineNumber);
        }
    }
}