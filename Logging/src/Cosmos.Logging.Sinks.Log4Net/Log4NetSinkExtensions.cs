using System;
using System.IO;
using System.Reflection;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Settings;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    public static class Log4NetSinkExtensions {
        public static ILogServiceCollection WriteToLog4Net(this ILogServiceCollection services) {
            return services.WriteToLog4Net((Action<Log4NetSinkSettings>) null);
        }

        public static ILogServiceCollection WriteToLog4Net(this ILogServiceCollection services, Action<Log4NetSinkSettings> settingAct) {
            var settings = new Log4NetSinkSettings();
            settingAct?.Invoke(settings);
            return services.WriteToLog4Net(settings);
        }

        public static ILogServiceCollection WriteToLog4Net(this ILogServiceCollection services, Log4NetSinkSettings settings) {
            return services.WriteToLog4Net(Options.Create(settings));
        }

        public static ILogServiceCollection WriteToLog4Net(this ILogServiceCollection services, IOptions<Log4NetSinkSettings> settings) {
            services.AddSinkSettings(settings.Value);
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