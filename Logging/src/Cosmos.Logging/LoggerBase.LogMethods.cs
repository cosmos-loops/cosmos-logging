using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public abstract partial class LoggerBase {

        public virtual void LogVerbose(string messageTemplate) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogVerbose<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogVerbose<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogDebug(string messageTemplate) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogDebug<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogDebug<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }


        public virtual void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogInformation(string messageTemplate) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogInformation<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogInformation<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogInformation<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogInformation<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogWarning(string messageTemplate) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogWarning<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogWarning<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogWarning<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogWarning<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogError(string messageTemplate) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogError<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogError<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogError(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogError<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogError<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogFatal(string messageTemplate) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogFatal<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogFatal<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }
    }
}