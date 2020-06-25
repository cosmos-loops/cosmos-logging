using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.SampleLogSink;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for sample log sink
    /// </summary>
    public static class SampleLogSinkExtensions {
        /// <summary>
        /// Add sample log
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddSampleLog(this ILogServiceCollection services, Action<SampleOptions> settingAct = null,
            Action<IConfiguration, SampleLogConfiguration> config = null) {
            var options = new SampleOptions();
            settingAct?.Invoke(options);
            return services.AddSampleLog(Options.Create(options), config);
        }

        /// <summary>
        /// Add sample log
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddSampleLog(this ILogServiceCollection services, IOptions<SampleOptions> settings,
            Action<IConfiguration, SampleLogConfiguration> config = null) {
            services.AddSinkSettings<SampleOptions, SampleLogConfiguration>(settings.Value, (conf, sink) => config?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, SampleLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, SampleLogPayloadClientProvider>();
                s.TryAddSingleton(settings);
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<SampleOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}