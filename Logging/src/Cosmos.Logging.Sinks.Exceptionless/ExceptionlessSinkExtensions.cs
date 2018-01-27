using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Sinks.Exceptionless.Core;
using Exceptionless;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public static class ExceptionlessSinkExtensions {
        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, Action<ExceptionlessOptions> settingAct = null,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            var settings = new ExceptionlessOptions();
            settingAct?.Invoke(settings);
            return services.AddExceptionless(settings, configAct);
        }

        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, ExceptionlessOptions options,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            return services.AddExceptionless(Options.Create(options), configAct);
        }

        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, IOptions<ExceptionlessOptions> settings,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            services.AddSinkSettings<ExceptionlessOptions, ExceptionlessSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
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