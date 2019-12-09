using System;
using System.Data.Entity;
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
    public static class EfEnricherExtensions {
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

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<EfEnricherOptions, EfEnricherConfiguration>(settings.Value,
                    (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfInterceptorDescriptor),
                    provider => new EfInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings))));

                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfIntegrationActivation),
                    provider => new EfIntegrationActivation(provider.GetService<EfInterceptorDescriptor>()))));

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<EfEnricherOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(EfInterceptorDescriptor), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(EfIntegrationActivation), false, ServiceLifetime.Singleton));
        }
    }
}