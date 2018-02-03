using System;
using System.Runtime.CompilerServices;
using Exceptionless;

// ReSharper disable ExplicitCallerInfoArgument
// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class LoggerExtensions {
        public static void LogVerbose(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogVerbose(messageTemplate, OptCtxAct, memberName);
        }

        public static void LogVerbose(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogVerbose(exception, messageTemplate, OptCtxAct, memberName);
        }

        public static void LogDebug(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogDebug(messageTemplate, OptCtxAct, memberName);
        }

        public static void LogDebug(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogDebug(exception, messageTemplate, OptCtxAct, memberName);
        }

        public static void LogInformation(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogInformation(messageTemplate, OptCtxAct, memberName);
        }

        public static void LogInformation(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogInformation(exception, messageTemplate, OptCtxAct, memberName);
        }

        public static void LogWarning(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogWarning(messageTemplate, OptCtxAct, memberName, filePath, lineNumber);
        }

        public static void LogWarning(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogWarning(exception, messageTemplate, OptCtxAct, memberName, filePath, lineNumber);
        }

        public static void LogError(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogError(messageTemplate, OptCtxAct, memberName, filePath, lineNumber);
        }

        public static void LogError(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogError(exception, messageTemplate, OptCtxAct, memberName, filePath, lineNumber);
        }

        public static void LogFatal(this ILogger logger, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogFatal(messageTemplate, OptCtxAct, memberName, filePath, lineNumber);
        }

        public static void LogFatal(this ILogger logger, Exception exception, string messageTemplate,
            Func<EventBuilder, EventBuilder> eventBuilderFunc,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            void OptCtxAct(AdditionalOptContext ctx) => ctx.ForExceptionless(eventBuilderFunc);
            logger.LogFatal(exception, messageTemplate, OptCtxAct, memberName, filePath, lineNumber);
        }
    }
}