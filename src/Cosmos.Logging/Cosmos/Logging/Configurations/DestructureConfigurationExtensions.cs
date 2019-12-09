using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Extensions for destructure configuration
    /// </summary>
    public static class DestructureConfigurationExtensions {
        /// <summary>
        /// With destructure resolve rule
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="TDestructureResolveRule"></typeparam>
        /// <returns></returns>
        public static ILogServiceCollection With<TDestructureResolveRule>(this ILogServiceCollection services)
            where TDestructureResolveRule : class, IDestructureResolveRule, new() {
            return services.With(new TDestructureResolveRule());
        }

        /// <summary>
        /// With destructure resolve rule
        /// </summary>
        /// <param name="services"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection With(this ILogServiceCollection services, IDestructureResolveRule rule) {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (rule == null)
                throw new ArgumentNullException(nameof(rule));

            var configurationPointer = services.ExposeLoggingConfiguration();
            configurationPointer.Destructure.AdditionalDestructureResolveRules.Add(rule);

            return services;
        }

        /// <summary>
        /// As scalar
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="TScalarType"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection AsScalar<TScalarType>(this ILogServiceCollection services) {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var configurationPointer = services.ExposeLoggingConfiguration();
            configurationPointer.Destructure.AdditionalScalarTypes.Add(typeof(TScalarType));

            return services;
        }
    }
}