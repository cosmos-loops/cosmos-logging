using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Core.Components {
    /// <summary>
    /// Sink components types
    /// </summary>
    public static class SinkComponentsTypes {
        // ReSharper disable once InconsistentNaming
        private static readonly List<ComponentsRegistration> _appends;

        static SinkComponentsTypes() {
            _appends = new List<ComponentsRegistration>();
        }

        /// <summary>
        /// Apends
        /// </summary>
        public static IReadOnlyList<ComponentsRegistration> Appends => _appends;

        /// <summary>
        /// Safe append type
        /// </summary>
        /// <param name="registration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SafeAddAppendType(ComponentsRegistration registration) {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            if (_appends.Any(x => x.ServiceType == registration.ServiceType)) return;
            _appends.Add(registration);
        }
    }
}