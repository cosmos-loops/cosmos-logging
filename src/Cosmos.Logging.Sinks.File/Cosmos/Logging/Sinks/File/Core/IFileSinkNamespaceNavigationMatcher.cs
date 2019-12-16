using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Filters.Navigators;

namespace Cosmos.Logging.Sinks.File.Core {
    /// <summary>
    /// Interface for sink sink namespace navigation matcher
    /// </summary>
    public interface IFileSinkNamespaceNavigationMatcher {
        /// <summary>
        /// Match
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="valueList"></param>
        /// <returns></returns>
        bool Match(string @namespace, out IEnumerable<EndValueNamespaceNavigationNode> valueList);
    }
}