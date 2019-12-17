using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving {
    /// <summary>
    /// Interface for scalar resolve rule
    /// </summary>
    public interface IScalarResolveRule {
        /// <summary>
        /// Try resolve
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool TryResolve(object value, out MessagePropertyValue result);
    }
}