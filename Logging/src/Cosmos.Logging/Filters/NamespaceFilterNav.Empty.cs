using System.Collections.Generic;

namespace Cosmos.Logging.Filters {
    public sealed class EmptyNamespaceFilterNav : NamespaceFilterNav {
        internal static readonly NamespaceFilterNav[] _emptyArray = new NamespaceFilterNav[0];
        internal static readonly EmptyNamespaceFilterNav _empty = new EmptyNamespaceFilterNav();

        public EmptyNamespaceFilterNav() : base("Empty") { }
        public override NamespaceFilterNav GetNextNav(string path) => default(NamespaceFilterNav);
        public override NamespaceFilterNav GetParentNav() => default(NamespaceFilterNav);
        public override IEnumerable<NamespaceFilterNav> GetNextNavs() => _emptyArray;
        public override EndValueNamespaceFilterNav GetValue() => null;
        public override void SetValue(EndValueNamespaceFilterNav nav) { }
        public override bool HasNextNav() => false;
        public override bool HasParentNav() => false;
        public override bool HasValue() => false;
        public override void AddChild(NamespaceFilterNav nav) { }
    }
}