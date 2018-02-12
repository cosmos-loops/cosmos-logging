using System;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.NHibernate.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using NHibernate;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class NhExtraSinkExtensions {
        public static DatabaseIntegration UseNHibernate(this DatabaseIntegration integration, Action<NhSinkOptions> settingAct = null,
            Action<IConfiguration, NhSinkConfiguration> configAction = null) {
            var settings = new NhSinkOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, NhSinkConfiguration sink, LoggingConfiguration configuration) {
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

        private static DatabaseIntegration UseNHibernateCore(DatabaseIntegration integration, IOptions<NhSinkOptions> settings,
            Action<IConfiguration, NhSinkConfiguration, LoggingConfiguration> config = null) {
            if (integration == null) throw new ArgumentNullException(nameof(integration));

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<NhSinkOptions, NhSinkConfiguration>(settings.Value, (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(provider =>
                    new StaticServiceResolveInitialization(provider.GetRequiredService<ILoggingServiceProvider>(), settings.Value))));

                RegisterCoreComponentsTypes();
            }

            return integration;
        }
        
        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<NhSinkOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(StaticServiceResolveInitialization), false, ServiceLifetime.Singleton));
        }
    }
}