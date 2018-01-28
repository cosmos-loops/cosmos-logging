using System.Collections.Generic;

namespace Cosmos.Logging.Filters.Navigators {
    public sealed class EmptyNamespaceNavigationNode : NamespaceNavigator {
        internal static readonly NamespaceNavigator[] _emptyArray = new NamespaceNavigator[0];
        internal static readonly EmptyNamespaceNavigationNode _empty = new EmptyNamespaceNavigationNode();

        public EmptyNamespaceNavigationNode() : base("Empty") { }
        public override NamespaceNavigator GetNextNav(string path) => default(NamespaceNavigator);
        public override NamespaceNavigator GetParentNav() => default(NamespaceNavigator);
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => _emptyArray;
        public override EndValueNamespaceNavigationNode GetValue() => null;
        public override void SetValue(EndValueNamespaceNavigationNode nav) { }
        public override bool HasNextNav() => false;
        public override bool HasParentNav() => false;
        public override bool HasValue() => false;
        public override void AddChild(NamespaceNavigator nav) { }
    }
}