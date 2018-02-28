using System;
using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    public class NamespaceNavigatorCache : IFileSinkNamespaceNavigationParser, IFileSinkINamespaceNavigationMatcher {
        private readonly IFileSinkNamespaceNavigationParser _namespaceNavigationParser;
        private readonly RootNamespaceNavigation _root;

        public NamespaceNavigatorCache(IFileSinkNamespaceNavigationParser namespaceNavigationParser) {
            _namespaceNavigationParser = namespaceNavigationParser ?? throw new ArgumentNullException(nameof(namespaceNavigationParser));
            _root = RootNamespaceNavigation.GetInstance();
        }

        public void Parse(OutputOptions options, out EndValueNamespaceNavigationNode endValueNode) {
            _namespaceNavigationParser.Parse(options, out endValueNode);
        }

        public bool Match(string @namespace, out IEnumerable<EndValueNamespaceNavigationNode> valueList) {
            return NamespaceNavigationMatcher.Match(@namespace, out valueList);
        }

        public RootNamespaceNavigation Root => _root;
    }
}