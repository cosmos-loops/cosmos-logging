using System;
using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Strategies;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    public class EndValueNamespaceNavigationNode : NamespaceNavigator {
        public EndValueNamespaceNavigationNode(SavingStrategy savingStrategy) : base("EndValue") {
            SavingStrategy = savingStrategy ?? throw new ArgumentNullException(nameof(savingStrategy));
        }

        public SavingStrategy SavingStrategy { get; }

        public override NamespaceNavigator GetNextNav(string path) => default(NamespaceNavigator);
        public override NamespaceNavigator GetParentNav() => default(NamespaceNavigator);
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => EmptyNamespaceNavigationNode._emptyArray;
        public override IEnumerable<EndValueNamespaceNavigationNode> GetValues() => null;
        public override void AppendValue(EndValueNamespaceNavigationNode nav) { }
        public override void AppendValue(IEnumerable<EndValueNamespaceNavigationNode> navList) { }
        public override bool HasNextNav() => false;
        public override bool HasParentNav() => false;
        public override bool HasValues() => false;
        public override void AddChild(NamespaceNavigator nav) { }

        public override int GetHashCode() {
            return SavingStrategy.GetHashCode();
        }
    }
}