using System;
using Cosmos.Extensions.Dependency.Core;

namespace Cosmos.Logging.Core.Components {
    /// <summary>
    /// Components registration
    /// </summary>
    public class ComponentsRegistration {
        /// <summary>
        /// Create a new instance of <see cref="ComponentsRegistration"/>.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="many"></param>
        /// <param name="lifetime"></param>
        public ComponentsRegistration(Type serviceType, Many many, DependencyLifetimeType lifetime) {
            ServiceType = serviceType;
            Many = many;
            Lifetime = lifetime;
        }

        /// <summary>
        /// Service type
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Many or not
        /// </summary>
        public Many Many { get; set; }

        /// <summary>
        /// Lifetime
        /// </summary>
        public DependencyLifetimeType Lifetime { get; set; }

        /// <summary>
        /// Can unidirectional transfer or not.
        /// </summary>
        public bool CanUnidirectionalTransfer { get; set; } = true;
    }
}