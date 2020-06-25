using System;
using AspectCore.DependencyInjection;
using Cosmos.Extensions.Dependency;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.AspectCoreInjector;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for AspectCore register
    /// </summary>
    public static class AspectCoreRegisterExtensions {
        /// <summary>
        /// Register Cosmos.Logging for NCC AspectCore
        /// </summary>
        /// <param name="services"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection RegisterCosmosLogging(this IServiceContext services, IConfigurationRoot root) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            return new AspectCoreServiceCollection(services, root);
        }

        /// <summary>
        /// Done
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceContext Done(this ILogServiceCollection services) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (services is AspectCoreServiceCollection loggingServices) {

                var builder = loggingServices.OriginalServices;

                using (loggingServices) {

                    loggingServices.RegisterCoreComponents();

                    loggingServices.BuildAndActiveConfiguration();

                    loggingServices.RegisterTraceIdGenerator();

                }

                return builder;

            }

            throw new ArgumentException("Unknown type of ILogServiceCollection");
        }

        private static void RegisterCoreComponents(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddSingleton<ILoggingServiceProvider, AspectCoreLogServiceProvider>());
            services.AddDependency(s => s.TryAddSingleton<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>());
        }

        private static void BuildAndActiveConfiguration(this AspectCoreServiceCollection services) {
            services.BuildConfiguration();
            services.ActiveSinkSettings();
            services.ActiveOriginConfiguration();

            services.AddDependency(s => s.TryAddSingleton(Options.Create((LoggingOptions) services.ExposeLogSettings())));
            services.AddDependency(s => s.TryAddSingleton(services.ExposeLoggingConfiguration()));
        }

        private static void RegisterTraceIdGenerator(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddScoped<FallbackTraceIdAccessor, FallbackTraceIdAccessor>());
        }
    }
}