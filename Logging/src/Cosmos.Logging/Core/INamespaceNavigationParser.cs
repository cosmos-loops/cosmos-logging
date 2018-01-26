using Cosmos.Logging.Filters;

namespace Cosmos.Logging.Core {
    public interface INamespaceNavigationParser {
        NamespaceNavigator Parse(string @namespace, string level, out EndValueNamespaceNavigationNode endValueNode);
    }
}