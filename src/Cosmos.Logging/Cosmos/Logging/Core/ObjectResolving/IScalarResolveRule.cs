using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving {
    /// <summary>
    /// Interface for scalar resolve rule
    /// </summary>
    public interface IScalarResolveRule {
        bool TryResolve(object value, out MessagePropertyValue result);
    }
}