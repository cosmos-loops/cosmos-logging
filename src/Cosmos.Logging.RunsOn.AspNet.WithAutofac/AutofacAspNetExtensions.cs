using System;
using System.Web;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNet;
using Cosmos.Logging.RunsOn.AspNet.WithAutofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SoloDependencyContainer = Cosmos.Logging.RunsOn.AspNet.WithAutofac.Core.SoloDependencyContainer;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class AutofacAspNetExtensions {
        public static ContainerBuilder RegisterCosmosLogging(this ContainerBuilder builder, HttpApplication application, Action<ILogServiceCollection> config = null) {
            RegisterCosmosLoggingCore(application, builder, config);
            return builder;
        }

        public static void RegisterCosmosLogging(this HttpApplication application, ContainerBuilder builder, Action<ILogServiceCollection> config = null) {
            RegisterCosmosLoggingCore(application, builder, config);
        }

        private static void RegisterCosmosLoggingCore(HttpApplication application, ContainerBuilder builder, Action<ILogServiceCollection> config = null) {
            if (application == null) throw new ArgumentNullException(nameof(application));
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var serviceImpl = new AutofacAspNetServiceCollection();

            config?.Invoke(serviceImpl);

            RegisterCoreComponents(serviceImpl);

            UpdateAutofacContainer(builder, serviceImpl);

            builder.RegisterBuildCallback(c => serviceImpl.ActiveLogEventEnrichers());
        }

        private static void RegisterCoreComponents(AutofacAspNetServiceCollection serviceImpl) {
            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();
            serviceImpl.AddDependency(s => s.AddSingleton(provider => new StaticServiceResolveInitialization(provider.GetRequiredService<ILoggingServiceProvider>())));
        }

        private static void UpdateAutofacContainer(ContainerBuilder builder, AutofacAspNetServiceCollection serviceImpl) {
            builder.Populate(serviceImpl.ExposeServices());
            builder.RegisterType<AspNetLoggingServiceProvider>().As<ILoggingServiceProvider>().SingleInstance();
            builder.RegisterType<ShortcutPropertyFactoryAccessor>().As<IPropertyFactoryAccessor>().SingleInstance();
            builder.RegisterInstance(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings()));
            builder.RegisterInstance(serviceImpl.ExposeLoggingConfiguration());
        }
    }
}