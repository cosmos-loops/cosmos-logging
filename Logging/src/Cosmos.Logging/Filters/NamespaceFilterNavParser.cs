using System;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Filters {
    public class NamespaceFilterNavParser : INamespaceFilterNavParser {

        public NamespaceFilterNav Parse(string @namespace, string level, out EndValueNamespaceFilterNav endValueNode) {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));

            endValueNode = new EndValueNamespaceFilterNav(level);

            if (@namespace == "*") return new NamespaceFilterNav("*") {Value = endValueNode};
            if (@namespace == "Default") return NamespaceFilterNav.Empty;
            if (@namespace.IndexOf(".", StringComparison.Ordinal) < 0) return new NamespaceFilterNav(@namespace) {Value = endValueNode};

            var nss = @namespace.Split('.');
            var root = new NamespaceFilterNav(nss[0]);
            var currentNav = root;
            for (var i = 1; i < nss.Length; i++) {
                var _ = new NamespaceFilterNav(nss[i]);
                currentNav.AddChild(_);
                currentNav = _;

                if (nss[i] == "*") break;
            }

            currentNav.Value = endValueNode;
            return root;
        }
    }
}