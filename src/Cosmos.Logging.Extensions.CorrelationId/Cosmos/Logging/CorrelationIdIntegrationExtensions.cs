using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.CorrelationId;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for correlation id integration
    /// </summary>
    public static class CorrelationIdIntegrationExtensions {
        /// <summary>
        /// Add CorrelationId Integration
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection AddCorrelationIdIntegration(this ILogServiceCollection service) {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            service.AddDependency(s => s.TryAdd(ServiceDescriptor.Scoped<ILogTraceIdGenerator, CorrelationIdGenerator>()));
            ExpectedTraceIdGeneratorName.Value = nameof(CorrelationIdGenerator);

            return service;
        }
    }
}