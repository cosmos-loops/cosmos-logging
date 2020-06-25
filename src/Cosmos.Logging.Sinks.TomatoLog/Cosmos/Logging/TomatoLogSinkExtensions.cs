using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TomatoLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for TomatoLog sink
    /// </summary>
    public static class TomatoLogSinkExtensions {
        /// <summary>
        /// Add TomatoLog for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddTomatoLog(this ILogServiceCollection services, Action<TomatoLogSinkOptions> settingAct = null,
            Action<IConfiguration, TomatoLogSinkConfiguration> configAct = null) {
            var settings = new TomatoLogSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddTomatoLog(settings, configAct);
        }

        /// <summary>
        /// Add TomatoLog for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sinkOptions"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddTomatoLog(this ILogServiceCollection services, TomatoLogSinkOptions sinkOptions,
            Action<IConfiguration, TomatoLogSinkConfiguration> configAct = null) {
            return services.AddTomatoLog(Options.Create(sinkOptions), configAct);
        }

        /// <summary>
        /// Add TomatoLog for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddTomatoLog(this ILogServiceCollection services, IOptions<TomatoLogSinkOptions> settings,
            Action<IConfiguration, TomatoLogSinkConfiguration> configAct = null) {
            services.AddSinkSettings<TomatoLogSinkOptions, TomatoLogSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, TomatoLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, TomatoLogPayloadClientProvider>();
                s.TryAddSingleton(settings);
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<TomatoLogSinkOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}