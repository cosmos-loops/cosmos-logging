using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Core.Components {
    public static class CoreComponentsTypes {
        private static readonly ComponentsRegistration[] _default;
        private static readonly List<ComponentsRegistration> _appends;

        static CoreComponentsTypes() {
            _default = new[] {
                new ComponentsRegistration(typeof(ILoggingServiceProvider), false, ServiceLifetime.Singleton),
                new ComponentsRegistration(typeof(ILogPayloadClientProvider), true, ServiceLifetime.Singleton),
                new ComponentsRegistration(typeof(ILogPayloadClient), true, ServiceLifetime.Scoped) {CanUnidirectionalTransfer = false},
                new ComponentsRegistration(typeof(LoggingConfiguration), false, ServiceLifetime.Singleton),
                new ComponentsRegistration(typeof(IOptions<LoggingOptions>), false, ServiceLifetime.Singleton)
            };
            _appends = new List<ComponentsRegistration>();
        }

        public static ComponentsRegistration[] Defaults => _default;

        public static List<ComponentsRegistration> Appends => _appends;

        public static void SafeAddAppendType(ComponentsRegistration registration) {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            if (_appends.Any(x => x.ServiceType == registration.ServiceType)) return;
            _appends.Add(registration);
        }
    }
}