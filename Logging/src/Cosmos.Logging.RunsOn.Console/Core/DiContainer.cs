using System;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Cosmos.Logging.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static class DiContainer {
        private static IServiceResolver ServiceResolver { get; set; }

        public static ILogServiceCollection Initialize() {
            return Initialize(new ServiceCollection());
        }

        public static ILogServiceCollection Initialize(IServiceCollection services) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            return new ConsoleLogServiceCollection(services);
        }

        internal static void AllDone(ILogServiceCollection services) {
            if (services is ConsoleLogServiceCollection servicesImpl) {
                servicesImpl.ActiveSinkSettings();
                servicesImpl.AddDependency(s => s.AddSingleton(Options.Create((LoggingSettings) servicesImpl.ExposeLogSettings())));
                ServiceResolver = servicesImpl.ExposeServices().ToServiceContainer().Build();
            }
            else {
                throw new ArgumentException(nameof(services));
            }
        }

        public static IServiceProvider GetServiceResolver() => ServiceResolver ?? throw new NullReferenceException(nameof(ServiceResolver));

        public static IServiceProvider GetScopedServiceResolver() => ServiceResolver.CreateScope();
    }
}