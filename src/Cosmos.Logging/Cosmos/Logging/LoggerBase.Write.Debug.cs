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
        public virtual void LogDebug(string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }


        /// <inheritdoc />
        public virtual void LogDebug(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(null, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2,
                arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Debug, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }
    }
}