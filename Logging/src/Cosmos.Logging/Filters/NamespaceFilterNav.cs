using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Filters {
    public class NamespaceFilterNav {
        public static NamespaceFilterNav Empty => EmptyNamespaceFilterNav._empty;
        private NamespaceFilterNav ParentNav { get; set; }
        internal EndValueNamespaceFilterNav Value { get; set; }
        private readonly Dictionary<int, NamespaceFilterNav> _nextNavs = new Dictionary<int, NamespaceFilterNav>();

        public NamespaceFilterNav(string namespaceFragment) {
            if (string.IsNullOrWhiteSpace(namespaceFragment)) throw new ArgumentNullException(nameof(namespaceFragment));
            NamespaceFragment = namespaceFragment;
            FullNamespaceFragment = namespaceFragment;
        }

        public string NamespaceFragment { get; }

        public string FullNamespaceFragment { get; private set; }

        internal List<string> OriginNamespaceOnRoot { get; set; } = new List<string>();

        public virtual NamespaceFilterNav GetParentNav() => ParentNav;

        public virtual NamespaceFilterNav GetNextNav(string path) => _nextNavs.TryGetValue(path.GetHashCode(), out var ret) ? ret : Empty;

        public virtual IEnumerable<NamespaceFilterNav> GetNextNavs() => _nextNavs.Values;

        public virtual EndValueNamespaceFilterNav GetValue() => Value ?? EndValueNamespaceFilterNav.Default;

        public virtual void SetValue(EndValueNamespaceFilterNav nav) => Value = nav;

        public virtual bool HasParentNav() => ParentNav != null;

        public virtual bool HasNextNav() => _nextNavs.Count > 0;

        public virtual bool HasValue() => Value != null;

        public virtual void AddChild(NamespaceFilterNav nav) {
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

        private bool AntiLoopSelf(NamespaceFilterNav nav) {
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