using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Config;

namespace Cosmos.Logging.Sinks.NLog {
    public static class NLogSinkExtensions {
        public static ILogServiceCollection UseNLog(this ILogServiceCollection services, Action<NLogSinkSettings> settingAct = null,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            var settings = new NLogSinkSettings();
            settingAct?.Invoke(settings);
            return services.UseNLog(settings, configAction);
        }

        public static ILogServiceCollection UseNLog(this ILogServiceCollection services, NLogSinkSettings settings,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            return services.UseNLog(Options.Create(settings), configAction);
        }

        public static ILogServiceCollection UseNLog(this ILogServiceCollection services, IOptions<NLogSinkSettings> settings,
            Action<IConfiguration, NLogSinkConfiguration> configAction = null) {
            services.AddSinkSettings<NLogSinkSettings, NLogSinkConfiguration>(settings.Value, (conf, sink) => configAction?.Invoke(conf, sink));
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