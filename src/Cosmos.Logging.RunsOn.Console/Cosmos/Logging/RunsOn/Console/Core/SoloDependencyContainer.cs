using System;
using AspectCore.DependencyInjection;
using AspectCore.Extensions.DependencyInjection;
using Cosmos.Extensions.Dependency;
using Cosmos.IdUtils;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static partial class SoloDependencyContainer {
        private static IServiceResolver ServiceResolver { get; set; }

        internal static void AllDone(ILogServiceCollection services) {
            if (services is ConsoleLogServiceCollection loggingServices) {

                using (loggingServices) {

                    loggingServices.ActiveConsolePreferencesRenderers();

                    loggingServices.RegisterCoreComponents();

                    loggingServices.BuildAndActiveConfiguration();

                    loggingServices.AddTraceIdGenerator();

                }

                ServiceResolver = loggingServices.OriginalServices.ToServiceContext().Build();

                loggingServices.ActiveLogEventEnrichers();

                StaticServiceResolver.SetResolver(ServiceResolver.ResolveRequired<ILoggingServiceProvider>());

            } else {

                throw new ArgumentException(nameof(services));

            }
        }

        private static void RegisterCoreComponents(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddSingleton<ILoggingServiceProvider, ConsoleLoggingServiceProvider>());
            services.AddDependency(s => s.TryAddSingleton<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>());
        }

        private static void BuildAndActiveConfiguration(this ConsoleLogServiceCollection services) {
            services.BuildConfiguration();
            services.ActiveSinkSettings();
            services.ActiveOriginConfiguration();

            services.AddDependency(s => s.TryAddSingleton(Options.Create((LoggingOptions) services.ExposeLogSettings())));
            services.AddDependency(s => s.TryAddSingleton(services.ExposeLoggingConfiguration()));

        }

        private static void AddTraceIdGenerator(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddScoped<FallbackTraceIdAccessor, FallbackTraceIdAccessor>());
            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                services.AddDependency(s => s.TryAddScoped<ILogTraceIdGenerator, IServiceProvider>(__traceIdGeneratorFactory));
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
    }
}