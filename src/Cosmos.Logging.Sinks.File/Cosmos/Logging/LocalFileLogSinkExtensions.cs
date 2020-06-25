using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.File;
using Cosmos.Logging.Sinks.File.Renderers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for local file log sink
    /// </summary>
    public static class LocalFileLogSinkExtensions {
        /// <summary>
        /// Add file log for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settingAct"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddFilelog(this ILogServiceCollection services, Action<FileSinkOptions> settingAct = null,
            Action<IConfiguration, FileSinkLogConfiguration> config = null) {
            var options = new FileSinkOptions();
            settingAct?.Invoke(options);
            return services.AddFilelog(Options.Create(options), config);
        }

        /// <summary>
        /// Add file log for Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddFilelog(this ILogServiceCollection services, IOptions<FileSinkOptions> settings,
            Action<IConfiguration, FileSinkLogConfiguration> config = null) {
            services.AddSinkSettings(settings.Value, config);
            services.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, LocalFileLogPayloadClient>();
                s.AddSingleton<ILogPayloadClientProvider, LocalFileLogPayloadClientProvider>();
                s.TryAddSingleton(settings);
            });

            InternalRendererActivation.Action();
            RegisterCoreComponentsTypes();

            return services;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<FileSinkOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}