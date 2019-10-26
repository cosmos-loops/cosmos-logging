using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class ConsoleSinkExtensions
    {
        public static ILogServiceCollection AddConsole(this ILogServiceCollection services, Action<ConsoleSinkOptions> settingAct = null,
            Action<IConfiguration, ConsoleSinkConfiguration> configAction = null) {
            var settings = new ConsoleSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddConsole(settings, configAction);
        }
        
        public static ILogServiceCollection AddConsole(this ILogServiceCollection services, ConsoleSinkOptions options,
            Action<IConfiguration, ConsoleSinkConfiguration> configAction = null) {
            return services.AddConsole(Options.Create(options), configAction);
        }

        public static ILogServiceCollection AddConsole(this ILogServiceCollection services, IOptions<ConsoleSinkOptions> settings,
            Action<IConfiguration, ConsoleSinkConfiguration> configAction = null) {

            RegisterConfiguration(services, settings, configAction);

            RegisterCoreComponents(services, settings);

            RegisterCoreComponentsTypes();

            return services;
        }
        
        private static void RegisterConfiguration(ILogServiceCollection services, IOptions<ConsoleSinkOptions> settings,
            Action<IConfiguration, ConsoleSinkConfiguration> configAction = null) {
            services.AddSinkSettings<ConsoleSinkOptions, ConsoleSinkConfiguration>(settings.Value, (conf, sink) => configAction?.Invoke(conf, sink));
        }

        private static void RegisterCoreComponents(ILogServiceCollection services, IOptions<ConsoleSinkOptions> settings) {
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, ConsolePayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, ConsolePayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<ConsoleSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}