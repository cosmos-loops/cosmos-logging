using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging {
    public class NullLogger : ILogger {
        private readonly static NullLogger NullLoggerCache;

        static NullLogger() {
            NullLoggerCache = new NullLogger();
        }

        public static NullLogger Instance => NullLoggerCache;

        public string Name { get; }

        public void LogVerbose(LogEventId eventId, string messageTemplate, string memberName = null) { }

        public void LogVerbose<T>(LogEventId eventId, string messageTemplate, T arg, string memberName = null) { }

        public void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        public void LogVerbose(LogEventId eventId, string messageTemplate, object[] args, string memberName = null) { }

        public void LogVerbose(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogVerbose<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, 
            string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct, 
            string memberName = null) { }

        public void LogVerbose(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, string memberName = null) { }

        public void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, string memberName = null) { }

        public void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, 
            string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, 
            string memberName = null) { }

        public void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, object[] args, string memberName = null) { }

        public void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(LogEventId eventId, string messageTemplate, string memberName = null) { }

        public void LogDebug<T>(LogEventId eventId, string messageTemplate, T arg, string memberName = null) { }

        public void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        public void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        public void LogDebug(LogEventId eventId, string messageTemplate, object[] args, string memberName = null) { }

        public void LogDebug(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogDebug<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogDebug<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, string memberName = null) { }

        public void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            string memberName = null) { }

        public void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        public void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        public void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct, 
            string memberName = null) { }

        public void LogDebug<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogInformation(LogEventId eventId, string messageTemplate, string memberName = null) { }

        public void LogInformation<T>(LogEventId eventId, string messageTemplate, T arg, string memberName = null) { }

        public void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, 
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, string messageTemplate, object[] args, 
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct, 
            string memberName = null) { }

        public void LogInformation<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogInformation<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, Exception exception, string messageTemplate,
            string memberName = null) { }

        public void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            string memberName = null) { }

        public void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, object[] args, 
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct, 
            string memberName = null) { }

        public void LogInformation<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogWarning(LogEventId eventId, string messageTemplate, 
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(LogEventId eventId, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, 
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null,string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null,string filePath = null,int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct, 
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, 
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, 
            string memberName = null,string filePath = null,int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null,string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null,string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null,string filePath = null, int lineNumber = 0) { }

        public void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null,string filePath = null,int lineNumber = 0) { }

        public void LogError(LogEventId eventId, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(LogEventId eventId, string messageTemplate, T arg, 
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, 
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, 
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogError(LogEventId eventId, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct, 
            string memberName = null, string filePath = null,int lineNumber = 0) { }

        public void LogError<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(LogEventId eventId, Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(LogEventId eventId, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(LogEventId eventId, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(LogEventId eventId, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(LogEventId eventId, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(LogEventId eventId, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogVerbose(string messageTemplate, string memberName = null) { }

        public void LogVerbose<T>(string messageTemplate, T arg, string memberName = null) { }

        public void LogVerbose<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        public void LogVerbose(string messageTemplate, object[] args, string memberName = null) { }

        public void LogVerbose(string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogVerbose<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogVerbose<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogVerbose(string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogVerbose(Exception exception, string messageTemplate, string memberName = null) { }

        public void LogVerbose<T>(Exception exception, string messageTemplate, T arg, string memberName = null) { }

        public void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogVerbose(Exception exception, string messageTemplate, object[] args, string memberName = null) { }

        public void LogVerbose(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogVerbose(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(string messageTemplate, string memberName = null) { }

        public void LogDebug<T>(string messageTemplate, T arg, string memberName = null) { }

        public void LogDebug<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        public void LogDebug<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null) { }

        public void LogDebug(string messageTemplate, object[] args, string memberName = null) { }

        public void LogDebug(string messageTemplate, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogDebug<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(string messageTemplate, object[] args, Action<LogEventContext> contextAct, string memberName = null) { }

        public void LogDebug(Exception exception, string messageTemplate, string memberName = null) { }

        public void LogDebug<T>(Exception exception, string messageTemplate, T arg, string memberName = null) { }

        public void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null) { }

        public void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogDebug(Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        public void LogDebug(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogDebug(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(string messageTemplate, string memberName = null) { }

        public void LogInformation<T>(string messageTemplate, T arg,
            string memberName = null) { }

        public void LogInformation<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogInformation(string messageTemplate, object[] args,
            string memberName = null) { }

        public void LogInformation(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(Exception exception, string messageTemplate,
            string memberName = null) { }

        public void LogInformation<T>(Exception exception, string messageTemplate, T arg,
            string memberName = null) { }

        public void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null) { }

        public void LogInformation(Exception exception, string messageTemplate, object[] args,
            string memberName = null) { }

        public void LogInformation(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogInformation(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null) { }

        public void LogWarning(string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogWarning(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(Exception exception, string messageTemplate, string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(Exception exception, string messageTemplate, T arg, string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, string memberName = null, string filePath = null,
            int lineNumber = 0) { }

        public void LogError(Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogError(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(Exception exception, string messageTemplate,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(Exception exception, string messageTemplate, T arg,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(Exception exception, string messageTemplate, object[] args,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T>(Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public void LogFatal(Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            string memberName = null, string filePath = null, int lineNumber = 0) { }

        public LogEventLevel MinimumLevel { get; }
        public LogEventSendMode SendMode { get; }
        public bool IsEnabled(LogEventLevel level) => false;

        public IDisposable BeginScope<TState>(TState state) => null;

        public void Write(LogEventId? eventId, LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, ILogCallerInfo callerInfo,
            LogEventContext context = null, params object[] messageTemplateParameters) { }

        public void Write(LogEvent logEvent) { }

        public void Write(FutureLogEventDescriptor descriptor) { }

        public void SubmitLogger() { }

        public IFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) => null;

    }
}