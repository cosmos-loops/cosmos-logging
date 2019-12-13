using System;
using System.Linq;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.JdCloud;
using Cosmos.Logging.Sinks.JdCloud.Internals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for JdCloud log sink
    /// </summary>
    public static class JdCloudLogSinkExtensions {
        /// <summary>
        /// Add JdCloud Log service support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddJdCloudLogService(this ILogServiceCollection services, Action<JdCloudLogSinkOptions> settingAct = null,
            Action<IConfiguration, JdCloudLogSinkConfiguration> configAct = null) {
            var settings = new JdCloudLogSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddJdCloudLogService(settings, configAct);
        }

        /// <summary>
        /// Add JdCloud Log service support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sinkOptions"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddJdCloudLogService(this ILogServiceCollection services, JdCloudLogSinkOptions sinkOptions,
            Action<IConfiguration, JdCloudLogSinkConfiguration> configAct = null) {
            return services.AddJdCloudLogService(Options.Create(sinkOptions), configAct);
        }

        /// <summary>
        /// Add JdCloud Log service support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddJdCloudLogService(this ILogServiceCollection services, IOptions<JdCloudLogSinkOptions> settings,
            Action<IConfiguration, JdCloudLogSinkConfiguration> configAct = null) {
            services.AddSinkSettings(settings.Value, configAct);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, JdCloudLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, JdCloudLogPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<JdCloudLogSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}