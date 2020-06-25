using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFrameworkCore.Core;
using EnumsNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Cosmos Logging EntityFrameworkCore Enricher extensions
    /// </summary>
    public static class EfCoreEnricherExtensions {
        /// <summary>
        /// Use Cosmos Logging EntityFrameworkCore enricher
        /// </summary>
        /// <param name="integration"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static DatabaseIntegration UseEntityFrameworkCore(
            this DatabaseIntegration integration,
            Action<EfCoreEnricherOptions> settingAct = null,
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

        private static DatabaseIntegration UseEntityFrameworkCoreInternal(
            DatabaseIntegration integration,
            IOptions<EfCoreEnricherOptions> settings,
            Action<IConfiguration, EfCoreEnricherConfiguration, LoggingConfiguration> config = null) {

            var services = integration.ExposeServiceCollectionWrapper;
            if (services != null) {
                services.AddExtraSinkSettings(settings.Value, config);
                services.AddDependency(s => s.TryAddSingleton(settings));

                RegisterEntityFrameworkCoreInterceptor(services, settings);

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterEntityFrameworkCoreInterceptor(ILogServiceCollection services, IOptions<EfCoreEnricherOptions> settings) {
            services.AddDependency(s => s.TryAddSingleton<IServiceProvider>(__efcoreInterceptorFactory, typeof(EfCoreInterceptorDescriptor)));

            // ReSharper disable once InconsistentNaming
            object __efcoreInterceptorFactory(IServiceProvider provider) {
                var instance = new EfCoreInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings);
                EfCoreInterceptorDescriptor.Instance = instance;
                return instance;
            }
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<EfCoreEnricherOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(EfCoreInterceptorDescriptor), Many.FALSE, DependencyLifetimeType.Singleton));
        }

    }
}