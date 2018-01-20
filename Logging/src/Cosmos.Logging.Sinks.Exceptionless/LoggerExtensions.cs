using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Exceptionless;
using Exceptionless;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class LoggerExtensions {
        public static void LogVerbose(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogVerbose(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogVerbose(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogVerbose(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogDebug(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogDebug(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogDebug(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogDebug(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogInformation(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogInformation(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogInformation(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogInformation(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogWarning(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogWarning(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogWarning(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogWarning(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogError(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogError(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogError(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogError(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogFatal(this ILogger logger, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogFatal(messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }

        public static void LogFatal(this ILogger logger, Exception exception, string messageTemplate, Func<EventBuilder, EventBuilder> eventBuilderFunc,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            logger.LogFatal(exception, messageTemplate, ctx => ctx.ForExceptionless(eventBuilderFunc), mode);
        }
    }
}