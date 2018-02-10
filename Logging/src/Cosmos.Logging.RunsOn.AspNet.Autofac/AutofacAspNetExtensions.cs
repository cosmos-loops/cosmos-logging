using System;
using System.Web;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNet;
using Cosmos.Logging.RunsOn.AspNet.Autofac;
using Cosmos.Logging.RunsOn.AspNet.Autofac.Core;
using Cosmos.Logging.RunsOn.AspNet.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class AutofacAspNetExtensions {
        public static void RegisterCosmosLogging(this HttpApplication application, ContainerBuilder builder, Action<ILogServiceCollection> config = null) {
            if (application == null) throw new ArgumentNullException(nameof(application));
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var serviceImpl = new AutofacAspNetServiceCollection();

            config?.Invoke(serviceImpl);

            RegisterCoreComponents(serviceImpl);

            UpdateAutofacContainer(builder, serviceImpl);
        }

        private static void RegisterCoreComponents(AutofacAspNetServiceCollection serviceImpl) {
            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();
            serviceImpl.ActiveAspNetPreferencesRenderers();
            serviceImpl.AddDependency(s => s.AddSingleton(provider => new StaticProviderHack(provider.GetRequiredService<ILoggingServiceProvider>())));
        }

        private static void UpdateAutofacContainer(ContainerBuilder builder, AutofacAspNetServiceCollection serviceImpl) {
            builder.Populate(serviceImpl.ExposeServices());
            builder.RegisterType<AspNetLoggingServiceProvider>().As<ILoggingServiceProvider>().SingleInstance();
            builder.RegisterInstance(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings()));
            builder.RegisterInstance(serviceImpl.ExposeLoggingConfiguration());
        }
    }
}