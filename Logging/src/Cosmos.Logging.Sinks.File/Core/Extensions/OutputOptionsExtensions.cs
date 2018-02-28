using System.Linq;
using Cosmos.Logging.Sinks.File.Configurations;

namespace Cosmos.Logging.Sinks.File.Core.Extensions {
    internal static class OutputOptionsExtensions {

        public static bool IsValid(this OutputOptions options) {
            if (string.IsNullOrWhiteSpace(options?.Path)) return false;
            if (string.IsNullOrWhiteSpace(options.Template)) return false;
            if (options.Navigators == null || !options.Navigators.Any()) return false;
            return true;
        }
    }
}