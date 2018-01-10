using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Config;

namespace Cosmos.Logging.Sinks.NLog {
    public static class NLogSinkExtensions {
        public static ILogServiceCollection WriteToNLog(this ILogServiceCollection services) {
            return services.WriteToNLog((Action<NLogSinkSettings>) null);
        }

        public static ILogServiceCollection WriteToNLog(this ILogServiceCollection services, Action<NLogSinkSettings> settingAct) {
            var settings = new NLogSinkSettings();
            settingAct?.Invoke(settings);
            return services.WriteToNLog(settings);
        }

        public static ILogServiceCollection WriteToNLog(this ILogServiceCollection services, NLogSinkSettings settings) {
            return services.WriteToNLog(Options.Create(settings));
        }

        public static ILogServiceCollection WriteToNLog(this ILogServiceCollection services, IOptions<NLogSinkSettings> settings) {
            services.AddSinkSettings(settings.Value);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, NLogPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, NLogPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            if (settings.Value.OriginConfiguration != null) {
                services.AddOriginConfigAction(root => LogManager.Configuration = settings.Value.OriginConfiguration);
            } else if (settings.Value.DoesUsedDefaultConfig) {
                services.AddOriginConfigAction(root => LogManager.Configuration = new DefaultLoggingConfiguration());
            } else if (!string.IsNullOrWhiteSpace(settings.Value.OriginConfigFilePath)) {
                
                services.AddOriginConfigAction(root => LogManager.Configuration = new XmlLoggingConfiguration(settings.Value.OriginConfigFilePath));
            }

            return services;
        }


    }
}