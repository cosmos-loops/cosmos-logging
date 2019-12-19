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
        public virtual void LogFatal(string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogFatal(string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogFatal(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogFatal(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }
        
          /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Fatal, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }
    }
}