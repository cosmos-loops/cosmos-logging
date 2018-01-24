using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public static class SampleLogSinkExtensions {
        public static ILogServiceCollection UseSampleLog(this ILogServiceCollection services, Action<SampleLogSinkSettings> settingAct = null,
            Action<IConfiguration, SampleLogConfiguration> configAction = null) {
            var settings = new SampleLogSinkSettings();
            settingAct?.Invoke(settings);
            return services.UseSampleLog(settings, configAction);
        }

        public static ILogServiceCollection UseSampleLog(this ILogServiceCollection services, SampleLogSinkSettings settings,
            Action<IConfiguration, SampleLogConfiguration> configAction = null) {
            return services.UseSampleLog(Options.Create(settings), configAction);
        }

        public static ILogServiceCollection UseSampleLog(this ILogServiceCollection services, IOptions<SampleLogSinkSettings> settings,
            Action<IConfiguration, SampleLogConfiguration> configAction = null) {
            services.AddSinkSettings<SampleLogSinkSettings, SampleLogConfiguration>(settings.Value, (conf, sink) => configAction?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, SampleLogPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, SampleLogPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            return services;
        }
    }
}