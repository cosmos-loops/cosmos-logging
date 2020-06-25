using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.Exceptionless;
using Cosmos.Logging.Sinks.Exceptionless.Internals;
using Exceptionless;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for exceptionless sink
    /// </summary>
    public static class ExceptionlessSinkExtensions {
        /// <summary>
        /// Add exceptionless support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, Action<ExceptionlessSinkOptions> settingAct = null,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            var settings = new ExceptionlessSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddExceptionless(settings, configAct);
        }

        /// <summary>
        /// Add exceptionless support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sinkOptions"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, ExceptionlessSinkOptions sinkOptions,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            return services.AddExceptionless(Options.Create(sinkOptions), configAct);
        }

        /// <summary>
        /// Add exceptionless support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddExceptionless(this ILogServiceCollection services, IOptions<ExceptionlessSinkOptions> settings,
            Action<IConfiguration, ExceptionlessSinkConfiguration> configAct = null) {
            services.AddSinkSettings(settings.Value, configAct);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, ExceptionlessPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, ExceptionlessPayloadClientProvider>();
                s.TryAddSingleton(settings);
            });

            RegisterOriginalConfig(services, settings.Value.OriginalConfigFilePath, settings.Value.OriginalConfigFileType);

            RegisterApiKey(services, settings.Value.ApiKey);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterOriginalConfig(ILogServiceCollection services, string path, FileTypes fileType) {
            if (!string.IsNullOrWhiteSpace(path)) {
                services.ModifyConfigurationBuilder(b => ConfigLoadingContext.Load(b, path, fileType));
                services.AddOriginalConfigAction(root => ExceptionlessClient.Default.Configuration.ReadFromConfiguration(root));
            }
            else if (services.BeGivenConfigurationBuilder || services.BeGivenConfigurationRoot) {
                services.AddOriginalConfigAction(root => ExceptionlessClient.Default.Configuration.ReadFromConfiguration(root));
            }
        }

        private static void RegisterApiKey(ILogServiceCollection services, string apiKey) {
            if (!string.IsNullOrWhiteSpace(apiKey))
                services.AddOriginalConfigAction(root => ExceptionlessClient.Default.Startup(apiKey));
            else
                services.AddOriginalConfigAction(root => ExceptionlessClient.Default.Startup());
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<ExceptionlessSinkOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}