using System;
using System.Web;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Cosmos.IdUtils;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNet;
using Cosmos.Logging.RunsOn.AspNet.Core.Internals;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for ASP.NET-Autofac 
    /// </summary>
    public static class AutofacAspNetExtensions {
        /// <summary>
        /// Register Cosmos.Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="application"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ContainerBuilder RegisterCosmosLogging(this ContainerBuilder builder, HttpApplication application, Action<ILogServiceCollection> config = null) {
            RegisterCosmosLoggingCore(application, builder, config);
            return builder;
        }

        /// <summary>
        /// Register Cosmos.Logging
        /// </summary>
        /// <param name="application"></param>
        /// <param name="builder"></param>
        /// <param name="config"></param>
        public static void RegisterCosmosLogging(this HttpApplication application, ContainerBuilder builder, Action<ILogServiceCollection> config = null) {
            RegisterCosmosLoggingCore(application, builder, config);
        }

        private static void RegisterCosmosLoggingCore(HttpApplication application, ContainerBuilder builder, Action<ILogServiceCollection> config = null) {
            if (application is null) throw new ArgumentNullException(nameof(application));
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            var services = new AutofacAspNetServiceCollection();

            config?.Invoke(services);

            RegisterCoreComponents(services);

            UpdateAutofacContainer(builder, services);

            builder.RegisterBuildCallback(c => services.ActiveLogEventEnrichers());
        }

        private static void RegisterCoreComponents(AutofacAspNetServiceCollection services) {
            services.BuildConfiguration();
            services.ActiveSinkSettings();
            services.ActiveOriginConfiguration();
            services.AddDependency(s => s.AddSingleton(__singletonFactory));

            StaticServiceResolveInitialization __singletonFactory(IServiceProvider provider) {
                return new StaticServiceResolveInitialization(provider.GetRequiredService<ILoggingServiceProvider>());
            }
        }

        private static void UpdateAutofacContainer(ContainerBuilder builder, AutofacAspNetServiceCollection services) {
            builder.Populate(services.ExposeServices());
            builder.RegisterType<AspNetLoggingServiceProvider>().As<ILoggingServiceProvider>().SingleInstance();
            builder.RegisterType<ShortcutPropertyFactoryAccessor>().As<IPropertyFactoryAccessor>().SingleInstance();
            builder.RegisterTraceIdGenerator();
            builder.RegisterInstance(Options.Create((LoggingOptions) services.ExposeLogSettings()));
            builder.RegisterInstance(services.ExposeLoggingConfiguration());
        }

        private static void RegisterTraceIdGenerator(this ContainerBuilder builder) {
            builder.RegisterType<FallbackTraceIdAccessor>().As<FallbackTraceIdAccessor>().InstancePerRequest();

            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                builder.Register(__traceIdGeneratorFactory).As<ILogTraceIdGenerator>().InstancePerRequest();
                ExpectedTraceIdGeneratorName.Value = nameof(SystemTraceIdGenerator);
            }

            // ReSharper disable once InconsistentNaming
            ILogTraceIdGenerator __traceIdGeneratorFactory(IComponentContext provider) {
                //1. Get traceIdAccessor and fallbackTraceIdAccessor from ServiceProvider
                var traceIdAccessor = provider.ResolveOptional<TraceIdAccessor>();
                var fallbackAccessor = provider.Resolve<FallbackTraceIdAccessor>();

                //2. Create a new instance of SystemTraceIdGenerator
                var generator = new SystemTraceIdGenerator(traceIdAccessor, fallbackAccessor);

                //3. Scoped update
                LogTraceIdGenerator.ScopedUpdate(generator);

                //4. Done, and return.
                return generator;
            }
        }
    }
}