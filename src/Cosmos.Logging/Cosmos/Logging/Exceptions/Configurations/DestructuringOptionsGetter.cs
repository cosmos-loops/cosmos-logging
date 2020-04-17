using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Configurations {
    internal static class DestructuringOptionsGetter {
        public static string GetRealRootName(ExceptionConfiguration configuration, ExceptionOptions options) {
            //优先级顺序：option > configuration > default value

            var destructuringOptions = options.Build(out var status);

            var rawName = status.NameChanged ? destructuringOptions.Name : configuration.RootName;

            return string.IsNullOrWhiteSpace(rawName) ? Constants.RootName : rawName;
        }

        public static int GetRealDepth(ExceptionConfiguration configuration, ExceptionOptions options) {
            //优先级顺序：option > configuration > default value

            var destructuringOptions = options.Build(out var status);

            var rawDepth = status.DepthChanged ? destructuringOptions.DestructureDepth : configuration.DestructureDepth;

            if (rawDepth.HasValue && rawDepth.Value > 0)
                return rawDepth.Value;
            return Constants.DefaultDestructureDepth;
        }
    }
}