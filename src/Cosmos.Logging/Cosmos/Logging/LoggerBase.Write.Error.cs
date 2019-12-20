using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    /// <summary>
    /// Logger base
    /// </summary>
    public abstract partial class LoggerBase {
        /// <inheritdoc />
        public virtual void LogError(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogError<T>(string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogError(string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogError<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogError(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogError<T>(Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogError(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogError<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(Exception exception, string messageTemplate, object[] args,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogTrack logTrack, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogTrack logTrack, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogTrack logTrack, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(logTrack, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }
    }
}