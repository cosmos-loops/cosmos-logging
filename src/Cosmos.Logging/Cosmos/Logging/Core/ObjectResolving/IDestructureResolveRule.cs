using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving {
    /// <summary>
    /// Interface for destructure resolve rule
    /// </summary>
    public interface IDestructureResolveRule {
        /// <summary>
        /// Try resolve
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nest"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool TryResolve(object value, IMessagePropertyValueFactory nest, out MessagePropertyValue result);
    }
}