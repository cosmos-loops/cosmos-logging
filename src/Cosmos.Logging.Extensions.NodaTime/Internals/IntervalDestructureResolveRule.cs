using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Events;
using NodaTime;

namespace Cosmos.Logging.Extensions.NodaTime.Internals {
    internal sealed class IntervalDestructureResolveRule : IDestructureResolveRule {
        public bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result) {
            if (value is Interval interval) {
                if (interval.HasStart) {
                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                    if (interval.HasEnd) {
                        // start and end
                        result = nest.CreatePropertyValue(new {interval.Start, interval.End}, PropertyResolvingMode.Destructure);
                    }
                    else {
                        // start only
                        result = nest.CreatePropertyValue(new {interval.Start}, PropertyResolvingMode.Destructure);
                    }
                }
                else if (interval.HasEnd) {
                    // end only
                    result = nest.CreatePropertyValue(new {interval.End}, PropertyResolvingMode.Destructure);
                }
                else {
                    // neither
                    result = new StructureValue(new MessageProperty[0]);
                }

                return true;
            }

            result = null;
            return false;
        }
    }
}