using System;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public static class AspNetCoreLoggerOfTExtensions {
        public static void LogVerbose<TState>(this ILogger<TState> logger, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogVerbose<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogVerbose<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogVerbose<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogVerbose<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogVerbose<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogVerbose<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogVerbose<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogVerbose<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogVerbose<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogVerbose<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject,
            Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogVerbose<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogVerbose<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogVerbose<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogDebug<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogDebug<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogDebug<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogDebug<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogDebug<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogDebug<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogDebug<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogDebug<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogDebug<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogDebug<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogDebug<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogDebug<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogDebug<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogInformation<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogInformation<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogInformation<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogInformation<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogInformation<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogInformation<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogInformation<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogInformation<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogInformation<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogInformation<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogInformation<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogInformation<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogInformation<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogWarning<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogWarning<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogWarning<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogWarning<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogWarning<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogWarning<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogWarning<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogWarning<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogWarning<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogWarning<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogWarning<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogWarning<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogWarning<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogError<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogError<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogError<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogError<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogError<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogError<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogError<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogError<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogError<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogError<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogError<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogError<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogError<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate);
            }
        }

        public static void LogFatal<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject);
            }
        }

        public static void LogFatal<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogFatal<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObjects);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogFatal<TState, T>(this ILogger<TState> logger, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogFatal<TState, T1, T2>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogFatal<TState, T1, T2, T3>(this ILogger<TState> logger, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(messageTemplate, optCtxAct);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate);
            }
        }

        public static void LogFatal<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject);
            }
        }

        public static void LogFatal<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2);
            }
        }

        public static void LogFatal<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObjects);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct);
            }
        }

        public static void LogFatal<TState, T>(this ILogger<TState> logger, Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject, optCtxAct);
            }
        }

        public static void LogFatal<TState, T1, T2>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, optCtxAct);
            }
        }

        public static void LogFatal<TState, T1, T2, T3>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, paramObject1, paramObject2, paramObject3, optCtxAct);
            }
        }

        public static void LogFatal<TState>(this ILogger<TState> logger, Exception exception, string messageTemplate,
            Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            if (logger is AspNetCoreLoggerOfT<TState> l) {
                l.ExposeLogger().LogVerbose(exception, messageTemplate, optCtxAct, paramObjects);
            }
        }
    }
}