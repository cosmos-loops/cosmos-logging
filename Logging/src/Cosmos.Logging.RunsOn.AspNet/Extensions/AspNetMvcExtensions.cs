using System;
using System.Web;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNet;
using Cosmos.Logging.RunsOn.AspNet.Core;
using Cosmos.Logging.RunsOn.AspNet.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class AspNetMvcExtensions {
        public static void RegisterCosmosLogging(this HttpApplication application, Action<ILogServiceCollection> config = null) {
            if (application == null) throw new ArgumentNullException(nameof(application));
            var serviceImpl = new AspNetLogServiceCollection();

            config?.Invoke(serviceImpl);

            RegisterCoreComponents(serviceImpl);

            BuildSoloContainer(serviceImpl);

            UpdateStaticProvider();
        }

        private static void RegisterCoreComponents(AspNetLogServiceCollection serviceImpl) {
            serviceImpl.AddDependency(s => s.AddSingleton<ILoggingServiceProvider, AspNetLoggingServiceProvider>());
            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();
            serviceImpl.ActiveAspNetPreferencesRenderers();
            serviceImpl.AddDependency(s => s.AddSingleton(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings())));
            serviceImpl.AddDependency(s => s.AddSingleton(serviceImpl.ExposeLoggingConfiguration()));
        }

        private static void BuildSoloContainer(ILogServiceCollection serviceImpl) {
            AspNetContainerSolo.ServiceProvider = serviceImpl.ExposeServices().BuildServiceProvider();
        }

        private static void UpdateStaticProvider() {
            StaticInstanceOfLoggingServiceProvider.SetInstance(AspNetContainerSolo.ServiceProvider.GetRequiredService<ILoggingServiceProvider>());
        }

        public static void RegisterOnError(this HttpApplication application) {
            InternalServerErrorLoggingHandler.Handle(application);
        }

        public static void RegisterOnBegin(this HttpApplication application) {
            MvcTraceLoggingHandler.OnStartHandle(application);
        }

        public static void RegisterOnEnd(this HttpApplication application) {
            MvcTraceLoggingHandler.OnEndHandle(application);
        }
    }
}