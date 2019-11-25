using System;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFrameworkCore.Core;
using EnumsNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class EfCoreEnricherExtensions {
        public static DatabaseIntegration UseEntityFrameworkCore(this DatabaseIntegration integration, Action<EfCoreEnricherOptions> settingAct = null,
            Action<IConfiguration, EfCoreEnricherConfiguration> configAction = null) {
            var settings = new EfCoreEnricherOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, EfCoreEnricherConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    AddNamespace($"{typeof(DbContext).Namespace}.*", GetExpectLevelName());
                    AddNamespace($"{typeof(DbContextOptionsBuilder).FullName}", GetExpectLevelName());
                    AddNamespace(DbLoggerCategory.Database.Command.Name, GetExpectLevelName());
                    AddNamespace(DbLoggerCategory.Query.Name, GetExpectLevelName());
                    AddNamespace(DbLoggerCategory.Update.Name, GetExpectLevelName());
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

            return UseEntityFrameworkCoreInternal(integration, Options.Create(settings), InternalAction);
        }

        private static DatabaseIntegration UseEntityFrameworkCoreInternal(DatabaseIntegration integration, IOptions<EfCoreEnricherOptions> settings,
            Action<IConfiguration, EfCoreEnricherConfiguration, LoggingConfiguration> config = null) {

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<EfCoreEnricherOptions, EfCoreEnricherConfiguration>(settings.Value,
                    (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfCoreInterceptorDescriptor),
                    provider => {
                        var instance = new EfCoreInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings);
                        EfCoreInterceptorDescriptor.Instance = instance;
                        return instance;
                    })));

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<EfCoreEnricherOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(EfCoreInterceptorDescriptor), false, ServiceLifetime.Singleton));
        }

    }
}