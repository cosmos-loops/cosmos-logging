using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters {
    public class EndValueNamespaceFilterNav : NamespaceFilterNav {
        private static readonly EndValueNamespaceFilterNav _default = new EndValueNamespaceFilterNav {Level = LogEventLevel.Verbose};
        public static EndValueNamespaceFilterNav Default => _default;

        private EndValueNamespaceFilterNav() : base("EndValue") { }

        public EndValueNamespaceFilterNav(string level) : base("EndValue") {
            Level = EnumsNET.Enums.TryParse(level, false, out LogEventLevel logEventLevel) ? logEventLevel : LogEventLevel.Verbose;
        }

        public LogEventLevel Level { get; private set; }

        public override NamespaceFilterNav GetNextNav(string path) => default(NamespaceFilterNav);
        public override IEnumerable<NamespaceFilterNav> GetNextNavs() => EmptyNamespaceFilterNav._emptyArray;
        public override EndValueNamespaceFilterNav GetValue() => this;
        public override void SetValue(EndValueNamespaceFilterNav nav) { }
        public override bool HasNextNav() => false;
        public override bool HasValue() => true;
        public override void AddChild(NamespaceFilterNav nav) { }
    }
}