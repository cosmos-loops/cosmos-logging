using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving {
    public interface IScalarResolveRule {
        bool TryResolve(object value, out MessagePropertyValue result);
    }
}