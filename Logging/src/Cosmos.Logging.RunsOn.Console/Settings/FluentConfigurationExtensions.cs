using Cosmos.Logging.RunsOn.Console.Core;
using Cosmos.Logging.Settings;

namespace Cosmos.Logging.RunsOn.Console.Settings {
    public static class FluentConfigurationExtensions {
        public static void AllDone(this ILogServiceCollection services) {
            IocContainer.AllDone(services);
        }
    }
}