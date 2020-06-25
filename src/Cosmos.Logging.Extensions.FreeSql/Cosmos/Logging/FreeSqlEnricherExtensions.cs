using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.FreeSql.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions FreeSql enricher
    /// </summary>
    public static class FreeSqlEnricherExtensions {
        /// <summary>
        /// Use FreeSql for Cosmos Logging
        /// </summary>
        /// <param name="integration"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static DatabaseIntegration UseFreeSql(
            this DatabaseIntegration integration, Action<FreeSqlEnricherOptions> settingAct = null,
            Action<IConfiguration, FreeSqlEnricherConfiguration> configAction = null) {
            var settings = new FreeSqlEnricherOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, FreeSqlEnricherConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    var @namespace = "FreeSql.*";
                    if (configuration.LogLevel.ContainsKey(@namespace)) {
                        configuration.LogLevel[@namespace] = GetExpectLevelName();
                    } else {
                        configuration.LogLevel.Add(@namespace, GetExpectLevelName());
                    }
                }
            }

            string GetExpectLevelName() => settings.MinimumLevel.HasValue ? settings.MinimumLevel.Value.GetName() : LogEventLevel.Verbose.GetName();

            return UseFreeSqlCore(integration, Options.Create(settings), InternalAction);
        }


        private static DatabaseIntegration UseFreeSqlCore(
            DatabaseIntegration integration,
            IOptions<FreeSqlEnricherOptions> settings,
            Action<IConfiguration, FreeSqlEnricherConfiguration, LoggingConfiguration> config = null) {
            if (integration is null) throw new ArgumentNullException(nameof(integration));

            var services = integration.ExposeServiceCollectionWrapper;
            if (services != null) {
                services.AddExtraSinkSettings(settings.Value, config);
                services.AddDependency(s => s.TryAddSingleton(settings));

                RegisterFreeSqlInterceptor(services, settings);

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterFreeSqlInterceptor(ILogServiceCollection services, IOptions<FreeSqlEnricherOptions> settings) {
            services.AddDependency(s => s.TryAddSingleton<IServiceProvider>(__freesqlInterceptorFactory, typeof(FreeSqlInterceptorDescriptor)));

            // ReSharper disable once InconsistentNaming
            object __freesqlInterceptorFactory(IServiceProvider provider) {
                return new FreeSqlInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings);
            }
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<FreeSqlEnricherOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(FreeSqlInterceptorDescriptor), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}