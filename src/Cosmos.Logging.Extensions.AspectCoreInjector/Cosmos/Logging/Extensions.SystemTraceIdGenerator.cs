using System;
using AspectCore.DependencyInjection;
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
        /// Register System TraceId generator for NCC AspectCore
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection RegisterSystemTraceIdGenerator(this ILogServiceCollection services) {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                services.AddDependency(s => s.AddScoped<ILogTraceIdGenerator, IServiceResolver>(__traceIdGeneratorFactory));
                ExpectedTraceIdGeneratorName.Value = nameof(SystemTraceIdGenerator);
            }

            // ReSharper disable once InconsistentNaming
            ILogTraceIdGenerator __traceIdGeneratorFactory(IServiceResolver provider) {
                //1. Get traceIdAccessor and fallbackTraceIdAccessor from ServiceProvider
                var traceIdAccessor = provider.Resolve<TraceIdAccessor>();
                var fallbackAccessor = provider.ResolveRequired<FallbackTraceIdAccessor>();

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