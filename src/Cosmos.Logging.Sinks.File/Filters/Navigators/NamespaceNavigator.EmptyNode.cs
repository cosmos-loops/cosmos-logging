using System.Collections.Generic;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    public class EmptyNamespaceNavigationNode : NamespaceNavigator {
        internal static readonly NamespaceNavigator[] _emptyArray = new NamespaceNavigator[0];
        internal static readonly EmptyNamespaceNavigationNode _empty = new EmptyNamespaceNavigationNode();
        public EmptyNamespaceNavigationNode() : base("Empty") { }

        public override NamespaceNavigator GetNextNav(string path) => default(NamespaceNavigator);
        public override NamespaceNavigator GetParentNav() => default(NamespaceNavigator);
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => _emptyArray;
        public override IEnumerable<EndValueNamespaceNavigationNode> GetValues() => null;
        public override void AppendValue(EndValueNamespaceNavigationNode nav) { }
        public override void AppendValue(IEnumerable<EndValueNamespaceNavigationNode> navList) { }
        public override bool HasNextNav() => false;
        public override bool HasParentNav() => false;
        public override bool HasValues() => false;
        public override void AddChild(NamespaceNavigator nav) { }
    }
}