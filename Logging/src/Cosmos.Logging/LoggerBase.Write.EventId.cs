using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public abstract partial class LoggerBase {

        public virtual void LogVerbose(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogVerbose<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogVerbose(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogVerbose<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2,
                paramObject3);
        }

        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogDebug(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogDebug<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogDebug(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogDebug<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }


        public virtual void LogDebug(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2,
                paramObject3);
        }

        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogInformation(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogInformation<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2,
                paramObject3);
        }

        public virtual void LogInformation(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogInformation(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogInformation<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2,
                paramObject3);
        }

        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogWarning(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogWarning<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogWarning(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogWarning<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogError(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogError<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogError(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogError<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogFatal(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogFatal<T>(LogEventId eventId, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogFatal(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogFatal<T>(LogEventId eventId, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(LogEventId eventId, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }
    }
}