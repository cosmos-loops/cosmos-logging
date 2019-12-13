using System;
using Cosmos.Logging.Core.Sinks;
using Cosmos.Logging.Future;
using Cosmos.Logging.Sinks.Exceptionless;
using Exceptionless;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for exceptionless operation
    /// </summary>
    public static class ExceptionlessOperationExtensions {
        /// <summary>
        /// Additional operation for exceptionless
        /// </summary>
        /// <param name="context"></param>
        /// <param name="additionalOptHandle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LogEventContext ForExceptionless(this LogEventContext context, Func<EventBuilder, EventBuilder> additionalOptHandle) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (additionalOptHandle == null) return context;

            var opt = new LogSinkAdditionalOperation(typeof(ExceptionlessPayloadClient), additionalOptHandle);
            context.ImportOpt(opt);

            return context;
        }

        /// <summary>
        /// Append additional operation
        /// </summary>
        /// <param name="futureLogger"></param>
        /// <param name="additionalOptHandle"></param>
        /// <returns></returns>
        public static IFutureLogger AppendAdditionalOperation(this IFutureLogger futureLogger, Func<EventBuilder, EventBuilder> additionalOptHandle) {
            var opt = new LogSinkAdditionalOperation(typeof(ExceptionlessPayloadClient), additionalOptHandle);
            futureLogger.AppendAdditionalOperation(opt);

            return futureLogger;
        }
    }
}