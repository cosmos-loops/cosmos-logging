using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Extensions for global options 
    /// </summary>
    public static class GlobalOptionsExtensions {
        /// <summary>
        /// To global
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingsAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection ToGlobal(this ILogServiceCollection services, Action<LoggingOptions> settingsAct) {
            var settings = new LoggingOptions();
            settingsAct?.Invoke(settings);
            return ToGlobal(services, settings);
        }

        /// <summary>
        /// To global
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingsAct"></param>
        /// <typeparam name="TLoggingSettings"></typeparam>
        /// <returns></returns>
        public static ILogServiceCollection ToGlobal<TLoggingSettings>(this ILogServiceCollection services, Action<TLoggingSettings> settingsAct)
            where TLoggingSettings : LoggingOptions, new() {
            var settings = new TLoggingSettings();
            settingsAct?.Invoke(settings);
            return ToGlobal(services, settings);
        }

        /// <summary>
        /// To global
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <typeparam name="TLoggingSettings"></typeparam>
        /// <returns></returns>
        public static ILogServiceCollection ToGlobal<TLoggingSettings>(this ILogServiceCollection services, TLoggingSettings settings)
            where TLoggingSettings : LoggingOptions, new() {
            if (services is StandardLogServiceCollection collection) {
                collection.ReplaceSettings(settings);
            }

            return services;
        }
    }
}