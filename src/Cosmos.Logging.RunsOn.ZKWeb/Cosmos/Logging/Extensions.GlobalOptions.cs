using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.ZKWeb.Core;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for global options
    /// </summary>
    public static class GlobalOptionsExtensions {
        /// <summary>
        /// To global
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingsConfigure"></param>
        /// <returns></returns>
        public static ILogServiceCollection ToGlobal(this ILogServiceCollection services, Action<LoggingOptions> settingsConfigure) {
            var settings = new LoggingOptions();
            settingsConfigure?.Invoke(settings);
            return ToGlobal(services, settings);
        }

        /// <summary>
        /// To global
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingsConfigure"></param>
        /// <typeparam name="TLoggingSettings"></typeparam>
        /// <returns></returns>
        public static ILogServiceCollection ToGlobal<TLoggingSettings>(this ILogServiceCollection services, Action<TLoggingSettings> settingsConfigure)
            where TLoggingSettings : LoggingOptions, new() {
            var settings = new TLoggingSettings();
            settingsConfigure?.Invoke(settings);
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
            if (services is ZkWebLogServiceCollection loggingServices) {
                loggingServices.ReplaceSettings(settings);
            }

            return services;
        }
    }
}