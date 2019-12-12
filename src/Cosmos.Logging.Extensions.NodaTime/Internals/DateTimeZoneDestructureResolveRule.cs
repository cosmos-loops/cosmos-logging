using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Events;
using NodaTime;

namespace Cosmos.Logging.Extensions.NodaTime.Internals {
    internal sealed class DateTimeZoneDestructureResolveRule : IDestructureResolveRule {
        public bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result) {
            if (value is DateTimeZone dtz) {
                result = nest.CreatePropertyValue(dtz.Id, PropertyResolvingMode.Destructure);
                return true;
            }
            else {
                result = null;
                return false;
            }
        }
    }
}