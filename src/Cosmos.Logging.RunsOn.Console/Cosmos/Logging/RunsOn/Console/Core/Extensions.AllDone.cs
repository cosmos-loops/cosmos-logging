using Cosmos.Logging.Core;
using Cosmos.Logging.RunsOn.Console.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for all done
    /// </summary>
    public static class AllDoneExtensions {
        /// <summary>
        /// All done
        /// </summary>
        /// <param name="services"></param>
        public static void AllDone(this ILogServiceCollection services) {
            SoloDependencyContainer.AllDone(services);
            LOGGER._initialized = true;
        }
    }
}