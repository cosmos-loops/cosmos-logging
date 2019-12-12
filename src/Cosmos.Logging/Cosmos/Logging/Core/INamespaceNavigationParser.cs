using Cosmos.Logging.Filters.Navigators;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for namespace navigation parser
    /// </summary>
    public interface INamespaceNavigationParser {
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="level"></param>
        /// <param name="endValueNode"></param>
        /// <returns></returns>
        NamespaceNavigator Parse(string @namespace, string level, out EndValueNamespaceNavigationNode endValueNode);
    }
}