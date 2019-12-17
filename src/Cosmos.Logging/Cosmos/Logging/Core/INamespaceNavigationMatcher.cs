using Cosmos.Logging.Filters.Navigators;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for Namespace Navigation matcher
    /// </summary>
    public interface INamespaceNavigationMatcher {
        /// <summary>
        /// Match
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Match(string @namespace, out EndValueNamespaceNavigationNode value);
    }
}