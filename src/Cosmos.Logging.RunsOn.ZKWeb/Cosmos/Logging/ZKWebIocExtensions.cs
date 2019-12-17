using System;
using Cosmos.IdUtils;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.ZKWeb;
using Cosmos.Logging.RunsOn.ZKWeb.Core;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.Options;
using ZKWebStandard.Ioc;
using ZKWebStandard.Ioc.Extensions;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for ZKWeb IOC 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class ZKWebIocExtensions {

        /// <summary>
        /// Register Cosmos Logging to ZKWeb IOC
        /// </summary>
        /// <param name="ioc"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IContainer RegisterCosmosLogging(this IContainer ioc, Action<ILogServiceCollection> config) {
            var serviceImpl = new ZkWebLogServiceCollection();

            config?.Invoke(serviceImpl);

            ioc.Register<ILoggingServiceProvider, ZKWebLoggingServiceProvider>(ReuseType.Singleton);
            ioc.Register<IPropertyFactoryAccessor, ShortcutPropertyFactoryAccessor>();

            serviceImpl.BuildConfiguration();
            serviceImpl.ActiveSinkSettings();
            serviceImpl.ActiveOriginConfiguration();

            ioc.RegisterFromServiceCollection(serviceImpl.ExposeServices());
            ioc.RegisterTraceIdGenerator();
            ioc.RegisterInstance(Options.Create((LoggingOptions) serviceImpl.ExposeLogSettings()), ReuseType.Singleton);
            ioc.RegisterInstance(serviceImpl.ExposeLoggingConfiguration(), ReuseType.Singleton);

            StaticServiceResolver.SetResolver(ioc.Resolve<ILoggingServiceProvider>());

            serviceImpl.ActiveLogEventEnrichers();

            return ioc;
        }

        private static void RegisterTraceIdGenerator(this IContainer ioc) {
            ioc.Register<FallbackTraceIdAccessor, FallbackTraceIdAccessor>(ReuseType.Scoped);
            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                ioc.RegisterDelegate(typeof(ILogTraceIdGenerator), () => __traceIdGeneratorFactory(ioc), ReuseType.Scoped);
                ExpectedTraceIdGeneratorName.Value = nameof(SystemTraceIdGenerator);
            }

            ILogTraceIdGenerator __traceIdGeneratorFactory(IContainer provider) {
                //1. Get traceIdAccessor and fallbackTraceIdAccessor from ServiceProvider
                var traceIdAccessor = provider.Resolve<TraceIdAccessor>(IfUnresolved.ReturnDefault);
                var fallbackAccessor = provider.Resolve<FallbackTraceIdAccessor>();

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