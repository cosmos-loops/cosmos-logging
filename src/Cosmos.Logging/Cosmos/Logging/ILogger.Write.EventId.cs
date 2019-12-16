using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    /// <summary>
    /// Interface for logger
    /// </summary>
    public partial interface ILogger {
        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogEventId eventId, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
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
        void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);
    }
}