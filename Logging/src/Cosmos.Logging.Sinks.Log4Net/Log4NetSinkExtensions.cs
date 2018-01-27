using System;
using System.IO;
using System.Reflection;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    public static class Log4NetSinkExtensions {
        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, Action<Log4NetOptions> settingAct = null,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            var settings = new Log4NetOptions();
            settingAct?.Invoke(settings);
            return services.AddLog4Net(settings, configAct);
        }

        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, Log4NetOptions options,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            return services.AddLog4Net(Options.Create(options), configAct);
        }

        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, IOptions<Log4NetOptions> settings,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            services.AddSinkSettings<Log4NetOptions, Log4NetSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, Log4NetPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, Log4NetPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            if (!string.IsNullOrWhiteSpace(settings.Value.OriginConfigFilePath)) {
                services.AddOriginConfigAction(root => InternalUseCustomConfigFilePath(settings.Value.OriginConfigFilePath, settings.Value.WatchOriginConfigFile));
            }

            return services;
        }

        private static bool InternalUseCustomConfigFilePath(string filePath, bool needWatch = false) {
            if (!File.Exists(filePath)) return false;
            var loggerRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            if (needWatch)
                XmlConfigurator.ConfigureAndWatch(loggerRepository, new FileInfo(filePath));
            else
                XmlConfigurator.Configure(loggerRepository, new FileInfo(filePath));

            return true;
        }
    }
}