using System;
using System.Linq;
using System.Reflection;
using Cosmos.Logging.Configurations;
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

            RegisterOriginalConfig(services, settings.Value.OriginConfigFilePath, settings.Value.OriginConfigFileType);

            RegisterApiKey(services, settings.Value.ApiKey);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterOriginalConfig(ILogServiceCollection services, string path, FileTypes fileType) {
            if (!string.IsNullOrWhiteSpace(path)) {
                services.ModifyConfigurationBuilder(b => ConfigLoadingContext.Load(b, path, fileType));
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Configuration.ReadFromConfiguration(root));
            }
            else if (services.BeGivenConfigurationBuilder || services.BeGivenConfigurationRoot) {
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Configuration.ReadFromConfiguration(root));
            }
        }

        private static void RegisterApiKey(ILogServiceCollection services, string apiKey) {
            if (!string.IsNullOrWhiteSpace(apiKey))
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Startup(apiKey));
            else
                services.AddOriginConfigAction(root => ExceptionlessClient.Default.Startup());
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<ExceptionlessSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}