using System;
using System.Data.Entity;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFramework.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Cosmos Logging EntityFramework Enricher extensions
    /// </summary>
    public static class EfEnricherExtensions {
        /// <summary>
        /// Use EntityFramework for Cosmos.Logging
        /// </summary>
        /// <param name="integration"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static DatabaseIntegration UseEntityFramework(
            this DatabaseIntegration integration,
            Action<EfEnricherOptions> settingAct = null,
            Action<IConfiguration, EfEnricherConfiguration> configAction = null) {

            var settings = new EfEnricherOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, EfEnricherConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    AddNamespace($"{typeof(DbContext).Namespace}.*", GetExpectLevelName());
                    AddNamespace($"{typeof(Database).FullName}", LogEventLevel.Debug.GetName());
                }

                void AddNamespace(string @namespace, string expectLevelName) {
                    if (string.IsNullOrWhiteSpace(@namespace)) return;
                    if (configuration.LogLevel.ContainsKey(@namespace)) {
                        configuration.LogLevel[@namespace] = expectLevelName;
                    }
                    else {
                        configuration.LogLevel.Add(@namespace, expectLevelName);
                    }
                }

                string GetExpectLevelName() => settings.MinimumLevel.HasValue
                    ? settings.MinimumLevel.Value.GetName()
                    : LogEventLevel.Verbose.GetName();
            }

            return UseEntityFrameworkCore(integration, Options.Create(settings), InternalAction);
        }

        private static DatabaseIntegration UseEntityFrameworkCore(
            DatabaseIntegration integration,
            IOptions<EfEnricherOptions> settings,
            Action<IConfiguration, EfEnricherConfiguration, LoggingConfiguration> config = null) {

            if (integration is null) throw new ArgumentNullException(nameof(integration));

            var services = integration.ExposeServiceCollectionWrapper;

            if (services != null) {
                services.AddExtraSinkSettings<EfEnricherOptions, EfEnricherConfiguration>(settings.Value, (c, s, l) => config?.Invoke(c, s, l));
                services.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));

                RegisterEntityFrameworkInterceptor(services, settings);

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterEntityFrameworkInterceptor(ILogServiceCollection services, IOptions<EfEnricherOptions> settings) {
            services.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfInterceptorDescriptor), __efDescriptorFactory)));
            services.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfIntegrationActivation), __efIntegrationFactory)));

            // ReSharper disable once InconsistentNaming
            object __efDescriptorFactory(IServiceProvider provider) {
                return new EfInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings);
            }

            // ReSharper disable once InconsistentNaming
            object __efIntegrationFactory(IServiceProvider provider) {
                return new EfIntegrationActivation(provider.GetService<EfInterceptorDescriptor>());
            }
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<EfEnricherOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(EfInterceptorDescriptor), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(EfIntegrationActivation), false, ServiceLifetime.Singleton));
        }
    }
}