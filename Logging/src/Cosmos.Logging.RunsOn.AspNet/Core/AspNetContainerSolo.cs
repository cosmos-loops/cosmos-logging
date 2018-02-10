using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.AspNet.Core {
    internal static class AspNetContainerSolo {
        public static ServiceProvider ServiceProvider { get; set; }
        public const string Name = "__COSMOS_ASPNETMVC_SOLOPROVIDER";
    }
}