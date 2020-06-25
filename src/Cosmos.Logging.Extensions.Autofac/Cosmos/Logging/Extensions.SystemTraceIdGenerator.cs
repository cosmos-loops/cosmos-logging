using System;
using Autofac;
using Cosmos.Extensions.Dependency;
using Cosmos.IdUtils;
using Cosmos.Logging.Core;
using Cosmos.Logging.Trace;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for trace id generator
    /// </summary>
    public static class TraceIdGeneratorExtensions {
        /// <summary>
        /// Register System TraceId generator for Autofac
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection RegisterSystemTraceIdGenerator(this ILogServiceCollection services) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                services.AddDependency(s => s.AddScoped<ILogTraceIdGenerator, IComponentContext>(__traceIdGeneratorFactory));
                ExpectedTraceIdGeneratorName.Value = nameof(SystemTraceIdGenerator);
            }

            // ReSharper disable once InconsistentNaming
            ILogTraceIdGenerator __traceIdGeneratorFactory(IComponentContext provider) {
                //1. Get traceIdAccessor and fallbackTraceIdAccessor from ServiceProvider
                var traceIdAccessor = provider.ResolveOptional<TraceIdAccessor>();
                var fallbackAccessor = provider.Resolve<FallbackTraceIdAccessor>();

                //2. Create a new instance of SystemTraceIdGenerator
                var generator = new SystemTraceIdGenerator(traceIdAccessor, fallbackAccessor);

                //3. Scoped update
                LogTraceIdGenerator.ScopedUpdate(generator);

                //4. Done, and return.
                return generator;
            }

            return services;
        }
    }
}