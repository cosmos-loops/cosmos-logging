using Cosmos.Extensions.Dependency;
using Cosmos.Logging.Extensions.Host;

namespace Cosmos.Logging.Core.Internals {
    internal static class CoreRegisterExtensions {
        public static void AppendOrOverride(this ILogServiceCollection services) {
            services.AddDependency(s => s.TryAddSingleton<ILoggingServiceProvider, HostingLoggingServiceProvider>());
        }
    }
}