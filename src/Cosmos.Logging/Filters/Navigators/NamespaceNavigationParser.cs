using System;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Filters.Navigators {
    public class NamespaceNavigationParser : INamespaceNavigationParser {

        public NamespaceNavigator Parse(string @namespace, string level, out EndValueNamespaceNavigationNode endValueNode) {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));

            endValueNode = new EndValueNamespaceNavigationNode(level);

            if (@namespace == "*") return new NamespaceNavigator("*") {Value = endValueNode};
            if (@namespace == "Default") return NamespaceNavigator.Empty;
            if (@namespace.IndexOf(".", StringComparison.Ordinal) < 0) return new NamespaceNavigator(@namespace) {Value = endValueNode};

            var nss = @namespace.Split('.');
            var root = new NamespaceNavigator(nss[0]);
            var currentNav = root;
            for (var i = 1; i < nss.Length; i++) {
                var _ = new NamespaceNavigator(nss[i]);
                currentNav.AddChild(_);
                currentNav = _;

                if (nss[i] == "*") break;
            }

            currentNav.Value = endValueNode;
            return root;
        }
    }
}