using System;
using System.Runtime.CompilerServices;
using Cosmos.Disposables;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging {
    /// <summary>
    /// Null logger
    /// </summary>
    public sealed class NullLogger : ILogger {
        private static readonly NullLogger NullLoggerCache;

        static NullLogger() {
            NullLoggerCache = new NullLogger();
        }

        /// <summary>
        /// Gets an instance of <see cref="NullLogger"/>.
        /// </summary>
        public static NullLogger Instance => NullLoggerCache;

        /// <summary>
        /// Gets logger's name
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <inheritdoc />
        public void Log(LogEventLevel level, string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogEventLevel level, string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, string messageTemplate, object[] args, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogEventLevel level, string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, Exception exception, string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogEventLevel level, Exception exception, string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, Exception exception, string messageTemplate, object[] args, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, Exception exception, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogEventLevel level, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogEventLevel level, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogTrack @event, LogEventLevel level, string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogTrack @event, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogTrack @event, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, string messageTemplate, object[] args, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogTrack @event, LogEventLevel level, string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogTrack @event, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogTrack @event, LogEventLevel level, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, T arg, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null,
            string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, object[] args, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T>(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2>(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log<T1, T2, T3>(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct, string memberName = null,
            string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void Log(LogTrack @event, LogEventLevel level, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(LogTrack logTrack, string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, string messageTemplate, object[] args, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(LogTrack logTrack, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, object[] args, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(LogTrack @event, string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, string messageTemplate, object[] args, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, Exception exception, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(LogTrack @event, string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, string messageTemplate, object[] args,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, Exception exception, string messageTemplate,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(LogTrack @event, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(LogTrack @event, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(LogTrack @event, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(LogTrack @event, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(LogTrack @event, Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(LogTrack @event, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(LogTrack @event, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(LogTrack @event, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(LogTrack logTrack, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(LogTrack logTrack, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(LogTrack logTrack, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(LogTrack logTrack, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(LogTrack logTrack, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogVerbose(string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(string messageTemplate, object[] args, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(Exception exception, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(Exception exception, string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(Exception exception, string messageTemplate, object[] args, string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogVerbose(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(string messageTemplate, object[] args, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(Exception exception, string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(Exception exception, string messageTemplate, T arg, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogDebug(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(string messageTemplate, string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(string messageTemplate, T arg,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(string messageTemplate, object[] args,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(Exception exception, string messageTemplate,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(Exception exception, string messageTemplate, T arg,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogInformation(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        /// <inheritdoc />
        public void LogWarning(string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogWarning(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(Exception exception, string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(Exception exception, string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogError(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public void LogFatal(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        /// <inheritdoc />
        public LogEventLevel MinimumLevel { get; } = LogEventLevel.Off;


        /// <inheritdoc />
        public LogEventSendMode SendMode { get; } = LogEventSendMode.Customize;

        /// <inheritdoc />
        public bool IsEnabled(LogEventLevel level) => false;

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) => NoopDisposableObject.Instance;

        /// <inheritdoc />
        public void Write(LogTrack? logTrack, LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, ILogCallerInfo callerInfo,
            LogEventContext context = null, params object[] messageTemplateParameters) { }

        /// <inheritdoc />
        public void Write(LogEvent logEvent) { }

        /// <inheritdoc />
        public void Write(FutureLogEventDescriptor descriptor) { }

        /// <inheritdoc />
        public void SubmitLogger() { }

        /// <inheritdoc />
        public IFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) => null;

        /// <inheritdoc />
        public ISimpleLogger ToSimple() => NullSimpleLogger.Instance;
    }
}