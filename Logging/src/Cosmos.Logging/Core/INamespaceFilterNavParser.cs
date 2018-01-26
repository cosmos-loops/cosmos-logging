using Cosmos.Logging.Filters;

namespace Cosmos.Logging.Core {
    public interface INamespaceFilterNavParser {
        NamespaceFilterNav Parse(string @namespace, string level);
    }
}