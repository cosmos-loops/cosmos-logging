using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public class NullLogger : ILogger {
        private readonly static NullLogger NullLoggerCache;

        static NullLogger() {
            NullLoggerCache = new NullLogger();
        }

        public static NullLogger Instance => NullLoggerCache;

        public string Name { get; }
        public LogEventLevel MinimumLevel { get; }
        public LogEventSendMode SendMode { get; }

        public bool IsEnabled(LogEventLevel level) => false;

        public IDisposable BeginScope<TState>(TState state) => default(IDisposable);

        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode,
            AdditionalOptContext context = null, params object[] messageTemplateParameters) { }

        public void Write(LogEvent logEvent) { }

        public void SubmitLogger() { }
        public void LogVerbose(string messageTemplate) { }

        public void LogVerbose<T>(string messageTemplate, T paramObject) { }

        public void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogVerbose(string messageTemplate, params object[] paramObjects) { }

        public void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogVerbose(Exception exception, string messageTemplate) { }

        public void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject) { }

        public void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogVerbose(Exception exception, string messageTemplate, params object[] paramObjects) { }

        public void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) { }

        public void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogDebug(string messageTemplate) { }

        public void LogDebug<T>(string messageTemplate, T paramObject) { }

        public void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogDebug(string messageTemplate, params object[] paramObjects) { }

        public void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogDebug(Exception exception, string messageTemplate) { }

        public void LogDebug<T>(Exception exception, string messageTemplate, T paramObject) { }

        public void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogDebug(Exception exception, string messageTemplate, params object[] paramObjects) { }

        public void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogInformation(string messageTemplate) { }

        public void LogInformation<T>(string messageTemplate, T paramObject) { }

        public void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogInformation(string messageTemplate, params object[] paramObjects) { }

        public void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogInformation(Exception exception, string messageTemplate) { }

        public void LogInformation<T>(Exception exception, string messageTemplate, T paramObject) { }

        public void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogInformation(Exception exception, string messageTemplate, params object[] paramObjects) { }

        public void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) { }

        public void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogWarning(string messageTemplate) { }

        public void LogWarning<T>(string messageTemplate, T paramObject) { }

        public void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogWarning(string messageTemplate, params object[] paramObjects) { }

        public void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogWarning(Exception exception, string messageTemplate) { }

        public void LogWarning<T>(Exception exception, string messageTemplate, T paramObject) { }

        public void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogWarning(Exception exception, string messageTemplate, params object[] paramObjects) { }

        public void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) { }

        public void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogError(string messageTemplate) { }

        public void LogError<T>(string messageTemplate, T paramObject) { }

        public void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogError(string messageTemplate, params object[] paramObjects) { }

        public void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogError(Exception exception, string messageTemplate) { }

        public void LogError<T>(Exception exception, string messageTemplate, T paramObject) { }

        public void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogError(Exception exception, string messageTemplate, params object[] paramObjects) { }

        public void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogFatal(string messageTemplate) { }

        public void LogFatal<T>(string messageTemplate, T paramObject) { }

        public void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogFatal(string messageTemplate, params object[] paramObjects) { }

        public void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }

        public void LogFatal(Exception exception, string messageTemplate) { }

        public void LogFatal<T>(Exception exception, string messageTemplate, T paramObject) { }

        public void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) { }

        public void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) { }

        public void LogFatal(Exception exception, string messageTemplate, params object[] paramObjects) { }

        public void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) { }

        public void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) { }
    }
}