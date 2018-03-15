using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    internal static class NamespaceNavigationMatcher {
        public static bool Match(string @namespace, out IEnumerable<EndValueNamespaceNavigationNode> valueList) {
            var root = RootNamespaceNavigation.GetInstance();
            var defaultValueList = valueList = root.HasAllValue() ? root.GetStarValues() : root.GetDefaultValues();

            if (string.IsNullOrWhiteSpace(@namespace)) return false;
            if (string.Compare(@namespace, "Default", StringComparison.OrdinalIgnoreCase) == 0) return true;

            var globalValueList = root.GetStarValues();

            if (@namespace.IndexOf('.') < 0) {
                valueList = MergedOrDefault(root.GetFirstLevelNavValues(@namespace));
                return HasValue(valueList);
            }

            var nss = @namespace.Split('.');
            var currentNav = root.GetFirstLevelNavNode(nss[0]);
            var index = 0;
            do {
                if (string.CompareOrdinal(currentNav.NamespaceFragment, "*") == 0) {
                    valueList = MergedOrDefault(currentNav.GetValues());
                    return HasValue(valueList);
                }

                if (string.CompareOrdinal(nss[index], currentNav.NamespaceFragment) != 0) {
                    valueList = defaultValueList;
                    return HasValue(valueList);
                }

                if (index + 1 < nss.Length && !currentNav.HasNextNav()) {
                    valueList = MergedOrDefault(currentNav.GetValues());
                    return HasValue(valueList);
                }

                currentNav = currentNav.GetNextNav(nss[++index]);

            } while (index < nss.Length);

            valueList = defaultValueList;

            return HasValue(valueList);


            bool HasGlobaltValueList() => globalValueList != null && globalValueList.Any();
            bool HasValue(IEnumerable<EndValueNamespaceNavigationNode> targetValueList) => targetValueList.Any();

            IEnumerable<EndValueNamespaceNavigationNode> TouchValueList(IEnumerable<EndValueNamespaceNavigationNode> targetValueList) {
                foreach (var value in targetValueList) {
                    yield return value;
                }

                if (HasGlobaltValueList()) {
                    foreach (var value in globalValueList) {
                        yield return value;
                    }
                }
            }

            IEnumerable<EndValueNamespaceNavigationNode> MergedOrDefault(IEnumerable<EndValueNamespaceNavigationNode> targetValueList) {
                var merged = TouchValueList(targetValueList);
                return HasValue(merged) ? merged : root.GetDefaultValues();
            }
        }
    }
}