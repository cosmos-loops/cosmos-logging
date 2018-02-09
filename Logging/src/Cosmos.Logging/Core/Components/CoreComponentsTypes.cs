using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Core.Components {
    public static class CoreComponentsTypes {
        public static ComponentsRegistration[] Defaults = {
            new ComponentsRegistration(typeof(ILoggingServiceProvider), false, ServiceLifetime.Singleton),
            new ComponentsRegistration(typeof(ILogPayloadClientProvider), true, ServiceLifetime.Singleton),
            new ComponentsRegistration(typeof(ILogPayloadClient), true, ServiceLifetime.Scoped) {CanUnidirectionalTransfer = false},
            new ComponentsRegistration(typeof(LoggingConfiguration), false, ServiceLifetime.Singleton),
            new ComponentsRegistration(typeof(IOptions<LoggingOptions>), false, ServiceLifetime.Singleton)
        };

        public static List<ComponentsRegistration> Appends { get; } = new List<ComponentsRegistration>();

        public static void SafeAddAppendType(ComponentsRegistration registration) {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            if (Appends.Any(x => x.ServiceType == registration.ServiceType)) return;
            Appends.Add(registration);
        }
    }
}