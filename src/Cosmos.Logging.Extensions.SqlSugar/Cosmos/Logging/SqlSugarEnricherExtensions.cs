using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.SqlSugar.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for SqlSugar enricher
    /// </summary>
    public static class SqlSugarEnricherExtensions {
        /// <summary>
        /// Use SqlSugar for Cosmos.Logging
        /// </summary>
        /// <param name="integration"></param>
        /// <param name="settingAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static DatabaseIntegration UseSqlSugar(
            this DatabaseIntegration integration,
            Action<SqlSugarEnricherOptions> settingAct = null,
            Action<IConfiguration, SqlSguarEnricherConfiguration> configAction = null) {

            var settings = new SqlSugarEnricherOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, SqlSguarEnricherConfiguration sink, LoggingConfiguration configuration) {
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

        private static DatabaseIntegration UseSqlSugarCore(
            DatabaseIntegration integration,
            IOptions<SqlSugarEnricherOptions> settings,
            Action<IConfiguration, SqlSguarEnricherConfiguration, LoggingConfiguration> config = null) {

            if (integration is null) throw new ArgumentNullException(nameof(integration));

            var services = integration.ExposeServiceCollectionWrapper;
            if (services != null) {
                services.AddExtraSinkSettings(settings.Value, config);
                services.AddDependency(s => s.TryAddSingleton(settings));

                RegisterSqlSugarInterceptor(services, settings);

                RegisterCoreComponentsTypes();
            }

            return integration;
        }

        private static void RegisterSqlSugarInterceptor(ILogServiceCollection services, IOptions<SqlSugarEnricherOptions> settings) {
            services.AddDependency(s => s.TryAddSingleton<IServiceProvider>(__sqlsugarInterceptorFactory, typeof(SqlSugarInterceptorDescriptor)));

            // ReSharper disable once InconsistentNaming
            object __sqlsugarInterceptorFactory(IServiceProvider provider) {
                return new SqlSugarInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings);
            }
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<SqlSugarEnricherOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(SqlSugarInterceptorDescriptor), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }

}