using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving.Rules {
    internal class EnumResolveRule : IScalarResolveRule {
        public bool TryResolve(object value, out MessagePropertyValue result) {
            result = value.GetType().IsEnum ? new ScalarValue(value) : null;
            return result != null;
        }
    }
}