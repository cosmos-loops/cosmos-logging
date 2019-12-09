using System;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Cosmos.IdUtils;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static class SoloDependencyContainer {
        private static IServiceResolver ServiceResolver { get; set; }

        public static ILogServiceCollection Initialize() {
            return Initialize(new ServiceCollection(), (IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services) {
            return Initialize(services, (IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services, IConfigurationBuilder builder) {
            if (services is null) throw new ArgumentNullException(nameof(services));
            return builder == null
                ? new ConsoleLogServiceCollection(services)
                : new ConsoleLogServiceCollection(services, builder);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services, IConfigurationRoot root) {
            if (services is null) throw new ArgumentNullException(nameof(services));
            return root == null
                ? new ConsoleLogServiceCollection(services)
                : new ConsoleLogServiceCollection(services, root);
        }

        internal static void AllDone(ILogServiceCollection services) {
            if (services is ConsoleLogServiceCollection servicesImpl) {
                servicesImpl.BuildConfiguration();
                servicesImpl.ActiveSinkSettings();
                servicesImpl.ActiveOriginConfiguration();
                servicesImpl.AddTraceIdGenerator();
                servicesImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(Options.Create((LoggingOptions) servicesImpl.ExposeLogSettings()))));
                servicesImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Singleton(servicesImpl.ExposeLoggingConfiguration())));
                ServiceResolver = servicesImpl.ExposeServices().ToServiceContainer().Build();
                servicesImpl.ActiveLogEventEnrichers();
                StaticServiceResolver.SetResolver(ServiceResolver.ResolveRequired<ILoggingServiceProvider>());
            }
            else {
                throw new ArgumentException(nameof(services));
            }
        }

        private static void AddTraceIdGenerator(this ConsoleLogServiceCollection servicesImpl) {
            servicesImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Scoped<FallbackTraceIdAccessor, FallbackTraceIdAccessor>()));
            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                servicesImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Scoped(__traceIdGeneratorFactory)));
                ExpectedTraceIdGeneratorName.Value = nameof(SystemTraceIdGenerator);
            }

            // ReSharper disable once InconsistentNaming
            ILogTraceIdGenerator __traceIdGeneratorFactory(IServiceProvider provider) {
                //1. Get traceIdAccessor and fallbackTraceIdAccessor from ServiceProvider
                var traceIdAccessor = provider.GetService<TraceIdAccessor>();
                var fallbackAccessor = provider.GetRequiredService<FallbackTraceIdAccessor>();

                //2. Create a new instance of SystemTraceIdGenerator
                var generator = new SystemTraceIdGenerator(traceIdAccessor, fallbackAccessor);

                //3. Scoped update
                LogTraceIdGenerator.ScopedUpdate(generator);

                //4. Done, and return.
                return generator;
            }
        }

        public static IServiceProvider GetServiceResolver() => ServiceResolver ?? throw new NullReferenceException(nameof(ServiceResolver));

        public static IServiceProvider GetScopedServiceResolver() => ServiceResolver.CreateScope();
    }
}