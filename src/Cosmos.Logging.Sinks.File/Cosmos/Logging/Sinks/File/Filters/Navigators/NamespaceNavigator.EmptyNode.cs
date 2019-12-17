using System.Collections.Generic;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    /// <summary>
    /// Empty namespace navifation node
    /// </summary>
    public class EmptyNamespaceNavigationNode : NamespaceNavigator {
        internal static readonly NamespaceNavigator[] _emptyArray = new NamespaceNavigator[0];
        internal static readonly EmptyNamespaceNavigationNode _empty = new EmptyNamespaceNavigationNode();

        /// <inheritdoc />
        public EmptyNamespaceNavigationNode() : base("Empty") { }

        /// <inheritdoc />
        public override NamespaceNavigator GetNextNav(string path) => default;

        /// <inheritdoc />
        public override NamespaceNavigator GetParentNav() => default;

        /// <inheritdoc />
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => _emptyArray;

        /// <inheritdoc />
        public override IEnumerable<EndValueNamespaceNavigationNode> GetValues() => null;

        /// <inheritdoc />
        public override void AppendValue(EndValueNamespaceNavigationNode nav) { }

        /// <inheritdoc />
        public override void AppendValue(IEnumerable<EndValueNamespaceNavigationNode> navList) { }

        /// <inheritdoc />
        public override bool HasNextNav() => false;

        /// <inheritdoc />
        public override bool HasParentNav() => false;

        /// <inheritdoc />
        public override bool HasValues() => false;

        /// <inheritdoc />
        public override void AddChild(NamespaceNavigator nav) { }
    }
}