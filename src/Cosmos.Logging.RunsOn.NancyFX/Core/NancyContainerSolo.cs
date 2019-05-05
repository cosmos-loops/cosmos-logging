using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    internal static class NancyContainerSolo {
        public static ServiceProvider ServiceProvider { get; set; }
        public const string Name = "__COSMOS_NANCYFX_SOLOPROVIDER";
    }
}