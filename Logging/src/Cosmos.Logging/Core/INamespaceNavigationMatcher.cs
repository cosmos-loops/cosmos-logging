using Cosmos.Logging.Filters;

namespace Cosmos.Logging.Core {
    public interface INamespaceNavigationMatcher {
        bool Match(string @namespace, out EndValueNamespaceNavigationNode value);
    }
}