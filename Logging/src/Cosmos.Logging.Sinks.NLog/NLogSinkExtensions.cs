using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Config;

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
            services.AddSinkSettings<NLogSinkOptions, NLogSinkConfiguration>(settings.Value, (conf, sink) => configAction?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.TryAdd(ServiceDescriptor.Scoped<ILogPayloadClient, NLogPayloadClient>());
                s.TryAdd(ServiceDescriptor.Singleton<ILogPayloadClientProvider, NLogPayloadClientProvider>());
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });
            if (settings.Value.OriginConfiguration != null) {
                services.AddOriginConfigAction(root => LogManager.Configuration = settings.Value.OriginConfiguration);
            } else if (settings.Value.DoesUsedDefaultConfig) {
                services.AddOriginConfigAction(root => LogManager.Configuration = new DefaultLoggingTarget());
            } else if (!string.IsNullOrWhiteSpace(settings.Value.OriginConfigFilePath)) {
                services.AddOriginConfigAction(root => LogManager.Configuration = new XmlLoggingConfiguration(settings.Value.OriginConfigFilePath));
            }

            return services;
        }
    }
}