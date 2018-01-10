using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public static class SampleLogSinkExtensions {
        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services) {
            return services.WriteToSampleLog((Action<SampleLogSinkSettings>) null);
        }
        
        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services, Action<SampleLogSinkSettings> settingAct) {
            var settings = new SampleLogSinkSettings();
            settingAct?.Invoke(settings);
            return services.WriteToSampleLog(settings);
        }

        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services, SampleLogSinkSettings settings) {
            return services.WriteToSampleLog(Options.Create(settings));
        }

        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services, IOptions<SampleLogSinkSettings> settings) {
            services.AddSinkSettings(settings.Value);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, SampleLogPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, SampleLogPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            return services;
        }
    }
}