using System;
using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Strategies;

namespace Cosmos.Logging.Sinks.File.Filters.Navigators {
    /// <summary>
    /// End value namespace navigation node
    /// </summary>
    public class EndValueNamespaceNavigationNode : NamespaceNavigator {
        /// <inheritdoc />
        public EndValueNamespaceNavigationNode(SavingStrategy savingStrategy) : base("EndValue") {
            SavingStrategy = savingStrategy ?? throw new ArgumentNullException(nameof(savingStrategy));
        }

        /// <summary>
        /// Gets saving strategy
        /// </summary>
        public SavingStrategy SavingStrategy { get; }

        /// <inheritdoc />
        public override NamespaceNavigator GetNextNav(string path) => default(NamespaceNavigator);

        /// <inheritdoc />
        public override NamespaceNavigator GetParentNav() => default(NamespaceNavigator);

        /// <inheritdoc />
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => EmptyNamespaceNavigationNode._emptyArray;

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

        /// <inheritdoc />
        public override int GetHashCode() {
            return SavingStrategy.GetHashCode();
        }
    }
}