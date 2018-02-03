using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public abstract partial class LoggerBase {

        public virtual void LogVerbose(string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogVerbose<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogVerbose(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogVerbose<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogDebug(string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogDebug<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogDebug(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogDebug<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }


        public virtual void LogDebug(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogInformation(string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogInformation<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(string messageTemplate,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            Write(null, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogInformation(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogInformation<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        public virtual void LogInformation<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            Write(null, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, paramObjects);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx);
        }

        public virtual void LogInformation<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, new LogCallerInfo(memberName), optCtx, paramObjects);
        }

        public virtual void LogWarning(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogWarning<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogWarning(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogWarning<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogWarning<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogWarning<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogError(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogError<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogError(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogError<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogError(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogError<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogError(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogError<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogFatal(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogFatal<T>(string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogFatal(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogFatal<T>(string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, paramObjects);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx);
        }

        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), optCtx, paramObjects);
        }
    }
}