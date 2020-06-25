using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TencentCloudCls;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Tencent Cloud CLS sink
    /// </summary>
    public static class TencentCloudClsSinkExtensions {
        /// <summary>
        /// Add Tencent Cloud CLS support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddTencentCloudCls(this ILogServiceCollection services, Action<TencentCloudClsSinkOptions> settingAct = null,
            Action<IConfiguration, TencentCloudClsSinkConfiguration> configAct = null) {
            var settings = new TencentCloudClsSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddTencentCloudCls(settings, configAct);
        }

        /// <summary>
        /// Add Tencent Cloud CLS support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sinkOptions"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddTencentCloudCls(this ILogServiceCollection services, TencentCloudClsSinkOptions sinkOptions,
            Action<IConfiguration, TencentCloudClsSinkConfiguration> configAct = null) {
            return services.AddTencentCloudCls(Options.Create(sinkOptions), configAct);
        }

        /// <summary>
        /// Add Tencent Cloud CLS support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddTencentCloudCls(this ILogServiceCollection services, IOptions<TencentCloudClsSinkOptions> settings,
            Action<IConfiguration, TencentCloudClsSinkConfiguration> configAct = null) {
            services.AddSinkSettings(settings.Value, configAct);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, TencentCloudClsPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, TencentCloudClsPayloadClientProvider>();
                s.TryAddSingleton(settings);
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<TencentCloudClsSinkOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}