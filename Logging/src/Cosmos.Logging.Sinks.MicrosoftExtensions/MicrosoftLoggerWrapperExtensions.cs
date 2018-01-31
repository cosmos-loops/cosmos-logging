using System;
using Cosmos.Logging.Sinks.MicrosoftExtensions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class MicrosoftLoggerWrapperExtensions {
        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogVerbose<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogVerbose<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogVerbose<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogVerbose<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogVerbose<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogVerbose<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T1 paramObject1,
            T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogVerbose<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogVerbose<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogVerbose<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogVerbose(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogDebug<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogDebug<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogDebug<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogDebug<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogDebug<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogDebug<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogDebug<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogDebug<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T1 paramObject1,
            T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogDebug<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogDebug<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogDebug<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogDebug<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogDebug(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogInformation<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogInformation<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogInformation<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogInformation<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogInformation<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogInformation<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogInformation<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogInformation<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T1 paramObject1,
            T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogInformation<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogInformation<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogInformation<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogInformation<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogInformation(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogWarning<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogWarning<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogWarning<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogWarning<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogWarning<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogWarning<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogWarning<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogWarning<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T1 paramObject1,
            T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogWarning<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogWarning<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogWarning<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogWarning<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogWarning(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogError<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogError<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogError<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogError<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogError<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogError<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogError<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogError<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T1 paramObject1,
            T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogError<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogError<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogError<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogError<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogError(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogFatal<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogFatal<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogFatal<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T1 paramObject1, T2 paramObject2,
            T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogFatal<T>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogFatal<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogFatal<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct,
            params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogFatal<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogFatal<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T1 paramObject1,
            T2 paramObject2) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogFatal<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogFatal<T>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogFatal<T1, T2>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogFatal<T1, T2, T3>(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogFatal(this Microsoft.Extensions.Logging.ILogger logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is MicrosoftLoggerWrapper l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }
    }
}