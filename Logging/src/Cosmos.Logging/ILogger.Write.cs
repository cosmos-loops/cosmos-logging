using System;
using System.Runtime.CompilerServices;

namespace Cosmos.Logging {
    public partial interface ILogger {
            void LogVerbose(string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogVerbose(string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogVerbose(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogVerbose(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogVerbose(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogVerbose(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogVerbose(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogDebug(string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogDebug(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogDebug(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogDebug(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogInformation(string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null);

        void LogInformation(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogInformation(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null);

        void LogInformation(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects);

        void LogWarning(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogWarning(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogWarning(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogWarning(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogWarning(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogError(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogError(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogFatal(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0
            , params object[] paramObjects);

        void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogFatal(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);

        void LogFatal(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        void LogFatal(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects);
    }
}