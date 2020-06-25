using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.NLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for NLog sink
    /// </summary>
    public static class NLogSinkExtensions {
        /// <summary>
        /// Add NLog support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddNLog(this ILogServiceCollection services, Action<NLogSinkOptions> settingAct = null,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            var settings = new NLogSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddNLog(settings, configAction);
        }

        /// <summary>
        /// Add NLog support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddNLog(this ILogServiceCollection services, NLogSinkOptions options,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            return services.AddNLog(Options.Create(options), configAction);
        }

        /// <summary>
        /// Add NLog support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddNLog(this ILogServiceCollection services, IOptions<NLogSinkOptions> settings,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {

            RegisterConfiguration(services, settings, configAction);

            RegisterCoreComponents(services, settings);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterConfiguration(ILogServiceCollection services, IOptions<NLogSinkOptions> settings,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            services.AddSinkSettings(settings.Value, configAction);
        }

        private static void RegisterCoreComponents(ILogServiceCollection services, IOptions<NLogSinkOptions> settings) {
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, NLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, NLogPayloadClientProvider>();
                s.TryAddSingleton(settings);
            });
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<NLogSinkOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}