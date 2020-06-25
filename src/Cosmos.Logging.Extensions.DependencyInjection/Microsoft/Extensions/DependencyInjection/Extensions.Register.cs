using System;
using Cosmos.Extensions.Dependency;
using Cosmos.Logging;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.DependencyInjection;
using Cosmos.Logging.Extensions.MicrosoftSupported;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Extensions for Service collection
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Add Cosmos.Logging
        /// </summary>
        /// <param name="services"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static ILogServiceCollection AddCosmosLogging(this IServiceCollection services, IConfigurationRoot root) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            return new StandardLogServiceCollection(services, root);
        }

        /// <summary>
        /// Done
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Done(this ILogServiceCollection services) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (services is StandardLogServiceCollection loggingServices) {

                var builder = loggingServices.OriginalServices;

                using (loggingServices) {

                    loggingServices.RegisterCoreComponents();

                    loggingServices.BuildAndActiveConfiguration();

                    loggingServices.RegisterTraceIdGenerator();

                    loggingServices.RegisterLoggerFactory();

                    loggingServices.RegisterCallback();
                }

                return builder;

            }

            throw new ArgumentException("Unknown type of ILogServiceCollection");
        }

        private static void RegisterCoreComponents(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddSingleton<ILoggingServiceProvider, StandardLogServiceProvider>());
            services.AddDependency(s => s.TryAddSingleton<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>());
            services.AddDependency(s => s.TryAddSingleton(typeof(ILogger<>), typeof(MicrosoftLoggerAdapter<>)));
        }

        private static void BuildAndActiveConfiguration(this StandardLogServiceCollection services) {
            services.BuildConfiguration();
            services.ActiveSinkSettings();
            services.ActiveOriginConfiguration();
            
            services.AddDependency(s => s.TryAddSingleton(Options.Options.Create((LoggingOptions) services.ExposeLogSettings())));
            services.AddDependency(s => s.TryAddSingleton(services.ExposeLoggingConfiguration()));
        }

        private static void RegisterTraceIdGenerator(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddScoped<FallbackTraceIdAccessor, FallbackTraceIdAccessor>());
        }

        private static void RegisterLoggerFactory(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddSingleton<ILoggerFactory, IServiceProvider>(
                provider => new MicrosoftLoggerFactory(provider.GetService<ILoggingServiceProvider>())));
        }

        private static void RegisterCallback(this StandardLogServiceCollection services) {
            services.AddDependency(s => s.AddSingleton<StandardSecInitializingCallback, IServiceProvider>(provider => {
                var callback = new StandardSecInitializingCallback();
                callback.AppendAction(services.ActiveLogEventEnrichers);
                callback.AppendAction(() => StaticServiceResolver.SetResolver(provider.GetService<ILoggingServiceProvider>()));
                return callback;
            }));
        }
    }
}