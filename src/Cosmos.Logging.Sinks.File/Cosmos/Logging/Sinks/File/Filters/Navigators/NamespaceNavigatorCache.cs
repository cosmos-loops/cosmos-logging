using System;
using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    /// <summary>
    /// Namespace navigator cache
    /// </summary>
    public class NamespaceNavigatorCache : IFileSinkNamespaceNavigationParser, IFileSinkNamespaceNavigationMatcher {
        private readonly IFileSinkNamespaceNavigationParser _namespaceNavigationParser;
        private readonly RootNamespaceNavigation _root;

        /// <summary>
        /// Create a new instance of <see cref="NamespaceNavigatorCache"/>
        /// </summary>
        /// <param name="namespaceNavigationParser"></param>
        public NamespaceNavigatorCache(IFileSinkNamespaceNavigationParser namespaceNavigationParser) {
            _namespaceNavigationParser = namespaceNavigationParser ?? throw new ArgumentNullException(nameof(namespaceNavigationParser));
            _root = RootNamespaceNavigation.GetInstance();
        }

        /// <inheritdoc />
        public void Parse(string basePath, OutputOptions options, out EndValueNamespaceNavigationNode endValueNode) {
            _namespaceNavigationParser.Parse(basePath, options, out endValueNode);
        }

        /// <inheritdoc />
        public bool Match(string @namespace, out IEnumerable<EndValueNamespaceNavigationNode> valueList) {
            return NamespaceNavigationMatcher.Match(@namespace, out valueList);
        }

        /// <summary>
        /// Gets root node
        /// </summary>
        public RootNamespaceNavigation Root => _root;
    }
}