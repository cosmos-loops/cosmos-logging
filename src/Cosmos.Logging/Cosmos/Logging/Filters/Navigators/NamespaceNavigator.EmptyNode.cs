using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cosmos.Logging.Filters.Navigators {
    /// <summary>
    /// Empty node for namespace navigator
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public sealed class EmptyNamespaceNavigationNode : NamespaceNavigator {
        internal static readonly NamespaceNavigator[] _emptyArray = new NamespaceNavigator[0];
        internal static readonly EmptyNamespaceNavigationNode _empty = new EmptyNamespaceNavigationNode();

        /// <inheritdoc />
        public EmptyNamespaceNavigationNode() : base("Empty") { }

        /// <inheritdoc />
        public override NamespaceNavigator GetNextNav(string path) => default(NamespaceNavigator);

        /// <inheritdoc />
        public override NamespaceNavigator GetParentNav() => default(NamespaceNavigator);

        /// <inheritdoc />
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => _emptyArray;

        /// <inheritdoc />
        public override EndValueNamespaceNavigationNode GetValue() => null;

        /// <inheritdoc />
        public override void SetValue(EndValueNamespaceNavigationNode nav) { }

        /// <inheritdoc />
        public override bool HasNextNav() => false;

        /// <inheritdoc />
        public override bool HasParentNav() => false;

        /// <inheritdoc />
        public override bool HasValue() => false;

        /// <inheritdoc />
        public override void AddChild(NamespaceNavigator nav) { }
    }
}