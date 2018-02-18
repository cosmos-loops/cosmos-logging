using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.File;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class LocalFileLogSinkExtensions {
        public static ILogServiceCollection AddFIle(this ILogServiceCollection services, Action<FileSinkOptions> settingAct = null,
            Action<IConfiguration, FileSinkLogConfiguration> config = null) {
            var options = new FileSinkOptions();
            settingAct?.Invoke(options);
            return services.AddFIle(Options.Create(options), config);
        }

        public static ILogServiceCollection AddFIle(this ILogServiceCollection services, IOptions<FileSinkOptions> settings,
            Action<IConfiguration, FileSinkLogConfiguration> config = null) {
            services.AddSinkSettings<FileSinkOptions, FileSinkLogConfiguration>(settings.Value, (conf, sink) => config?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, LocalFileLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, LocalFileLogPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<FileSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}