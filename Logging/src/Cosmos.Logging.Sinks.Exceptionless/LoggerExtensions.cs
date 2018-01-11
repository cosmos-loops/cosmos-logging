using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Exceptionless;
using Exceptionless;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class LoggerExtensions {
        public static void Verbose(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Verbose(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Verbose(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Verbose(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Debug(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Debug(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Debug(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Debug(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Information(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Information(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Information(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Information(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Warning(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Warning(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Warning(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Warning(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Error(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Error(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Error(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Error(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Fatal(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Fatal(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void Fatal(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.Fatal(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }
    }
}