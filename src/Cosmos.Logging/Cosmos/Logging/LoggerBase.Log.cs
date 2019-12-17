using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    /// <summary>
    /// Logger base
    /// </summary>
    public abstract partial class LoggerBase {
        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventLevel level, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventLevel level, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventLevel level, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(null, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventLevel level, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventLevel level, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(null, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventId eventId, LogEventLevel level, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventId eventId, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventId eventId, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, null, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventId eventId, LogEventLevel level, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventId eventId, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventId eventId, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, null, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber));
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            Write(eventId, level, exception, messageTemplate, LogEventSendMode.Customize,
                new LogCallerInfo(memberName, filePath, lineNumber), null, args);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void Log<T>(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public virtual void Log<T1, T2>(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public virtual void Log<T1, T2, T3>(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, arg1, arg2, arg3);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public virtual void Log(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            var ctx = TouchLogEventContext(contextAct);
            Write(eventId, level, exception, messageTemplate, ctx.SendMode,
                new LogCallerInfo(memberName, filePath, lineNumber), ctx, args);
        }
    }
}