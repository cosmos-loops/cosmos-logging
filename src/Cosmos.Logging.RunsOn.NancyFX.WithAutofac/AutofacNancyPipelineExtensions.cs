using System;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Cosmos.IdUtils;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.NancyFX;
using Cosmos.Logging.RunsOn.NancyFX.Core;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.Options;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class AutofacNancyPipelineExtensions {
        public static IPipelines RegisterCosmosLogging(this IPipelines pipelines, ILifetimeScope container, Action<ILogServiceCollection> config) {
            if (pipelines == null) throw new ArgumentNullException(nameof(pipelines));
            if (container == null) throw new ArgumentNullException(nameof(container));

            var serviceImpl = new AutofacNancyLogServiceCollection();

            config?.Invoke(serviceImpl);

            RegisterCoreComponents(serviceImpl);

            UpdateAutofacContainer(container, serviceImpl);

            UpdateStaticProvider(container);

            NancyPipelinesHook.RegisterLoggingHandlers(pipelines);
            
            RegisterEnricherComponents(serviceImpl);

            return pipelines;
        }

        private static void RegisterCoreComponents(AutofacNancyLogServiceCollection serviceImpl) {
            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();
        }

        private static void RegisterEnricherComponents(AutofacNancyLogServiceCollection serviceImpl) {
            serviceImpl.ActiveLogEventEnrichers();
        }

        private static void UpdateAutofacContainer(ILifetimeScope container, AutofacNancyLogServiceCollection serviceImpl) {
            container.Update(builder => {
                builder.Populate(serviceImpl.ExposeServices());
                builder.RegisterType<NancyLoggingServiceProvider>().As<ILoggingServiceProvider>().SingleInstance();
                builder.RegisterType<ShortcutPropertyFactoryAccessor>().As<IPropertyFactoryAccessor>().SingleInstance();
                builder.RegisterTraceIdGenerator();
                builder.RegisterInstance(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings()));
                builder.RegisterInstance(serviceImpl.ExposeLoggingConfiguration());
            });
        }

        private static void RegisterTraceIdGenerator(this ContainerBuilder builder) {
            builder.RegisterType<FallbackTraceIdAccessor>().As<FallbackTraceIdAccessor>().InstancePerRequest();
            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                builder.Register(__traceIdGeneratorFactory).As<ILogTraceIdGenerator>().InstancePerRequest();
                ExpectedTraceIdGeneratorName.Value = nameof(SystemTraceIdGenerator);
            }
            
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

        private static void UpdateStaticProvider(ILifetimeScope container) {
            StaticServiceResolver.SetResolver(container.Resolve<ILoggingServiceProvider>());
        }
    }
}