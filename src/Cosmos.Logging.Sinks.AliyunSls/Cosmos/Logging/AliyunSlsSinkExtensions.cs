using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.AliyunSls;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Aliyun SLS
    /// </summary>
    public static class AliyunSlsSinkExtensions {
        /// <summary>
        /// Add Aliyun SLS support for Cosmos Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddAliyunSls(this ILogServiceCollection services, Action<AliyunSlsSinkOptions> settingAct = null,
            Action<IConfiguration, AliyunSlsSinkConfiguration> configAct = null) {
            var settings = new AliyunSlsSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddAliyunSls(settings, configAct);
        }

        /// <summary>
        /// Add Aliyun SLS support for Cosmos Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sinkOptions"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddAliyunSls(this ILogServiceCollection services, AliyunSlsSinkOptions sinkOptions,
            Action<IConfiguration, AliyunSlsSinkConfiguration> configAct = null) {
            return services.AddAliyunSls(Options.Create(sinkOptions), configAct);
        }

        /// <summary>
        /// Add Aliyun SLS support for Cosmos Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddAliyunSls(this ILogServiceCollection services, IOptions<AliyunSlsSinkOptions> settings,
            Action<IConfiguration, AliyunSlsSinkConfiguration> configAct = null) {
            services.AddSinkSettings(settings.Value, configAct);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, AliyunSlsPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, AliyunSlsPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<AliyunSlsSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}