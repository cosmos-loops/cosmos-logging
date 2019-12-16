using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Filters.Navigators {
    /// <summary>
    /// Namespace navigator
    /// </summary>
    public class NamespaceNavigator {
        /// <summary>
        /// Gets an empty instance for <see cref="NamespaceNavigator"/>.
        /// </summary>
        public static NamespaceNavigator Empty => EmptyNamespaceNavigationNode._empty;

        private NamespaceNavigator ParentNav { get; set; }
        internal EndValueNamespaceNavigationNode Value { get; set; }
        private readonly Dictionary<int, NamespaceNavigator> _nextNavs = new Dictionary<int, NamespaceNavigator>();
        private readonly Dictionary<int, EndValueNamespaceNavigationNode> _originalNamespaceOnRoot;
        private readonly object _originalNamespaceUpdateLock = new object();

        /// <summary>
        /// Create a new instance of <see cref="NamespaceNavigator"/>
        /// </summary>
        /// <param name="namespaceFragment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public NamespaceNavigator(string namespaceFragment) {
            if (string.IsNullOrWhiteSpace(namespaceFragment)) throw new ArgumentNullException(nameof(namespaceFragment));
            NamespaceFragment = namespaceFragment;
            FullNamespaceFragment = namespaceFragment;
            _originalNamespaceOnRoot = new Dictionary<int, EndValueNamespaceNavigationNode>();
        }

        /// <summary>
        /// Gets namespace fragment
        /// </summary>
        public string NamespaceFragment { get; }

        /// <summary>
        /// Gets full namespace fragment
        /// </summary>
        public string FullNamespaceFragment { get; private set; }

        /// <summary>
        /// Gets original namespace on root
        /// </summary>
        public IReadOnlyDictionary<int, EndValueNamespaceNavigationNode> OriginalNamespaceOnRoot => _originalNamespaceOnRoot;

        internal void UpdateOriginalNamespaceOnRoot(int hashcode, EndValueNamespaceNavigationNode value) {
            if (value != null && !_originalNamespaceOnRoot.ContainsKey(hashcode)) {
                lock (_originalNamespaceUpdateLock) {
                    if (!_originalNamespaceOnRoot.ContainsKey(hashcode)) {
                        _originalNamespaceOnRoot.Add(hashcode, value);
                    }
                }
            }
        }

        /// <summary>
        /// Get parent navigator
        /// </summary>
        /// <returns></returns>
        public virtual NamespaceNavigator GetParentNav() => ParentNav;

        /// <summary>
        /// Get next navigator
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual NamespaceNavigator GetNextNav(string path) => _nextNavs.TryGetValue(path.GetHashCode(), out var ret) ? ret : Empty;

        /// <summary>
        /// Get next navigators
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<NamespaceNavigator> GetNextNavs() => _nextNavs.Values;

        /// <summary>
        /// Get value
        /// </summary>
        /// <returns></returns>
        public virtual EndValueNamespaceNavigationNode GetValue() => Value ?? EndValueNamespaceNavigationNode.Default;

        /// <summary>
        /// Set value
        /// </summary>
        /// <param name="nav"></param>
        public virtual void SetValue(EndValueNamespaceNavigationNode nav) => Value = nav;

        /// <summary>
        /// Has parent navigator
        /// </summary>
        /// <returns></returns>
        public virtual bool HasParentNav() => ParentNav != null;

        /// <summary>
        /// Has next navigator
        /// </summary>
        /// <returns></returns>
        public virtual bool HasNextNav() => _nextNavs.Count > 0;

        /// <summary>
        /// Has value
        /// </summary>
        /// <returns></returns>
        public virtual bool HasValue() => Value != null;

        /// <summary>
        /// Add child
        /// </summary>
        /// <param name="nav"></param>
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

        /// <inheritdoc />
        public override int GetHashCode() {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return FullNamespaceFragment.GetHashCode();
        }
    }
}