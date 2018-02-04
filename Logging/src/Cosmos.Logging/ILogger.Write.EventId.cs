using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public partial interface ILogger {
        void LogVerbose(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogVerbose(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogVerbose(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogDebug(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogInformation(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null);

        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogWarning(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogWarning(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogFatal(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0
            , params object[] paramObjects);

        void LogFatal(LogEventId eventId, string messageTemplate, Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(LogEventId eventId, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);
    }
}