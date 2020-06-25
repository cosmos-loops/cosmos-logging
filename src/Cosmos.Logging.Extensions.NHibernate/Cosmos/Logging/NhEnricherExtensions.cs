using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.NHibernate.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using NHibernate;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for NHibernate enricher
    /// </summary>
    public static class NhEnricherExtensions {
        /// <summary>
        /// Add NHibernate for Cosmos.Logging
        /// </summary>
        /// <param name="integration"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static DatabaseIntegration UseNHibernate(
            this DatabaseIntegration integration,
            Action<NhEnricherOptions> settingAct = null,
            Action<IConfiguration, NhEnricherConfiguration> configAction = null) {
            var settings = new NhEnricherOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, NhEnricherConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    AddNamespace($"{typeof(ISessionFactory).Namespace}.*", GetExpectLevelName());
                }

                void AddNamespace(string @namespace, string expectLevelName) {
                    if (string.IsNullOrWhiteSpace(@namespace)) return;
                    if (configuration.LogLevel.ContainsKey(@namespace)) {
                        configuration.LogLevel[@namespace] = expectLevelName;
                    } else {
                        configuration.LogLevel.Add(@namespace, expectLevelName);
                    }
                }

                string GetExpectLevelName() => settings.MinimumLevel.HasValue
                    ? settings.MinimumLevel.Value.GetName()
                    : LogEventLevel.Verbose.GetName();
            }

            return UseNHibernateCore(integration, Options.Create(settings), InternalAction);
        }

        private static DatabaseIntegration UseNHibernateCore(
            DatabaseIntegration integration,
            IOptions<NhEnricherOptions> settings,
            Action<IConfiguration, NhEnricherConfiguration, LoggingConfiguration> config = null) {
            if (integration is null) throw new ArgumentNullException(nameof(integration));

            var services = integration.ExposeServiceCollectionWrapper;
            if (services != null) {
                services.AddExtraSinkSettings(settings.Value, config);
                services.AddDependency(s => s.TryAddSingleton(settings));

                RegisterNHibernateInitialization(services, settings);

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterNHibernateInitialization(ILogServiceCollection services, IOptions<NhEnricherOptions> settings) {
            services.AddDependency(s => s.TryAddSingleton<IServiceProvider>(__nhibernateInitFactory, typeof(StaticServiceResolveInitialization)));

            // ReSharper disable once InconsistentNaming
            object __nhibernateInitFactory(IServiceProvider provider) {
                return new StaticServiceResolveInitialization(provider.GetRequiredService<ILoggingServiceProvider>(), settings.Value);
            }
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<NhEnricherOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(StaticServiceResolveInitialization), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}