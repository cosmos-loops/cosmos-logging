using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.EntityFrameworkCore.Core;
using EnumsNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class EfCoreExtraSinkExtensions {
        public static DatabaseIntegration UseEntityFrameworkCore(this DatabaseIntegration integration, Action<EfCoreSinkOptions> settingAct = null,
            Action<IConfiguration, EfCoreSinkConfiguration> configAction = null) {
            var settings = new EfCoreSinkOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, EfCoreSinkConfiguration sink, LoggingConfiguration configuration) {
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

        private static DatabaseIntegration UseEntityFrameworkCoreInternal(DatabaseIntegration integration, IOptions<EfCoreSinkOptions> settings,
            Action<IConfiguration, EfCoreSinkConfiguration, LoggingConfiguration> config = null) {

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<EfCoreSinkOptions, EfCoreSinkConfiguration>(settings.Value,
                    (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfCoreInterceptorDescriptor),
                    provider => {
                        var instance = new EfCoreInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings);
                        EfCoreInterceptorDescriptor.Instance = instance;
                        return instance;
                    })));
            }

            return integration;
        }

    }
}