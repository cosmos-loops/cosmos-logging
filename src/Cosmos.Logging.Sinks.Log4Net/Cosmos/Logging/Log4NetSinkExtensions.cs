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

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Log4Net sink
    /// </summary>
    public static class Log4NetSinkExtensions {
        /// <summary>
        /// Add Log4Net support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, Action<Log4NetSinkOptions> settingAct = null,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            var settings = new Log4NetSinkOptions();
            settingAct?.Invoke(settings);
            return services.AddLog4Net(settings, configAct);
        }

        /// <summary>
        /// Add Log4Net support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sinkOptions"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, Log4NetSinkOptions sinkOptions,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            return services.AddLog4Net(Options.Create(sinkOptions), configAct);
        }

        /// <summary>
        /// Add Log4Net support for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddLog4Net(this ILogServiceCollection services, IOptions<Log4NetSinkOptions> settings,
            Action<IConfiguration, Log4NetSinkConfiguration> configAct = null) {
            services.AddSinkSettings(settings.Value, configAct);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, Log4NetPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, Log4NetPayloadClientProvider>();
                s.TryAdd(ServiceDescriptor.Singleton(settings));
            });

            RegisterNativeConfigurationFile(services, settings);

            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterNativeConfigurationFile(ILogServiceCollection services, IOptions<Log4NetSinkOptions> settings) {
            var filePath = settings.Value.NativeConfigFilePath;
            var needWatch = settings.Value.WatchNativeConfigFile;

            if (string.IsNullOrWhiteSpace(filePath))
                return;

            services.AddOriginalConfigAction(__loadingAndConfiguringConfigurationPath);

            // ReSharper disable once InconsistentNaming
            void __loadingAndConfiguringConfigurationPath(IConfiguration _) {

                if (!File.Exists(filePath))
                    return;

                var loggerRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

                if (needWatch)
                    XmlConfigurator.ConfigureAndWatch(loggerRepository, new FileInfo(filePath));
                else
                    XmlConfigurator.Configure(loggerRepository, new FileInfo(filePath));
            }
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<Log4NetSinkOptions>), false, ServiceLifetime.Singleton));
        }
    }
}