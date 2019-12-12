using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Extensions.CorrelationId;
using Cosmos.Logging.Trace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class CorrelationIdIntegrationExtensions {
        public static ILogServiceCollection AddCorrelationIdIntegration(this ILogServiceCollection service) {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            service.AddDependency(s => s.TryAdd(ServiceDescriptor.Scoped<ILogTraceIdGenerator, CorrelationIdGenerator>()));
            ExpectedTraceIdGeneratorName.Value = nameof(CorrelationIdGenerator);

            return service;
        }
    }
}