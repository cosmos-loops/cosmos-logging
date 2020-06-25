using System.Linq;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Core.Components {
    /// <summary>
    /// Core components types
    /// </summary>
    public static class CoreComponentsTypes {
        // ReSharper disable once InconsistentNaming
        private static readonly ComponentsRegistration[] _default;

        static CoreComponentsTypes() {
            _default = new[] {
                new ComponentsRegistration(typeof(ILoggingServiceProvider), Many.FALSE, DependencyLifetimeType.Singleton),
                new ComponentsRegistration(typeof(ILogPayloadClientProvider), Many.TRUE, DependencyLifetimeType.Singleton),
                new ComponentsRegistration(typeof(ILogPayloadClient), Many.TRUE, DependencyLifetimeType.Scoped) {CanUnidirectionalTransfer = false},
                new ComponentsRegistration(typeof(LoggingConfiguration), Many.FALSE, DependencyLifetimeType.Singleton),
                new ComponentsRegistration(typeof(IOptions<LoggingOptions>), Many.FALSE, DependencyLifetimeType.Singleton)
            };
        }

        /// <summary>
        /// Gets default component registrations
        /// </summary>
        public static ComponentsRegistration[] Defaults => _default;

        /// <summary>
        /// Append component registrations
        /// </summary>
        public static ComponentsRegistration[] Appends => SinkComponentsTypes.Appends.ToArray();
    }
}