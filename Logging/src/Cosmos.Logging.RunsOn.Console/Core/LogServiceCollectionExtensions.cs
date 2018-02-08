using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.RunsOn.Console.Core;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class LogServiceCollectionExtensions {
        public static ILogServiceCollection RunsOnConsole(this ILogServiceCollection services) {
            return services.RegisterToRunsOnConsole();
        }

        public static ILogServiceCollection RunsOnConsole(this ILogServiceCollection services, Action<LoggingOptions> settingsAction) {
            if (services.ExposeLogSettings() is LoggingOptions settings) {
                settingsAction?.Invoke(settings);
            }

            return services.RegisterToRunsOnConsole();
        }

        public static ILogServiceCollection RunsOnConsole<TLoggingSettings>(this ILogServiceCollection services, TLoggingSettings settings)
            where TLoggingSettings : LoggingOptions, new() {
            if (services is ConsoleLogServiceCollection collection) {
                collection.ReplaceSettings(settings);
            }

            return services.RegisterToRunsOnConsole();
        }

        public static void AllDone(this ILogServiceCollection services) {
            InternalDependencyContainer.AllDone(services);
            LOGGER._initialized = true;
        }

        private static ILogServiceCollection RegisterToRunsOnConsole(this ILogServiceCollection services) {
            return services.AddDependency(s => s.AddSingleton<ILoggingServiceProvider, ConsoleLoggingServiceProvider>());
        }
    }
}