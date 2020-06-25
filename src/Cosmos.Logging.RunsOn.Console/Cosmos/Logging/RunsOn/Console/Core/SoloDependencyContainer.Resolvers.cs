using System;
using AspectCore.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static partial class SoloDependencyContainer {
        public static IServiceProvider GetServiceResolver() => ServiceResolver ?? throw new NullReferenceException(nameof(ServiceResolver));

        public static IServiceProvider GetScopedServiceResolver() => ServiceResolver.CreateScope();
    }
}