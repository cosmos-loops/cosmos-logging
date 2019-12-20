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
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogTrack logTrack, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogTrack logTrack, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogVerbose<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogVerbose<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogVerbose<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
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
        void LogVerbose<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogTrack @event, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogDebug<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogDebug<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogDebug<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
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
        void LogDebug<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogDebug(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogTrack @event, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        void LogInformation<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        void LogInformation<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogInformation<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
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
        void LogInformation<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        void LogInformation(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogTrack @event, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogWarning<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
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
        void LogWarning<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogWarning<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
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
        void LogWarning<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogWarning<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
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
        void LogWarning<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogWarning<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
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
        void LogWarning<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
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
        void LogWarning<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogWarning(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogTrack @event, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogError<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
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
        void LogError<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogError<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
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
        void LogError<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogError<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
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
        void LogError<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogError<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
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
        void LogError<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
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
        void LogError<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogError(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogTrack @event, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogFatal<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
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
        void LogFatal<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogFatal<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
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
        void LogFatal<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        void LogFatal<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
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
        void LogFatal<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        void LogFatal<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
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
        void LogFatal<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
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
        void LogFatal<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="event"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void LogFatal(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);
    }
}