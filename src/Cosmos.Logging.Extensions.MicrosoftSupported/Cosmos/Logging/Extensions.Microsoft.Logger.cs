using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Extensions.MicrosoftSupported;
using IILogger = Microsoft.Extensions.Logging.ILogger;

// ReSharper disable ExplicitCallerInfoArgument
// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Microsoft logger wrapper
    /// </summary>
    public static class MicrosoftLoggerWrapperExtensions {
        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        /// <summary>
        /// 
        /// </summary>Log verbose
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogVerbose<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogVerbose<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogVerbose<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogVerbose<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogVerbose<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogVerbose<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogVerbose<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogVerbose<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogVerbose<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogVerbose<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogVerbose<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogVerbose<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogDebug<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogDebug<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogDebug<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogDebug<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogDebug<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogDebug<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogDebug<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogDebug<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogDebug<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogDebug<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogDebug<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogDebug<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log bugs
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogInformation<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogInformation<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogInformation<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogInformation<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogInformation<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogInformation<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(messageTemplate, args, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogInformation<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogInformation<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void LogInformation<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogInformation<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogInformation<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogInformation<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, args, contextAct, memberName);
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogWarning<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogWarning<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogWarning<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogWarning<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogWarning<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogWarning<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogWarning<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogWarning<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogWarning<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogWarning<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogWarning<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogWarning<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogError<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogError<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogError<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogError<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogError<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogError<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogError<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogError<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogError<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogError<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogError<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogError<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogError(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogError(exception, messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogFatal<T>(this IILogger logger, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogFatal<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogFatal<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogFatal<T>(this IILogger logger, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogFatal<T1, T2>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogFatal<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogFatal<T>(this IILogger logger, Exception exception, string messageTemplate, T arg,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void LogFatal<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogFatal<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, arg3, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate, object[] args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, args, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="arg"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        public static void LogFatal<T>(this IILogger logger, Exception exception, string messageTemplate, T arg, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogFatal<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
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
        public static void LogFatal<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 arg1, T2 arg2, T3 arg3, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, arg1, arg2, arg3, contextAct, memberName, filePath, lineNumber);
            }
        }

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        /// <param name="contextAct"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate, object[] args, Action<LogEventContext> contextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerAdapter l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, args, contextAct, memberName, filePath, lineNumber);
            }
        }
    }
}