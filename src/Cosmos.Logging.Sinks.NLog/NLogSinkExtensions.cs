using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.NLog {
    public static class NLogSinkExtensions {
        public static ILogServiceCollection AddNLog(this ILogServiceCollection services, Action<NLogSinkOptions> settingAct = null,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            var settings = new NLogSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddNLog(settings, configAction);
        }

        public static ILogServiceCollection AddNLog(this ILogServiceCollection services, NLogSinkOptions options,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            return services.AddNLog(Options.Create(options), configAction);
        }

        public static ILogServiceCollection AddNLog(this ILogServiceCollection services, IOptions<NLogSinkOptions> settings,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {

            RegisterConfiguration(services, settings, configAction);

            RegisterCoreComponents(services, settings);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterConfiguration(ILogServiceCollection services, IOptions<NLogSinkOptions> settings,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            services.AddSinkSettings<NLogSinkOptions, NLogSinkConfiguration>(settings.Value, (conf, sink) => configAction?.Invoke(conf, sink));
        }

        private static void RegisterCoreComponents(ILogServiceCollection services, IOptions<NLogSinkOptions> settings) {
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, NLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, NLogPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<NLogSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}