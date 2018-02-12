using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Core.Components {
    public static class SinkComponentsTypes {
        // ReSharper disable once InconsistentNaming
        private static readonly List<ComponentsRegistration> _appends;

        static SinkComponentsTypes() {
            _appends = new List<ComponentsRegistration>();
        }

        public static IReadOnlyList<ComponentsRegistration> Appends => _appends;

        public static void SafeAddAppendType(ComponentsRegistration registration) {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            if (_appends.Any(x => x.ServiceType == registration.ServiceType)) return;
            _appends.Add(registration);
        }
    }
}