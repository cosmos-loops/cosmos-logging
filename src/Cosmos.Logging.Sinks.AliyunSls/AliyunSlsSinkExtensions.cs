using System;
using System.Linq;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.AliyunSls;
using Cosmos.Logging.Sinks.AliyunSls.Internals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class AliyunSlsSinkExtensions
    {
        public static ILogServiceCollection AddAliyunSls(this ILogServiceCollection services, Action<AliyunSlsSinkOptions> settingAct = null,
            Action<IConfiguration, AliyunSlsSinkConfiguration> configAct = null)
        {
            var settings = new AliyunSlsSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddAliyunSls(settings, configAct);
        }

        public static ILogServiceCollection AddAliyunSls(this ILogServiceCollection services, AliyunSlsSinkOptions sinkOptions,
            Action<IConfiguration, AliyunSlsSinkConfiguration> configAct = null)
        {
            return services.AddAliyunSls(Options.Create(sinkOptions), configAct);
        }

        public static ILogServiceCollection AddAliyunSls(this ILogServiceCollection services, IOptions<AliyunSlsSinkOptions> settings,
            Action<IConfiguration, AliyunSlsSinkConfiguration> configAct = null)
        {
            services.AddSinkSettings<AliyunSlsSinkOptions, AliyunSlsSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s =>
            {
                s.AddScoped<ILogPayloadClient, AliyunSlsPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, AliyunSlsPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterAliyunSlsClients(settings.Value);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterAliyunSlsClients(AliyunSlsSinkOptions options)
        {
            if (!options.HasLegalNativeConfig(false))
                throw new InvalidOperationException("There is no legal Alibaba Cloud (Aliyun) SLS native config.");

            if (options.AliyunSlsNativeConfigs.Any())
                foreach (var kvp in options.AliyunSlsNativeConfigs)
                    AliyunSlsClientManager.SetSlsClient(kvp.Key, kvp.Value);
            else
                AliyunSlsClientManager.SetSlsClient(Constants.DefaultClient,
                    options.LogStoreName, options.EndPoint, options.ProjectName, options.AccessKeyId, options.AccessKey,
                    true);
        }

        private static void RegisterCoreComponentsTypes()
        {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<AliyunSlsSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}