using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Filters.Navigators {
    /// <summary>
    /// Namespace navigator cache
    /// </summary>
    public class NamespaceNavigatorCache : INamespaceNavigationParser, INamespaceNavigationMatcher {
        private readonly INamespaceNavigationParser _namespaceNavigationParser;
        private readonly Dictionary<int, NamespaceNavigator> _namespaceCache = new Dictionary<int, NamespaceNavigator>();
        private readonly Dictionary<int, NamespaceNavigator> _namespaceNavCache = new Dictionary<int, NamespaceNavigator>();
        private readonly object _namespacePoolLock = new object();

        /// <summary>
        /// Create a new instance of <see cref="NamespaceNavigatorCache"/>
        /// </summary>
        /// <param name="namespaceNavigationParser"></param>
        public NamespaceNavigatorCache(INamespaceNavigationParser namespaceNavigationParser) {
            _namespaceNavigationParser = namespaceNavigationParser ?? throw new ArgumentNullException(nameof(namespaceNavigationParser));
        }

        /// <inheritdoc />
        public NamespaceNavigator Parse(string @namespace, string level, out EndValueNamespaceNavigationNode endValueNode) {
            endValueNode = EndValueNamespaceNavigationNode.Null;
            if (string.IsNullOrWhiteSpace(@namespace)) return NamespaceNavigator.Empty;
            if (@namespace == "Default") return NamespaceNavigator.Empty;
            if (_namespaceCache.ContainsKey(@namespace.GetHashCode())) return _namespaceCache[@namespace.GetHashCode()];

            var nss = @namespace.Split('.');
            if (_namespaceNavCache.TryGetValue(nss[0].GetHashCode(), out var nav)) {
                var currentNav = nav;
                for (var i = 1; i < nss.Length; i++) {
                    if (nss[i] == "*") {
                        lock (_namespacePoolLock) {
                            currentNav.AddChild(_namespaceNavigationParser.Parse("*", level, out endValueNode));
                            _namespaceCache.Add(@namespace.GetHashCode(), nav);
                            nav.UpdateOriginalNamespaceOnRoot(@namespace.GetHashCode(), endValueNode);
                        }

                        return nav;
                    }

                    var tempNav = currentNav.GetNextNav(nss[i]);
                    if (tempNav == null || tempNav is EmptyNamespaceNavigationNode) {
                        var nss2 = new string[nss.Length - i];
                        Array.Copy(nss, i, nss2, 0, nss.Length - i);
                        lock (_namespacePoolLock) {
                            currentNav.AddChild(_namespaceNavigationParser.Parse(string.Join(".", nss2), level, out endValueNode));
                            _namespaceCache.Add(@namespace.GetHashCode(), nav);
                            nav.UpdateOriginalNamespaceOnRoot(@namespace.GetHashCode(), endValueNode);
                        }

                        return nav;
                    }

                    currentNav = tempNav;
                }

                endValueNode = currentNav.GetValue();
                nav.UpdateOriginalNamespaceOnRoot(@namespace.GetHashCode(), endValueNode);

                return nav;
            }

            lock (_namespacePoolLock) {
                var newNav = _namespaceNavigationParser.Parse(@namespace, level, out endValueNode);
                _namespaceCache.Add(@namespace.GetHashCode(), newNav);
                _namespaceNavCache.Add(nss[0].GetHashCode(), newNav);
                newNav.UpdateOriginalNamespaceOnRoot(@namespace.GetHashCode(), endValueNode);
                return newNav;
            }
        }

        /// <inheritdoc />
        public bool Match(string @namespace, out EndValueNamespaceNavigationNode value) {
            value = default;

            if (string.IsNullOrWhiteSpace(@namespace)) return false;
            if (_namespaceCache.ContainsKey(@namespace.GetHashCode())) return true;

            var nss = @namespace.Split('.');
            return _namespaceNavCache.TryGetValue(nss[0].GetHashCode(), out var nav) && NamespaceNavigationMatcher.Match(@namespace, nav, out value);
        }
    }
}