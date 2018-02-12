using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.SampleLogSink;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class SampleLogSinkExtensions {
        public static ILogServiceCollection AddSampleLog(this ILogServiceCollection services, Action<SampleOptions> settingAct = null,
            Action<IConfiguration, SampleLogConfiguration> config = null) {
            var options = new SampleOptions();
            settingAct?.Invoke(options);
            return services.AddSampleLog(Options.Create(options), config);
        }

        public static ILogServiceCollection AddSampleLog(this ILogServiceCollection services, IOptions<SampleOptions> settings,
            Action<IConfiguration, SampleLogConfiguration> config = null) {
            services.AddSinkSettings<SampleOptions, SampleLogConfiguration>(settings.Value, (conf, sink) => config?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.TryAdd(ServiceDescriptor.Scoped<ILogPayloadClient, SampleLogPayloadClient>());
                s.TryAdd(ServiceDescriptor.Singleton<ILogPayloadClientProvider, SampleLogPayloadClientProvider>());
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<SampleOptions>), false, ServiceLifetime.Singleton));
        }
    }
}