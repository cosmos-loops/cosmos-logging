using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Settings;
using Cosmos.Logging.Sinks.Exceptionless.Core;
using Exceptionless;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public static class ExceptionlessSinkExtensions {
        public static ILogServiceCollection WriteToExceptionless(this ILogServiceCollection services) {
            return services.WriteToExceptionless((Action<ExceptionlessSinkSettings>) null);
        }

        public static ILogServiceCollection WriteToExceptionless(this ILogServiceCollection services, Action<ExceptionlessSinkSettings> settingAct) {
            var settings = new ExceptionlessSinkSettings();
            settingAct?.Invoke(settings);
            return services.WriteToExceptionless(settings);
        }

        public static ILogServiceCollection WriteToExceptionless(this ILogServiceCollection services, ExceptionlessSinkSettings settings) {
            return services.WriteToExceptionless(Options.Create(settings));
        }

        public static ILogServiceCollection WriteToExceptionless(this ILogServiceCollection services, IOptions<ExceptionlessSinkSettings> settings) {
            services.AddSinkSettings(settings.Value);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, ExceptionlessPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, ExceptionlessPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            if (!string.IsNullOrWhiteSpace(settings.Value.OriginConfigFilePath)) {
                services.ModifyConfigurationBuilder(b => b.AddFile(settings.Value.OriginConfigFilePath, settings.Value.OriginConfigFileType));
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Configuration.ReadFromConfiguration(root));
            }

            if (!string.IsNullOrWhiteSpace(settings.Value.ApiKey)) {
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Startup(settings.Value.ApiKey));
            } else {
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Startup());
            }

            return services;
        }
    }
}