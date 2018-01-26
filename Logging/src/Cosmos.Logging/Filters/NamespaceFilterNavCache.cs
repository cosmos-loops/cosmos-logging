using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters {
    public class NamespaceFilterNavCache : INamespaceFilterNavParser {
        private readonly INamespaceFilterNavParser _namespaceFilterNavParser;
        private readonly Dictionary<int, NamespaceFilterNav> _namespaceCache = new Dictionary<int, NamespaceFilterNav>();
        private readonly Dictionary<int, NamespaceFilterNav> _namespaceNavCache = new Dictionary<int, NamespaceFilterNav>();
        private readonly object _namespacePoolLock = new object();

        public NamespaceFilterNavCache(INamespaceFilterNavParser namespaceFilterNavParser) {
            _namespaceFilterNavParser = namespaceFilterNavParser ?? throw new ArgumentNullException(nameof(namespaceFilterNavParser));
        }

        public NamespaceFilterNav Parse(string @namespace, string level) {
            if (string.IsNullOrWhiteSpace(@namespace)) return NamespaceFilterNav.Empty;
            if (@namespace == "Default") return NamespaceFilterNav.Empty;
            if (_namespaceCache.ContainsKey(@namespace.GetHashCode())) return _namespaceCache[@namespace.GetHashCode()];
            var nss = @namespace.Split('.');
            if (_namespaceNavCache.TryGetValue(nss[0].GetHashCode(), out var nav)) {
                var currentNav = nav;
                for (var i = 1; i < nss.Length; i++) {
                    if (nss[i] == "*") {
                        lock (_namespacePoolLock) {
                            currentNav.AddChild(_namespaceFilterNavParser.Parse("*", level));
                            _namespaceCache.Add(@namespace.GetHashCode(), nav);
                        }

                        return nav;
                    }

                    var tempNav = currentNav.GetNextNav(nss[i]);
                    if (tempNav == null || tempNav is EmptyNamespaceFilterNav) {
                        var nss2 = new string[nss.Length - i];
                        Array.Copy(nss, i, nss2, 0, nss.Length - i);
                        lock (_namespacePoolLock) {
                            currentNav.AddChild(_namespaceFilterNavParser.Parse(string.Join(".", nss2), level));
                            _namespaceCache.Add(@namespace.GetHashCode(), nav);
                            nav.OriginNamespaceOnRoot.Add(@namespace);
                        }

                        return nav;
                    }

                    currentNav = tempNav;
                }

                lock (_namespacePoolLock) {
                    nav.OriginNamespaceOnRoot.Add(@namespace);
                }

                return nav;
            }

            lock (_namespacePoolLock) {
                var newNav = _namespaceFilterNavParser.Parse(@namespace, level);
                _namespaceCache.Add(@namespace.GetHashCode(), newNav);
                _namespaceNavCache.Add(nss[0].GetHashCode(), newNav);
                newNav.OriginNamespaceOnRoot.Add(@namespace);
                return newNav;
            }
        }

        public bool Match(string @namespace, out EndValueNamespaceFilterNav value) {
            value = default(EndValueNamespaceFilterNav);

            if (string.IsNullOrWhiteSpace(@namespace)) return false;
            if (_namespaceCache.ContainsKey(@namespace.GetHashCode())) return true;

            var nss = @namespace.Split('.');
            return _namespaceNavCache.TryGetValue(nss[0].GetHashCode(), out var nav) && NamespaceNavMatcher.Match(@namespace, nav, out value);
        }
    }
}