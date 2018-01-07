using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public static class SampleLogSinkExtensions {
        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services) {
            return services.WriteToSampleLog(null);
        }

        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services, Action<SampleLogSinkSettings> sinkSettingAct) {

            var settings = new SampleLogSinkSettings();
            sinkSettingAct?.Invoke(settings);

            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, SampleLogPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, SampleLogPayloadClientProvider>();
                s.AddSingleton(Options.Create(settings));
            });
            return services;
        }
    }
}