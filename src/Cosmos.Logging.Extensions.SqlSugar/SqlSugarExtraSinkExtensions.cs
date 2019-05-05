using System;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.SqlSugar.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using SqlSugar;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class SqlSugarExtraSinkExtensions {
        public static DatabaseIntegration UseSqlSugar(this DatabaseIntegration integration, Action<SqlSugarOptions> settingAct = null,
            Action<IConfiguration, SqlSguarConfiguration> configAction = null) {
            var settings = new SqlSugarOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, SqlSguarConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    var @namespace = $"{typeof(SqlSugarClient).Namespace}.*";
                    if (configuration.LogLevel.ContainsKey(@namespace)) {
                        configuration.LogLevel[@namespace] = GetExpectLevelName();
                    } else {
                        configuration.LogLevel.Add(@namespace, GetExpectLevelName());
                    }
                }
            }

            string GetExpectLevelName() => settings.MinimumLevel.HasValue ? settings.MinimumLevel.Value.GetName() : LogEventLevel.Verbose.GetName();

            return UseSqlSugarCore(integration, Options.Create(settings), InternalAction);
        }

        private static DatabaseIntegration UseSqlSugarCore(DatabaseIntegration integration, IOptions<SqlSugarOptions> settings,
            Action<IConfiguration, SqlSguarConfiguration, LoggingConfiguration> config = null) {
            if (integration == null) throw new ArgumentNullException(nameof(integration));

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<SqlSugarOptions, SqlSguarConfiguration>(settings.Value, (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(SqlSugarInterceptorDescriptor),
                    provider => new SqlSugarInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings))));

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<SqlSugarOptions>), false, ServiceLifetime.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(SqlSugarInterceptorDescriptor), false, ServiceLifetime.Singleton));
        }
    }

}