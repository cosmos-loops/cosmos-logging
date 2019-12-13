using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.AspNet.Core {
    internal static class SoloDependencyContainer {
        public static ServiceProvider ServiceResolver { get; set; }
        public const string Name = "__COSMOS_ASPNETMVC_SOLOPROVIDER";
    }
}