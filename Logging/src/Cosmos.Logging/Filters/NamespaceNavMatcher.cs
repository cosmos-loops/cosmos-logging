using System;

namespace Cosmos.Logging.Filters {
    public static class NamespaceNavMatcher {
        public static bool Match(string @namespace, NamespaceFilterNav nav, out EndValueNamespaceFilterNav value) {
            value = default(EndValueNamespaceFilterNav);

            if (string.IsNullOrWhiteSpace(@namespace)) return false;
            if (string.Compare(@namespace, "Default", StringComparison.OrdinalIgnoreCase) == 0) return false;
            if (nav == null) return false;
            //if (nav.IsRoot() && nav.OriginNamespaceOnRoot.Contains(@namespace)) return true;

            var currentNav = nav.IsRoot() ? nav : GetRoot(nav);
            if (currentNav == null) return false;

            var nss = @namespace.Split('.');
            var index = 0;
            do {
                if (string.CompareOrdinal(currentNav.NamespaceFragment, "*") == 0) return true;
                if (string.CompareOrdinal(nss[index], currentNav.NamespaceFragment) != 0) return false;
                if (index + 1 < nss.Length && !currentNav.HasNextNav()) {
                    value = currentNav.GetValue();
                    return true;
                }

                currentNav = currentNav.GetNextNav(nss[index + 1]);
                index++;

            } while (index < nss.Length);

            return false;
        }

        private static NamespaceFilterNav GetRoot(NamespaceFilterNav nav) {
            if (nav == null) return null;
            if (!nav.HasParentNav()) return nav;
            var currentNav = nav;
            while (currentNav.HasParentNav()) {
                currentNav = currentNav.GetParentNav();
            }

            return currentNav;
        }

        private static bool IsRoot(this NamespaceFilterNav nav) {
            return nav != null && !nav.HasParentNav();
        }
    }
}