using System;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.FreeSql.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class FreeSqlEnricherExtensions {
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
                    }
                    else {
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

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<FreeSqlEnricherOptions, FreeSqlEnricherConfiguration>(settings.Value,
                    (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(FreeSqlInterceptorDescriptor),
                    provider => new FreeSqlInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings))));

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<FreeSqlEnricherOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(FreeSqlInterceptorDescriptor), false, ServiceLifetime.Singleton));
        }
    }
}