using System;
using System.Data.Entity;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.EntityFramework.Core;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class EfExtraSinkExtensions {
        public static DatabaseIntegration UseEntityFramework(this DatabaseIntegration integration, Action<EfSinkOptions> settingAct = null,
            Action<IConfiguration, EfSinkConfiguration> configAction = null) {
            var settings = new EfSinkOptions();
            settingAct?.Invoke(settings);

            void InternalAction(IConfiguration conf, EfSinkConfiguration sink, LoggingConfiguration configuration) {
                configAction?.Invoke(conf, sink);
                if (configuration?.LogLevel != null) {
                    AddNamespace($"{typeof(DbContext).Namespace}.*", GetExpectLevelName());
                    AddNamespace($"{typeof(Database).FullName}", LogEventLevel.Debug.GetName());
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

            return UseEntityFrameworkCore(integration, Options.Create(settings), InternalAction);
        }

        private static DatabaseIntegration UseEntityFrameworkCore(DatabaseIntegration integration, IOptions<EfSinkOptions> settings,
            Action<IConfiguration, EfSinkConfiguration, LoggingConfiguration> config = null) {
            if (integration == null) throw new ArgumentNullException(nameof(integration));

            var serviceImpl = integration.ExposeServiceCollectionWrapper;
            if (serviceImpl != null) {
                serviceImpl.AddExtraSinkSettings<EfSinkOptions, EfSinkConfiguration>(settings.Value, (conf, sink, configuration) => config?.Invoke(conf, sink, configuration));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(settings)));
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfInterceptorDescriptor),
                    provider => new EfInterceptorDescriptor(provider.GetService<ILoggingServiceProvider>(), settings))));

                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(typeof(EfIntegrationActivation),
                    provider => new EfIntegrationActivation(provider.GetService<EfInterceptorDescriptor>()))));
            }

            return integration;
        }
    }
}