using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    internal static class NamespaceNavigationMatcher {
        public static bool Match(string @namespace, out IEnumerable<EndValueNamespaceNavigationNode> valueList) {
            var root = RootNamespaceNavigation.GetInstance();
            valueList = root.HasAllValue() ? root.GetStarValues() : root.GetDefaultValues();

            if (string.IsNullOrWhiteSpace(@namespace)) return false;
            if (string.Compare(@namespace, "Default", StringComparison.OrdinalIgnoreCase) == 0) return true;

            if (@namespace.IndexOf('.') < 0) {
                valueList = root.GetFirstLevelNavValues(@namespace);
                return valueList != null;
            }

            var nss = @namespace.Split('.');
            var currentNav = root.GetFirstLevelNavNode(nss[0]);
            var index = 0;
            do {
                if (string.CompareOrdinal(currentNav.NamespaceFragment, "*") == 0) {
                    valueList = currentNav.GetValues();
                    return true;
                }

                if (string.CompareOrdinal(nss[index], currentNav.NamespaceFragment) != 0) {
                    return false;
                }

                if (index + 1 < nss.Length && !currentNav.HasNextNav()) {
                    valueList = currentNav.GetValues();
                    return true;
                }

                currentNav = currentNav.GetNextNav(nss[++index]);

            } while (index < nss.Length);

            return false;
        }
    }
}