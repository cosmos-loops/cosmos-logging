using System;
using System.Web;
using Cosmos.IdUtils;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNet;
using Cosmos.Logging.RunsOn.AspNet.Core;
using Cosmos.Logging.RunsOn.AspNet.Core.Handlers;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for ASP.NET MVC
    /// </summary>
    public static class AspNetMvcExtensions {
        /// <summary>
        /// Register Cosmos Logging
        /// </summary>
        /// <param name="application"></param>
        /// <param name="config"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RegisterCosmosLogging(this HttpApplication application, Action<ILogServiceCollection> config = null) {
            if (application == null) throw new ArgumentNullException(nameof(application));
            var serviceImpl = new AspNetLogServiceCollection();

            config?.Invoke(serviceImpl);

            RegisterCoreComponents(serviceImpl);

            BuildSoloContainer(serviceImpl);

            RegisterEnricherComponents(serviceImpl);

            UpdateStaticProvider();
        }

        private static void RegisterCoreComponents(AspNetLogServiceCollection serviceImpl) {
            serviceImpl.AddDependency(s => s.AddSingleton<ILoggingServiceProvider, AspNetLoggingServiceProvider>());
            serviceImpl.AddDependency(s => s.AddSingleton<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>());
            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();
            serviceImpl.RegisterTraceIdGenerator();
            serviceImpl.AddDependency(s => s.AddSingleton(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings())));
            serviceImpl.AddDependency(s => s.AddSingleton(serviceImpl.ExposeLoggingConfiguration()));
        }

        private static void RegisterTraceIdGenerator(this AspNetLogServiceCollection serviceImpl) {
            serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Scoped<FallbackTraceIdAccessor, FallbackTraceIdAccessor>()));

            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                serviceImpl.AddDependency(s => s.TryAdd(ServiceDescriptor.Scoped(__traceIdGeneratorFactory)));
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

        private static void RegisterEnricherComponents(AspNetLogServiceCollection serviceImpl) {
            serviceImpl.ActiveLogEventEnrichers();
        }

        private static void BuildSoloContainer(ILogServiceCollection serviceImpl) {
            SoloDependencyContainer.ServiceResolver = serviceImpl.ExposeServices().BuildServiceProvider();
        }

        private static void UpdateStaticProvider() {
            StaticServiceResolver.SetResolver(SoloDependencyContainer.ServiceResolver.GetRequiredService<ILoggingServiceProvider>());
        }

        /// <summary>
        /// Register on error
        /// </summary>
        /// <param name="application"></param>
        public static void RegisterOnError(this HttpApplication application) {
            InternalServerErrorLoggingHandler.Handle(application);
        }

        /// <summary>
        /// Register on begin
        /// </summary>
        /// <param name="application"></param>
        public static void RegisterOnBegin(this HttpApplication application) {
            MvcTraceLoggingHandler.OnStartHandle(application);
        }

        /// <summary>
        /// Register on end
        /// </summary>
        /// <param name="application"></param>
        public static void RegisterOnEnd(this HttpApplication application) {
            MvcTraceLoggingHandler.OnEndHandle(application);
        }
    }
}