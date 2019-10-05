using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TomatoLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class TomatoLogSinkExtensions
    {
        public static ILogServiceCollection AddTomatoLog(this ILogServiceCollection services, Action<TomatoLogSinkOptions> settingAct = null,
            Action<IConfiguration, TomatoLogSinkConfiguration> configAct = null)
        {
            var settings = new TomatoLogSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddTomatoLog(settings, configAct);
        }

        public static ILogServiceCollection AddTomatoLog(this ILogServiceCollection services, TomatoLogSinkOptions sinkOptions,
            Action<IConfiguration, TomatoLogSinkConfiguration> configAct = null)
        {
            return services.AddTomatoLog(Options.Create(sinkOptions), configAct);
        }

        public static ILogServiceCollection AddTomatoLog(this ILogServiceCollection services, IOptions<TomatoLogSinkOptions> settings,
            Action<IConfiguration, TomatoLogSinkConfiguration> configAct = null)
        {
            services.AddSinkSettings<TomatoLogSinkOptions, TomatoLogSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s =>
            {
                s.AddScoped<ILogPayloadClient, TomatoLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, TomatoLogPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });
            
            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes()
        {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<TomatoLogSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}