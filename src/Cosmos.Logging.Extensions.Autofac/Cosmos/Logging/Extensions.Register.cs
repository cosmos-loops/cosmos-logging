using System;
using Autofac;
using Cosmos.Extensions.Dependency;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.Autofac;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for Autofac
    /// </summary>
    public static class AutofacRegisterExtensions {
        /// <summary>
        /// Register Cosmos.Logging for Autofac
        /// </summary>
        /// <param name="services"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection RegisterCosmosLogging(this ContainerBuilder services, IConfigurationRoot root) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            return new AutofacServiceCollection(services, root);
        }
        
        /// <summary>
        /// Done
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ContainerBuilder Done(this ILogServiceCollection services) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (services is AutofacServiceCollection loggingServices) {

                var builder = loggingServices.OriginalServices;

                using (loggingServices) {
                    
                    loggingServices.RegisterCoreComponents();

                    loggingServices.BuildAndActiveConfiguration();

                    loggingServices.RegisterTraceIdGenerator();

                    loggingServices.RegisterPostBuiltAction();

                }

                return builder;
                
            }
            
            throw new ArgumentException("Unknown type of ILogServiceCollection");
        }
        
        private static void RegisterCoreComponents(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddSingleton<ILoggingServiceProvider, AutofacLogServiceProvider>());
            services.AddDependency(s => s.TryAddSingleton<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>());
        }

        private static void BuildAndActiveConfiguration(this AutofacServiceCollection services) {
            services.BuildConfiguration();
            services.ActiveSinkSettings();
            services.ActiveOriginConfiguration();
            
            services.AddDependency(s => s.TryAddSingleton(Options.Create((LoggingOptions) services.ExposeLogSettings())));
            services.AddDependency(s => s.TryAddSingleton(services.ExposeLoggingConfiguration()));

        }

        private static void RegisterTraceIdGenerator(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddScoped<FallbackTraceIdAccessor, FallbackTraceIdAccessor>());
        }
        
        private static void RegisterPostBuiltAction(this AutofacServiceCollection services) {
            services.AddPostRegisterAction("AfterBuild", builder =>
                builder.RegisterBuildCallback(container => {
                    services.ActiveLogEventEnrichers();
                    StaticServiceResolver.SetResolver(container.Resolve<ILoggingServiceProvider>());
                }));
        }
    }
}