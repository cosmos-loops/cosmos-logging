using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.Core.Components {
    public class ComponentsRegistration {
        public ComponentsRegistration(Type serviceType, bool many, ServiceLifetime lifetime) {
            ServiceType = serviceType;
            Many = many;
            Lifetime = lifetime;
        }

        public Type ServiceType { get; set; }
        public bool Many { get; set; }
        public ServiceLifetime Lifetime { get; set; }
        public bool CanUnidirectionalTransfer { get; set; } = true;
    }
}