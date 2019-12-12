using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters.Navigators {
    /// <summary>
    /// End value node for namespace navigator
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EndValueNamespaceNavigationNode : NamespaceNavigator {
        private static readonly EndValueNamespaceNavigationNode _null = default;
        private static readonly EndValueNamespaceNavigationNode _default = new EndValueNamespaceNavigationNode {Level = LogEventLevel.Verbose};

        /// <summary>
        /// Get a null end-value-node for namespace navigator
        /// </summary>
        public static EndValueNamespaceNavigationNode Null => _null;

        /// <summary>
        /// Get a default end-value-node for namespace navigator
        /// </summary>
        public static EndValueNamespaceNavigationNode Default => _default;

        private EndValueNamespaceNavigationNode() : base("EndValue") { }

        /// <inheritdoc />
        public EndValueNamespaceNavigationNode(string level) : base("EndValue") {
            Level = LogEventLevelConverter.Convert(level);
        }

        /// <summary>
        /// Gets log event level
        /// </summary>
        public LogEventLevel Level { get; private set; }

        /// <inheritdoc />
        public override NamespaceNavigator GetNextNav(string path) => default;

        /// <inheritdoc />
        public override IEnumerable<NamespaceNavigator> GetNextNavs() => EmptyNamespaceNavigationNode._emptyArray;

        /// <inheritdoc />
        public override EndValueNamespaceNavigationNode GetValue() => this;

        /// <inheritdoc />
        public override void SetValue(EndValueNamespaceNavigationNode nav) { }

        /// <inheritdoc />
        public override bool HasNextNav() => false;

        /// <inheritdoc />
        public override bool HasValue() => true;

        /// <inheritdoc />
        public override void AddChild(NamespaceNavigator nav) { }
    }
}