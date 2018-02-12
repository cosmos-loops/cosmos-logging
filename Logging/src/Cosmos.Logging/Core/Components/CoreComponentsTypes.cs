using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Core.Components {
    public static class CoreComponentsTypes {
        // ReSharper disable once InconsistentNaming
        private static readonly ComponentsRegistration[] _default;

        static CoreComponentsTypes() {
            _default = new[] {
                new ComponentsRegistration(typeof(ILoggingServiceProvider), false, ServiceLifetime.Singleton),
                new ComponentsRegistration(typeof(ILogPayloadClientProvider), true, ServiceLifetime.Singleton),
                new ComponentsRegistration(typeof(ILogPayloadClient), true, ServiceLifetime.Scoped) {CanUnidirectionalTransfer = false},
                new ComponentsRegistration(typeof(LoggingConfiguration), false, ServiceLifetime.Singleton),
                new ComponentsRegistration(typeof(IOptions<LoggingOptions>), false, ServiceLifetime.Singleton)
            };
        }

        public static ComponentsRegistration[] Defaults => _default;

        public static ComponentsRegistration[] Appends => SinkComponentsTypes.Appends.ToArray();
    }
}