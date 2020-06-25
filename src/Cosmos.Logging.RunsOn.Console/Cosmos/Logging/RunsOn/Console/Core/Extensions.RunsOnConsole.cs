using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.RunsOn.Console.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for log service collection
    /// </summary>
    public static class LogServiceCollectionExtensions {
        /// <summary>
        /// Runs on console
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ILogServiceCollection RunsOnConsole(this ILogServiceCollection services) {
            return services.RegisterToRunsOnConsole();
        }

        /// <summary>
        /// Runs on console
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingsConfigure"></param>
        /// <returns></returns>
        public static ILogServiceCollection RunsOnConsole(this ILogServiceCollection services, Action<LoggingOptions> settingsConfigure) {
            if (services.ExposeLogSettings() is LoggingOptions settings) {
                settingsConfigure?.Invoke(settings);
            }

            return services.RegisterToRunsOnConsole();
        }

        /// <summary>
        /// Runs on console
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <typeparam name="TLoggingSettings"></typeparam>
        /// <returns></returns>
        public static ILogServiceCollection RunsOnConsole<TLoggingSettings>(this ILogServiceCollection services, TLoggingSettings settings)
            where TLoggingSettings : LoggingOptions, new() {
            if (services is ConsoleLogServiceCollection loggingServices) {
                loggingServices.ReplaceSettings(settings);
            }

            return services.RegisterToRunsOnConsole();
        }

        private static ILogServiceCollection RegisterToRunsOnConsole(this ILogServiceCollection services) {
            services.AddDependency(s => s.AddSingleton<ILoggingServiceProvider, ConsoleLoggingServiceProvider>());
            services.AddDependency(s => s.AddSingleton<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>());
            return services;
        }
    }
}