using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Filters.Navigators;

namespace Cosmos.Logging.Sinks.File.Core {
    public interface IFileSinkNamespaceNavigationParser {
        void Parse(string basePath, OutputOptions options, out EndValueNamespaceNavigationNode endValueNode);
    }
}