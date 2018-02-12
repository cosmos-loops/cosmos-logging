using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Exceptionless;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public static class LoggerExtensions {
        public static void LogVerbose(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogVerbose(messageTemplate, eventContextAct, memberName);
        }

        public static void LogVerbose(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogVerbose(exception, messageTemplate, eventContextAct, memberName);
        }

        public static void LogDebug(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogDebug(messageTemplate, eventContextAct, memberName);
        }

        public static void LogDebug(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogDebug(exception, messageTemplate, eventContextAct, memberName);
        }

        public static void LogInformation(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogInformation(messageTemplate, eventContextAct, memberName);
        }

        public static void LogInformation(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogInformation(exception, messageTemplate, eventContextAct, memberName);
        }

        public static void LogWarning(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogWarning(messageTemplate, eventContextAct, memberName, filePath, lineNumber);
        }

        public static void LogWarning(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogWarning(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber);
        }

        public static void LogError(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogError(messageTemplate, eventContextAct, memberName, filePath, lineNumber);
        }

        public static void LogError(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogError(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber);
        }

        public static void LogFatal(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogFatal(messageTemplate, eventContextAct, memberName, filePath, lineNumber);
        }

        public static void LogFatal(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void eventContextAct(LogEventContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogFatal(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber);
        }
    }
}