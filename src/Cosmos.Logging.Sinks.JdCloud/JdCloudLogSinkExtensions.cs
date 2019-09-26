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

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class JdCloudLogSinkExtensions
    {
        public static ILogServiceCollection AddJdCloudLogService(this ILogServiceCollection services, Action<JdCloudLogSinkOptions> settingAct = null,
            Action<IConfiguration, JdCloudLogSinkConfiguration> configAct = null)
        {
            var settings = new JdCloudLogSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddJdCloudLogService(settings, configAct);
        }

        public static ILogServiceCollection AddJdCloudLogService(this ILogServiceCollection services, JdCloudLogSinkOptions sinkOptions,
            Action<IConfiguration, JdCloudLogSinkConfiguration> configAct = null)
        {
            return services.AddJdCloudLogService(Options.Create(sinkOptions), configAct);
        }

        public static ILogServiceCollection AddJdCloudLogService(this ILogServiceCollection services, IOptions<JdCloudLogSinkOptions> settings,
            Action<IConfiguration, JdCloudLogSinkConfiguration> configAct = null)
        {
            services.AddSinkSettings<JdCloudLogSinkOptions, JdCloudLogSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s =>
            {
                s.AddScoped<ILogPayloadClient, JdCloudLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, JdCloudLogPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterJdCloudLogClients(settings.Value);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterJdCloudLogClients(JdCloudLogSinkOptions options)
        {
            if (!options.HasLegalNativeConfig(false))
                throw new InvalidOperationException("There is no legal JD Cloud Log Service native config.");

            if (options.JdCloudLogNativeConfigs.Any())
                foreach (var kvp in options.JdCloudLogNativeConfigs)
                    JdCloudLogClientManager.SetLogClient(kvp.Key, kvp.Value);
            else
                JdCloudLogClientManager.SetLogClient(Constants.DefaultClient,
                    options.LogStreamName, options.AccessKey, options.SecretKey, options.Security, options.RequestTimeout,
                    true);
        }

        private static void RegisterCoreComponentsTypes()
        {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<JdCloudLogSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}