using System;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static class IocContainer {
        private static IServiceResolver ServiceResolver { get; set; }

        public static ILogServiceCollection Initialize() {
            return Initialize(new ServiceCollection(), (IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services) {
            return Initialize(services, (IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services, IConfigurationBuilder builder) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            return builder == null
                ? new ConsoleLogServiceCollection(services)
                : new ConsoleLogServiceCollection(services, builder);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services, IConfigurationRoot root) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            return root == null
                ? new ConsoleLogServiceCollection(services)
                : new ConsoleLogServiceCollection(services, root);
        }

        internal static void AllDone(ILogServiceCollection services) {
            if (services is ConsoleLogServiceCollection servicesImpl) {
                servicesImpl.BuildConfiguration();
                servicesImpl.ActiveSinkSettings();
                servicesImpl.ActiveOriginConfiguration();
                servicesImpl.ActiveConsolePreferencesRenders();
                servicesImpl.AddDependency(s => s.AddSingleton(Options.Create((LoggingSettings) servicesImpl.ExposeLogSettings())));
                servicesImpl.AddDependency(s => s.AddSingleton(servicesImpl.ExposeLoggingConfiguration()));
                ServiceResolver = servicesImpl.ExposeServices().ToServiceContainer().Build();
            } else {
                throw new ArgumentException(nameof(services));
            }
        }

        public static IServiceProvider GetServiceResolver() => ServiceResolver ?? throw new NullReferenceException(nameof(ServiceResolver));

        public static IServiceProvider GetScopedServiceResolver() => ServiceResolver.CreateScope();
    }
}