using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core.Extensions;
using Cosmos.Logging.Sinks.File.Filters.Navigators;

namespace Cosmos.Logging.Sinks.File.Filters {
    internal static class NavigationFilterProcessor {
        private static readonly RootNamespaceNavigation _root;
        private static readonly NamespaceNavigatorCache _cache;

        static NavigationFilterProcessor() {
            _root = RootNamespaceNavigation.GetInstance();
            _cache = new NamespaceNavigatorCache(new NamespaceNavigationParser());
        }

        internal static void SetOutputOption(OutputOptions options) {
            if (options.IsValid()) {
                _cache.Parse(options, out var value);
            }
        }

        public static IEnumerable<EndValueNamespaceNavigationNode> GetValues(string @namespace) {
            return _cache.Match(@namespace, out var ret) ? ret : null;
        }
    }
}