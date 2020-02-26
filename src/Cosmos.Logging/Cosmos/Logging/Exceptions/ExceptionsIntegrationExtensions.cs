using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Components;
using Cosmos.Logging.Exceptions.Configurations;
using Cosmos.Logging.Exceptions.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for exceptions integration
    /// </summary>
    public static class ExceptionsIntegrationExtensions {
        /// <summary>
        /// Add exception integration for Cosmos Logging
        /// </summary>
        /// <param name="service"></param>
        /// <param name="exceptionOptionAct"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection AddExceptionsIntegration(
            this ILogServiceCollection service,
            Action<ExceptionOptions> exceptionOptionAct = null,
            Action<IConfiguration, ExceptionConfiguration> configAction = null) {
            
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            var settings = ExceptionOptions.Create(exceptionOptionAct);

            service.UseExceptionExtensionsCore(settings.ToMsOptions(), (conf, sink, _) => configAction?.Invoke(conf, sink));

            return service;
        }

        private static ILogServiceCollection UseExceptionExtensionsCore(this ILogServiceCollection service, IOptions<ExceptionOptions> settings,
            Action<IConfiguration, ExceptionConfiguration, LoggingConfiguration> config = null) {
            var exceptionDestructuringAccessor = new ExceptionDestructuringAccessor();

            service.AddExtraSinkSettings(settings.Value, config);
            service.AddDependency(s => s.TryAddSingleton(settings));
            service.AddDependency(s => s.TryAddSingleton<IExceptionDestructuringAccessor>(exceptionDestructuringAccessor));
            service.AddEnricher(() => new ExceptionEnricher(exceptionDestructuringAccessor.Get()));

            RegisterCoreComponentsTypes();

            return service;
        }

        private static void RegisterCoreComponentsTypes() {
            SinkComponentsTypes.SafeAddAppendType(new ComponentsRegistration(typeof(IOptions<ExceptionOptions>), Many.FALSE, DependencyLifetimeType.Singleton));
        }
    }
}