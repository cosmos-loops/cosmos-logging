using System;
using Cosmos.Logging.Core.Sinks;
using Cosmos.Logging.Sinks.Exceptionless;
using Exceptionless;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
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