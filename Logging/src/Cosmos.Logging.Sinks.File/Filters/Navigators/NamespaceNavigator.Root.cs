using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    public class RootNamespaceNavigation {
        private static readonly RootNamespaceNavigation _singleRoot = new RootNamespaceNavigation();
        internal static RootNamespaceNavigation GetInstance() => _singleRoot;

        private NamespaceNavigator DefaultNavNode { get; set; }
        private NamespaceNavigator ForAllNavNode { get; set; }
        private readonly List<NamespaceNavigator> _namespaceNavigators;
        private readonly Dictionary<int, EndValueNamespaceNavigationNode> _registeredEndValueNodeDict;

        private RootNamespaceNavigation() {
            _namespaceNavigators = new List<NamespaceNavigator>();
            _registeredEndValueNodeDict = new Dictionary<int, EndValueNamespaceNavigationNode>();
        }

        public bool HasDefaultValue() => DefaultNavNode != null;

        public bool HasAllValue() => ForAllNavNode != null;

        public void SetDefaultNavValue(EndValueNamespaceNavigationNode value) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (!HasDefaultValue()) {
                DefaultNavNode = new NamespaceNavigator("Default");
            }

            DefaultNavNode.AppendValue(value);
        }

        public IReadOnlyList<EndValueNamespaceNavigationNode> GetDefaultValues() => DefaultNavNode.ValueList;

        public void SetAllNavValue(EndValueNamespaceNavigationNode value) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (!HasAllValue()) {
                ForAllNavNode = new NamespaceNavigator("*");
            }

            ForAllNavNode.AppendValue(value);
        }

        public IReadOnlyList<EndValueNamespaceNavigationNode> GetStarValues() => ForAllNavNode.ValueList;

        public void SetFirstLevelNavValue(string @namespace, EndValueNamespaceNavigationNode value) {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
            if (value == null) throw new ArgumentNullException(nameof(value));
            value = FixedValue(value);

            var firstMatched = _namespaceNavigators.FirstOrDefault(x => string.CompareOrdinal(x.NamespaceFragment, @namespace) == 0);
            if (firstMatched == null) {
                var nav = new NamespaceNavigator(@namespace);
                nav.AppendValue(value);
                _namespaceNavigators.Add(nav);
            } else {
                firstMatched.AppendValue(value);
            }
        }

        public IReadOnlyList<EndValueNamespaceNavigationNode> GetFirstLevelNavValues(string @namespace) {
            return _namespaceNavigators.FirstOrDefault(x => string.CompareOrdinal(@namespace, x.NamespaceFragment) == 0)?.ValueList;
        }

        public NamespaceNavigator GetFirstLevelNavNode(string namespaceFragment) {
            if (string.IsNullOrWhiteSpace(namespaceFragment)) return NamespaceNavigator.Empty;
            return _namespaceNavigators.FirstOrDefault(x => string.CompareOrdinal(namespaceFragment, x.NamespaceFragment) == 0) ?? NamespaceNavigator.Empty;
        }

        public void SetFluentLinkedNavValue(string @namespace, EndValueNamespaceNavigationNode value) {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
            if (value == null) throw new ArgumentNullException(nameof(value));
            value = FixedValue(value);

            var nss = @namespace.Split('.');
            var root = TouchRootNode(nss[0], out var createdMode);
            var currentNav = root;
            for (var i = 1; i < nss.Length; i++) {
                var _ = _namespaceNavigators.FirstOrDefault(x => x.NamespaceFragment == nss[i]);
                if (_ == null) {
                    _ = new NamespaceNavigator(nss[i]);
                    currentNav.AddChild(_);
                }

                currentNav = _;

                if (nss[i] == "*") break;
            }

            currentNav.AppendValue(value);

            if (createdMode) {
                _namespaceNavigators.Add(root);
            }
        }
        
        private EndValueNamespaceNavigationNode FixedValue(EndValueNamespaceNavigationNode value) {
            if (_registeredEndValueNodeDict.ContainsKey(value.GetHashCode())) {
                value = _registeredEndValueNodeDict[value.GetHashCode()];
            } else {
                _registeredEndValueNodeDict.Add(value.GetHashCode(), value);
            }

            return value;
        }

        private NamespaceNavigator TouchRootNode(string rootNamespaceNode, out bool createdMode) {
            var root = _namespaceNavigators.FirstOrDefault(x => string.CompareOrdinal(x.NamespaceFragment, rootNamespaceNode) == 0);
            createdMode = root == null;
            return createdMode ? new NamespaceNavigator(rootNamespaceNode) : root;
        }
    }
}