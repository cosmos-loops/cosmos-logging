using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    public class NamespaceNavigator {
        public static NamespaceNavigator Empty => EmptyNamespaceNavigationNode._empty;
        private NamespaceNavigator ParentNav { get; set; }
        private readonly Dictionary<int, EndValueNamespaceNavigationNode> _valueDict;
        private readonly Dictionary<int, NamespaceNavigator> _nextNavs;

        public NamespaceNavigator(string namespaceFragment) {
            if (string.IsNullOrWhiteSpace(namespaceFragment)) throw new ArgumentNullException(nameof(namespaceFragment));
            NamespaceFragment = namespaceFragment;
            FullNamespaceFragment = namespaceFragment;
            _valueDict = new Dictionary<int, EndValueNamespaceNavigationNode>();
            _nextNavs = new Dictionary<int, NamespaceNavigator>();
        }

        public string NamespaceFragment { get; }

        public string FullNamespaceFragment { get; private set; }

        internal IReadOnlyList<EndValueNamespaceNavigationNode> ValueList => _valueDict.Values.ToImmutableList();

        public virtual NamespaceNavigator GetParentNav() => ParentNav;

        public virtual NamespaceNavigator GetNextNav(string path) => _nextNavs.TryGetValue(path.GetHashCode(), out var ret) ? ret : Empty;

        public virtual IEnumerable<NamespaceNavigator> GetNextNavs() => _nextNavs.Values;

        public virtual IEnumerable<EndValueNamespaceNavigationNode> GetValues() => _valueDict.Values;

        public virtual void AppendValue(EndValueNamespaceNavigationNode value) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            var hashcode = value.GetHashCode();
            if (!_valueDict.ContainsKey(hashcode)) {
                _valueDict.Add(hashcode, value);
            }
        }

        public virtual void AppendValue(IEnumerable<EndValueNamespaceNavigationNode> valueList) {
            if (valueList == null) throw new ArgumentNullException(nameof(valueList));
            var validValueList = valueList.Where(x => !_valueDict.ContainsKey(x.GetHashCode()));
            foreach (var value in validValueList) {
                var hashcode = value.GetHashCode();
                if (!_valueDict.ContainsKey(hashcode)) {
                    _valueDict.Add(hashcode, value);
                }
            }
        }

        public virtual bool HasParentNav() => ParentNav != null;

        public virtual bool HasNextNav() => _nextNavs.Count > 0;

        public virtual bool HasValues() => _valueDict.Any();

        public virtual void AddChild(NamespaceNavigator nav) {
            if (nav == null) return;
            if (NamespaceFragment == "*") return;
            if (AntiLoopSelf(nav)) return;

            nav.ParentNav = this;
            nav.UpdateFullValueSegmentFromParent(FullNamespaceFragment);
            _nextNavs.Add(nav.NamespaceFragment.GetHashCode(), nav);
        }

        private void UpdateFullValueSegmentFromParent(string parentFullValueSegment) {
            FullNamespaceFragment = $"{parentFullValueSegment}.{NamespaceFragment}";
            foreach (var child in GetNextNavs()) {
                child.UpdateFullValueSegmentFromParent(FullNamespaceFragment);
            }
        }

        private bool AntiLoopSelf(NamespaceNavigator nav) {
            return AntiLoopSelf(nav.GetHashCode(), LoopSelfWard.Default);
        }

        private bool AntiLoopSelf(int targetHashCode, LoopSelfWard loopSelfWard) {
            if (GetHashCode() == targetHashCode) return true;

            var currentNav = this;
            if (currentNav.HasParentNav() && (loopSelfWard == LoopSelfWard.Default || loopSelfWard == LoopSelfWard.Upward)) {
                currentNav = currentNav.GetParentNav();
                if (currentNav.AntiLoopSelf(targetHashCode, LoopSelfWard.Upward)) return true;
            }

            currentNav = this;
            if (currentNav.HasNextNav() && (loopSelfWard == LoopSelfWard.Default || loopSelfWard == LoopSelfWard.Downward)) {
                foreach (var nextNav in currentNav.GetNextNavs()) {
                    if (nextNav.AntiLoopSelf(targetHashCode, LoopSelfWard.Downward)) return true;
                }
            }

            return false;
        }

        private enum LoopSelfWard {
            Default,
            Upward,
            Downward
        }

        public override int GetHashCode() {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return FullNamespaceFragment.GetHashCode();
        }
    }
}