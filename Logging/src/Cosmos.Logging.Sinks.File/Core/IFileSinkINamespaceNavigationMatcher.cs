using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Filters.Navigators;

namespace Cosmos.Logging.Sinks.File.Core {
    public interface IFileSinkINamespaceNavigationMatcher {
        bool Match(string @namespace, out IEnumerable<EndValueNamespaceNavigationNode> valueList);
    }
}