using Cosmos.Extensions.Dependency;
using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.AspNetCore;
using Cosmos.Logging.Trace;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Extensions for Service collection
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Register Microsoft ASP.NET Core Trace Id generator
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ILogServiceCollection RegisterAspNetCoreTraceIdGenerator(this ILogServiceCollection services) {

            if (!ExpectedTraceIdGeneratorName.HasValue()) {
                services.AddDependency(s => s.AddScoped<ILogTraceIdGenerator, AspNetCoreTraceIdGenerator>());
                ExpectedTraceIdGeneratorName.Value = nameof(AspNetCoreTraceIdGenerator);
            }

            return services;
        }
    }
}