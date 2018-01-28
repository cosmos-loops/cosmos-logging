using Cosmos.Logging.Filters;
using Cosmos.Logging.Filters.Navigators;

namespace Cosmos.Logging.Core {
    public interface INamespaceNavigationMatcher {
        bool Match(string @namespace, out EndValueNamespaceNavigationNode value);
    }
}