using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Configurations
{
    public static class DestructureConfigurationExtensions
    {
        public static ILogServiceCollection With<TDestructureResolveRule>(this ILogServiceCollection services)
            where TDestructureResolveRule : class, IDestructureResolveRule, new()
        {
            return services.With(new TDestructureResolveRule());
        }

        public static ILogServiceCollection With(this ILogServiceCollection services, IDestructureResolveRule rule)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (rule == null)
                throw new ArgumentNullException(nameof(rule));

            var configurationPointer = services.ExposeLoggingConfiguration();
            configurationPointer.Destructure.AdditionalDestructureResolveRules.Add(rule);

            return services;
        }

        public static ILogServiceCollection AsScalar<TScalarType>(this ILogServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var configurationPointer = services.ExposeLoggingConfiguration();
            configurationPointer.Destructure.AdditionalScalarTypes.Add(typeof(TScalarType));

            return services;
        }
    }
}