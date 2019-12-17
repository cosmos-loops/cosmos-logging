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
        public virtual void LogVerbose(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        /// <inheritdoc />
        /// <inheritdoc />
        public virtual void LogVerbose<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2,
                arg3);
        }

        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Verbose, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
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

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogInformation<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2,
                arg3);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, null, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName));
        }

        /// <inheritdoc />
        public virtual void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, arg1, arg2,
                arg3);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, new LogCallerInfo(memberName), null, args);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Information, exception, messageTemplate, ctx.SendMode, new LogCallerInfo(memberName), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogWarning<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Warning, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <inheritdoc />
        public virtual void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <inheritdoc />
        public virtual void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <inheritdoc />
        public virtual void LogError(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, LogEventLevel.Error, exception, messageTemplate, ctx.SendMode,
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