using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core.Extensions;
using Cosmos.Logging.Sinks.File.Filters.Navigators;

namespace Cosmos.Logging.Sinks.File.Filters {
    internal static class NavigationFilterProcessor {
        private static readonly RootNamespaceNavigation _root;
        private static readonly NamespaceNavigatorCache _cache;
        private static readonly Dictionary<int, OutputOptions> _optionsesCache;
        private static readonly Dictionary<int, EndValueNamespaceNavigationNode> _valueIndexedByRuleNameCache;

        static NavigationFilterProcessor() {
            _root = RootNamespaceNavigation.GetInstance();
            _cache = new NamespaceNavigatorCache(new NamespaceNavigationParser());
            _optionsesCache = new Dictionary<int, OutputOptions>();
            _valueIndexedByRuleNameCache = new Dictionary<int, EndValueNamespaceNavigationNode>();
        }

        internal static void SetOutputOption(string ruleName, OutputOptions options, string basePath) {
            if (!string.IsNullOrWhiteSpace(ruleName) &&
                !_optionsesCache.ContainsKey(ruleName.GetHashCode()) &&
                options.IsValid()) {
                _cache.Parse(basePath, options, out var value);
                _optionsesCache.Add(ruleName.GetHashCode(), options);
                _valueIndexedByRuleNameCache.Add(ruleName.GetHashCode(), value);
            }
        }

        public static IEnumerable<EndValueNamespaceNavigationNode> GetValues(string @namespace) {
            return _cache.Match(@namespace, out var ret) ? ret : null;
        }
    }
}