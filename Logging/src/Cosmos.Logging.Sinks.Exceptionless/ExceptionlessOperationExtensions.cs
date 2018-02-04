using System;
using Cosmos.Logging.Core.Sinks;
using Cosmos.Logging.Future;
using Cosmos.Logging.Sinks.Exceptionless;
using Exceptionless;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class ExceptionlessOperationExtensions {
        public static LogEventContext ForExceptionless(this LogEventContext context, Func<EventBuilder, EventBuilder> additionalOptHandle) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (additionalOptHandle == null) return context;

            var opt = new LogSinkAdditionalOperation(typeof(ExceptionlessPayloadClient), additionalOptHandle);
            context.ImportOpt(opt);

            return context;
        }

        public static IFutureLogger AppendAdditionalOperation(this IFutureLogger futureLogger, Func<EventBuilder, EventBuilder> additionalOptHandle) {
            var opt = new LogSinkAdditionalOperation(typeof(ExceptionlessPayloadClient), additionalOptHandle);
            futureLogger.AppendAdditionalOperation(opt);

            return futureLogger;
        }
    }
}