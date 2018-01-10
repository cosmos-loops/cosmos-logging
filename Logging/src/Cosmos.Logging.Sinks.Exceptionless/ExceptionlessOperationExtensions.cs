using System;
using Cosmos.Logging.Core.Sinks;
using Exceptionless;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public static class ExceptionlessOperationExtensions {
        public static AdditionalOptContext ForExceptionless(this AdditionalOptContext context, Func<EventBuilder, EventBuilder> additionalOptHandle) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (additionalOptHandle == null) return context;

            var opt = new LogSinkAdditionalOperation(typeof(ExceptionlessPayloadClient), additionalOptHandle);
            context.ImportOpt(opt);

            return context;
        }
    }
}