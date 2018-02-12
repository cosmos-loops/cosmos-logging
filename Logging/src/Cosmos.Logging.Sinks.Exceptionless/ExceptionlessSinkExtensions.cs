using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.Exceptionless;
using Cosmos.Logging.Sinks.Exceptionless.Internals;
using Exceptionless;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class ExceptionlessSinkExtensions {
        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, Action<ExceptionlessSinkOptions> settingAct = null,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            var settings = new ExceptionlessSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddExceptionless(settings, configAct);
        }

        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, ExceptionlessSinkOptions sinkOptions,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            return services.AddExceptionless(Options.Create(sinkOptions), configAct);
        }

        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, IOptions<ExceptionlessSinkOptions> settings,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            services.AddSinkSettings<ExceptionlessSinkOptions, ExceptionlessSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, ExceptionlessPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, ExceptionlessPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
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

            RegisterCoreComponentsTypes();

            return services;
        }


        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<ExceptionlessSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}