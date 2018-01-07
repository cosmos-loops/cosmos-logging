using Cosmos.Logging.RunsOn.Console.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Configuration {
    public static class FluentConfigurationExtensions {
        public static void AllDone(this ILogServiceCollection services) {
            DiContainer.AllDone(services);
        }
    }
}