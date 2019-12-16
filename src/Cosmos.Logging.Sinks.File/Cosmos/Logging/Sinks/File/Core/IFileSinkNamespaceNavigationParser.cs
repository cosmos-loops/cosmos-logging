using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Filters.Navigators;

namespace Cosmos.Logging.Sinks.File.Core {
    /// <summary>
    /// Interface for file sink namespace navigation parser
    /// </summary>
    public interface IFileSinkNamespaceNavigationParser {
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="options"></param>
        /// <param name="endValueNode"></param>
        void Parse(string basePath, OutputOptions options, out EndValueNamespaceNavigationNode endValueNode);
    }
}