using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters.Navigators {
    public class EndValueNamespaceNavigationNode : NamespaceNavigator {
        private static readonly EndValueNamespaceNavigationNode _null = default(EndValueNamespaceNavigationNode);
        private static readonly EndValueNamespaceNavigationNode _default = new EndValueNamespaceNavigationNode {Level = LogEventLevel.Verbose};
        public static EndValueNamespaceNavigationNode Null => _null;
        public static EndValueNamespaceNavigationNode Default => _default;

        private EndValueNamespaceNavigationNode() : base("EndValue") { }

        public EndValueNamespaceNavigationNode(string level) : base("EndValue") {
            Level = LogEventLevelConverter.Convert(level);
        }

        public LogEventLevel Level { get; private set; }

        public override NamespaceNavigator GetNextNav(string path) => default(NamespaceNavigator);
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => EmptyNamespaceNavigationNode._emptyArray;
        public override EndValueNamespaceNavigationNode GetValue() => this;
        public override void SetValue(EndValueNamespaceNavigationNode nav) { }
        public override bool HasNextNav() => false;
        public override bool HasValue() => true;
        public override void AddChild(NamespaceNavigator nav) { }
    }
}