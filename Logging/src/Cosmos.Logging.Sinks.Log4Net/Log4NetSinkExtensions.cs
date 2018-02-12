using System;
using System.IO;
using System.Reflection;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.Log4Net;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class Log4NetSinkExtensions {
        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, Action<Log4NetSinkOptions> settingAct = null,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            var settings = new Log4NetSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddLog4Net(settings, configAct);
        }

        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, Log4NetSinkOptions sinkOptions,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            return services.AddLog4Net(Options.Create(sinkOptions), configAct);
        }

        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, IOptions<Log4NetSinkOptions> settings,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            services.AddSinkSettings<Log4NetSinkOptions, Log4NetSinkConfiguration>(settings.Value, (conf, sink) => configAct?.Invoke(conf, sink));
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, Log4NetPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, Log4NetPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });
            if (!string.IsNullOrWhiteSpace(settings.Value.OriginConfigFilePath)) {
                services.AddOriginConfigAction(root => InternalUseCustomConfigFilePath(settings.Value.OriginConfigFilePath, settings.Value.WatchOriginConfigFile));
            }

            RegisterCoreComponentsTypes();

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

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<Log4NetSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}