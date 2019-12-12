using System;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.PostgreSql.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class PostgresEnricherExtensions {
        public static DatabaseIntegration UsePostgreSql(
            this DatabaseIntegration integration,
            Action<PostgresEnricherOptions> settingAct = null,
            Action<IConfiguration, PostgresEnricherConfiguration> configAction = null) {
            var settings = new PostgresEnricherOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, PostgresEnricherConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    var @namespace = "Npgsql.*";
                    if (configuration.LogLevel.ContainsKey(@namespace)) {
                        configuration.LogLevel[@namespace] = GetExpectLevelName();
                    }
                    else {
                        configuration.LogLevel.Add(@namespace, GetExpectLevelName());
                    }
                }
            }

            string GetExpectLevelName() => settings.MinimumLevel.HasValue ? settings.MinimumLevel.Value.GetName() : LogEventLevel.Verbose.GetName();

            return UsePostgreSqlCore(integration, Options.Create(settings), InternalAction);
        }

        private static DatabaseIntegration UsePostgreSqlCore(
            DatabaseIntegration integration,
            IOptions<PostgresEnricherOptions> settings,
            Action<IConfiguration, PostgresEnricherConfiguration, LoggingConfiguration> config = null) {
            if (integration == null) throw new ArgumentNullException(nameof(integration));

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<PostgresEnricherOptions, PostgresEnricherConfiguration>(settings.Value,
                    (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s =>
                    s.TryAdd(
                        ServiceDescriptor.Singleton(typeof(NpgsqlLogActivation), provider => new NpgsqlLogActivation(provider.GetService<ILoggingServiceProvider>(), settings))));

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<PostgresEnricherOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(NpgsqlLogActivation), false, ServiceLifetime.Singleton));
        }
    }
}