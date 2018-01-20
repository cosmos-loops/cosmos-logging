using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Settings;
using Cosmos.Logging.Sinks.Exceptionless.Core;
using Exceptionless;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public static class ExceptionlessSinkExtensions {
        public static ILogServiceCollection UseExceptionless(this ILogServiceCollection services) {
            return services.UseExceptionless((Action<ExceptionlessSinkSettings>) null);
        }

        public static ILogServiceCollection UseExceptionless(this ILogServiceCollection services, Action<ExceptionlessSinkSettings> settingAct) {
            var settings = new ExceptionlessSinkSettings();
            settingAct?.Invoke(settings);
            return services.UseExceptionless(settings);
        }

        public static ILogServiceCollection UseExceptionless(this ILogServiceCollection services, ExceptionlessSinkSettings settings) {
            return services.UseExceptionless(Options.Create(settings));
        }

        public static ILogServiceCollection UseExceptionless(this ILogServiceCollection services, IOptions<ExceptionlessSinkSettings> settings) {
            services.AddSinkSettings(settings.Value);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, ExceptionlessPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, ExceptionlessPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            if (!string.IsNullOrWhiteSpace(settings.Value.OriginConfigFilePath)) {
                services.ModifyConfigurationBuilder(b => b.AddFile(settings.Value.OriginConfigFilePath, settings.Value.OriginConfigFileType));
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Configuration.ReadFromConfiguration(root));
            } else if (services.BeGivenConfigurationBuilder || services.BeGivenConfigurationRoot) {
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