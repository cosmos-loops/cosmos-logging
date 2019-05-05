using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Filters.Navigators {
    public class NamespaceNavigator {
        public static NamespaceNavigator Empty => EmptyNamespaceNavigationNode._empty;
        private NamespaceNavigator ParentNav { get; set; }
        internal EndValueNamespaceNavigationNode Value { get; set; }
        private readonly Dictionary<int, NamespaceNavigator> _nextNavs = new Dictionary<int, NamespaceNavigator>();
        private readonly Dictionary<int, EndValueNamespaceNavigationNode> _originNamespaceOnRoot;
        private readonly object _originNamespaceUpdateLock = new object();

        public NamespaceNavigator(string namespaceFragment) {
            if (string.IsNullOrWhiteSpace(namespaceFragment)) throw new ArgumentNullException(nameof(namespaceFragment));
            NamespaceFragment = namespaceFragment;
            FullNamespaceFragment = namespaceFragment;
            _originNamespaceOnRoot = new Dictionary<int, EndValueNamespaceNavigationNode>();
        }

        public string NamespaceFragment { get; }

        public string FullNamespaceFragment { get; private set; }

        public IReadOnlyDictionary<int, EndValueNamespaceNavigationNode> OriginNamespaceOnRoot => _originNamespaceOnRoot;

        internal void UpdateOriginNamespaceOnRoot(int hashcode, EndValueNamespaceNavigationNode value) {
            if (value != null && !_originNamespaceOnRoot.ContainsKey(hashcode)) {
                lock (_originNamespaceUpdateLock) {
                    if (!_originNamespaceOnRoot.ContainsKey(hashcode)) {
                        _originNamespaceOnRoot.Add(hashcode, value);
                    }
                }
            }
        }

        public virtual NamespaceNavigator GetParentNav() => ParentNav;

        public virtual NamespaceNavigator GetNextNav(string path) => _nextNavs.TryGetValue(path.GetHashCode(), out var ret) ? ret : Empty;

        public virtual IEnumerable<NamespaceNavigator> GetNextNavs() => _nextNavs.Values;

        public virtual EndValueNamespaceNavigationNode GetValue() => Value ?? EndValueNamespaceNavigationNode.Default;

        public virtual void SetValue(EndValueNamespaceNavigationNode nav) => Value = nav;

        public virtual bool HasParentNav() => ParentNav != null;

        public virtual bool HasNextNav() => _nextNavs.Count > 0;

        public virtual bool HasValue() => Value != null;

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