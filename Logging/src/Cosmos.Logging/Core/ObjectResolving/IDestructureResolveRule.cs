using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving {
    public interface IDestructureResolveRule {
        bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result);
    }
}