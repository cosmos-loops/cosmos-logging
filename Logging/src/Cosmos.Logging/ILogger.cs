using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public interface ILogger {

        string Name { get; }

        LogEventLevel MinimumLevel { get; }

        LogEventSendMode SendMode { get; }

        bool IsEnabled(LogEventLevel level);

        IDisposable BeginScope<TState>(TState state);

        void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode,
            AdditionalOptContext context = null, params object[] messageTemplateParameters);

        void Write(LogEvent logEvent);

        void SubmitLogger();

        void LogVerbose(string messageTemplate);

        void LogVerbose<T>(string messageTemplate, T paramObject);

        void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogVerbose(string messageTemplate, params object[] paramObjects);

        void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogVerbose(Exception exception, string messageTemplate);

        void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject);

        void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogVerbose(Exception exception, string messageTemplate, params object[] paramObjects);

        void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogDebug(string messageTemplate);

        void LogDebug<T>(string messageTemplate, T paramObject);

        void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogDebug(string messageTemplate, params object[] paramObjects);

        void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogDebug<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogDebug(Exception exception, string messageTemplate);

        void LogDebug<T>(Exception exception, string messageTemplate, T paramObject);

        void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogDebug(Exception exception, string messageTemplate, params object[] paramObjects);

        void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogDebug<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogInformation(string messageTemplate);

        void LogInformation<T>(string messageTemplate, T paramObject);

        void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogInformation(string messageTemplate, params object[] paramObjects);

        void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogInformation<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogInformation(Exception exception, string messageTemplate);

        void LogInformation<T>(Exception exception, string messageTemplate, T paramObject);

        void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogInformation(Exception exception, string messageTemplate, params object[] paramObjects);

        void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogInformation<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogWarning(string messageTemplate);

        void LogWarning<T>(string messageTemplate, T paramObject);

        void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogWarning(string messageTemplate, params object[] paramObjects);

        void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogWarning<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogWarning(Exception exception, string messageTemplate);

        void LogWarning<T>(Exception exception, string messageTemplate, T paramObject);

        void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogWarning(Exception exception, string messageTemplate, params object[] paramObjects);

        void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogWarning<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogError(string messageTemplate);

        void LogError<T>(string messageTemplate, T paramObject);

        void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogError(string messageTemplate, params object[] paramObjects);

        void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogError<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogError(Exception exception, string messageTemplate);

        void LogError<T>(Exception exception, string messageTemplate, T paramObject);

        void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogError(Exception exception, string messageTemplate, params object[] paramObjects);

        void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogError<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogFatal(string messageTemplate);

        void LogFatal<T>(string messageTemplate, T paramObject);

        void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogFatal(string messageTemplate, params object[] paramObjects);

        void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogFatal<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);

        void LogFatal(Exception exception, string messageTemplate);

        void LogFatal<T>(Exception exception, string messageTemplate, T paramObject);

        void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2);

        void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3);

        void LogFatal(Exception exception, string messageTemplate, params object[] paramObjects);

        void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct);

        void LogFatal<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct);

        void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct);

        void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct);

        void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects);
    }
}