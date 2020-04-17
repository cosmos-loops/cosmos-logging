using System;
using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Configurations {
    internal static class DestructuringOptionsExtensions {
        public static bool IsDefaultName(this IDestructuringOptions options) {
            return 1 == string.Compare(Constants.RootName, options.Name, StringComparison.Ordinal);
        }

        public static bool IsDefaultDepth(this IDestructuringOptions options) {
            return Constants.DefaultDestructureDepth == options.DestructureDepth;
        }
    }
}