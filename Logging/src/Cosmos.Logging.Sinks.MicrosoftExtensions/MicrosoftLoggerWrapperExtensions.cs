using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Sinks.MicrosoftExtensions;
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

        public static void LogVerbose<T>(this IILogger logger, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName, paramObjects);
            }
        }

        public static void LogVerbose(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, eventContextAct, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, eventContextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, eventContextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, eventContextAct, memberName, paramObjects);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName, paramObjects);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, eventContextAct, memberName);
            }
        }

        public static void LogVerbose<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, eventContextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, eventContextAct, memberName);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName);
            }
        }

        public static void LogVerbose(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, eventContextAct, memberName, paramObjects);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName, paramObjects);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, eventContextAct, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, eventContextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, eventContextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, eventContextAct, memberName, paramObjects);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName, paramObjects);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, eventContextAct, memberName);
            }
        }

        public static void LogDebug<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, eventContextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, eventContextAct, memberName);
            }
        }

        public static void LogDebug<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName);
            }
        }

        public static void LogDebug(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, eventContextAct, memberName, paramObjects);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, memberName, paramObjects);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, eventContextAct, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, eventContextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, eventContextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, eventContextAct, memberName, paramObjects);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, memberName, paramObjects);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, eventContextAct, memberName);
            }
        }

        public static void LogInformation<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, eventContextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, eventContextAct, memberName);
            }
        }

        public static void LogInformation<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName);
            }
        }

        public static void LogInformation(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, eventContextAct, memberName, paramObjects);
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

        public static void LogWarning<T>(this IILogger logger, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, paramObject, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, paramObject1, paramObject2, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, paramObject1, paramObject2, paramObject3, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, memberName, filePath, lineNumber, paramObjects);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T>(this IILogger logger, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, paramObject, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, paramObject1, paramObject2, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(messageTemplate, eventContextAct, memberName, filePath, lineNumber, paramObjects);
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

        public static void LogWarning<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, paramObject, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, paramObject1, paramObject2, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, paramObject1, paramObject2, paramObject3, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, memberName, filePath, lineNumber, paramObjects);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, paramObject, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, paramObject1, paramObject2, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogWarning(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogWarning(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber, paramObjects);
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

        public static void LogError<T>(this IILogger logger, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, paramObject, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, paramObject1, paramObject2, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, paramObject1, paramObject2, paramObject3, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, memberName, filePath, lineNumber, paramObjects);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T>(this IILogger logger, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, paramObject, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, paramObject1, paramObject2, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(messageTemplate, eventContextAct, memberName, filePath, lineNumber, paramObjects);
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

        public static void LogError<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, paramObject, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, paramObject1, paramObject2, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, paramObject1, paramObject2, paramObject3, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, memberName, filePath, lineNumber, paramObjects);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, paramObject, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, paramObject1, paramObject2, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogError(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogError(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber, paramObjects);
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

        public static void LogFatal<T>(this IILogger logger, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, paramObject, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, paramObject1, paramObject2, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, paramObject1, paramObject2, paramObject3, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, memberName, filePath, lineNumber, paramObjects);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T>(this IILogger logger, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, paramObject, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, paramObject1, paramObject2, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(messageTemplate, eventContextAct, memberName, filePath, lineNumber, paramObjects);
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

        public static void LogFatal<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, paramObject, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, paramObject1, paramObject2, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, paramObject1, paramObject2, paramObject3, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, memberName, filePath, lineNumber, paramObjects);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T>(this IILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, paramObject, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, paramObject1, paramObject2, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal<T1, T2, T3>(this IILogger logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, paramObject1, paramObject2, paramObject3, eventContextAct, memberName, filePath, lineNumber);
            }
        }

        public static void LogFatal(this IILogger logger, Exception exception, string messageTemplate,
            Action<LogEventContext> eventContextAct,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogFatal(exception, messageTemplate, eventContextAct, memberName, filePath, lineNumber, paramObjects);
            }
        }
    }
}