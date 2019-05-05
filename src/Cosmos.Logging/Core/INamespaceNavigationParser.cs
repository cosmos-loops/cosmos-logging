using Cosmos.Logging.Filters.Navigators;

namespace Cosmos.Logging.Core {
    public interface INamespaceNavigationParser {
        NamespaceNavigator Parse(string @namespace, string level, out EndValueNamespaceNavigationNode endValueNode);
    }
}