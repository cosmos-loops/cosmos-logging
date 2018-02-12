using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Extensions.Microsoft;
using IILogger = Microsoft.Extensions.Logging.ILogger;

// ReSharper disable ExplicitCallerInfoArgument
// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class MicrosoftLoggerWrapperExtensions {
        public static void LogVerbose(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, contextAct, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, contextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, contextAct, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, contextAct, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, contextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, contextAct, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, contextAct, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, contextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, contextAct, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, contextAct, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, contextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, contextAct, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, contextAct, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, contextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, contextAct, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, contextAct, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, contextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, contextAct, memberName);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }
    }
}