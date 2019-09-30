using System;
using System.Linq;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TencentCloudCls;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class TencentCloudClsSinkExtensions
    {
        public static ILogServiceCollection AddTencentCloudCls(this ILogServiceCollection services, Action<TencentCloudClsSinkOptions> settingAct = null,
            Action<IConfiguration, TencentCloudClsSinkConfiguration> configAct = null)
        {
            var settings = new TencentCloudClsSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddTencentCloudCls(settings, configAct);
        }

        public static ILogServiceCollection AddTencentCloudCls(this ILogServiceCollection services, TencentCloudClsSinkOptions sinkOptions,
            Action<IConfiguration, TencentCloudClsSinkConfiguration> configAct = null)
        {
            return services.AddTencentCloudCls(Options.Create(sinkOptions), configAct);
        }

        public static ILogServiceCollection AddTencentCloudCls(this ILogServiceCollection services, IOptions<TencentCloudClsSinkOptions> settings,
            Action<IConfiguration, TencentCloudClsSinkConfiguration> configAct = null)
        {
            services.AddSinkSettings<TencentCloudClsSinkOptions, TencentCloudClsSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s =>
            {
                s.AddScoped<ILogPayloadClient, TencentCloudClsPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, TencentCloudClsPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes()
        {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<TencentCloudClsSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}