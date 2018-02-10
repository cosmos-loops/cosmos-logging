using System;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.NancyFX;
using Cosmos.Logging.RunsOn.NancyFX.Core;
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

            return pipelines;
        }

        private static void RegisterCoreComponents(AutofacNancyLogServiceCollection serviceImpl) {
            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();
            serviceImpl.ActiveNancyPreferencesRenderers();
        }

        private static void UpdateAutofacContainer(ILifetimeScope container, AutofacNancyLogServiceCollection serviceImpl) {
            container.Update(builder => {
                builder.Populate(serviceImpl.ExposeServices());
                builder.RegisterType<NancyLoggingServiceProvider>().As<ILoggingServiceProvider>().SingleInstance();
                builder.RegisterInstance(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings()));
                builder.RegisterInstance(serviceImpl.ExposeLoggingConfiguration());
            });
        }

        private static void UpdateStaticProvider(ILifetimeScope container) {
            StaticInstanceOfLoggingServiceProvider.SetInstance(container.Resolve<ILoggingServiceProvider>());
        }
    }
}