using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.AspNetCore.RendersLib;

namespace Microsoft.Extensions.DependencyInjection {
    /// <summary>
    /// Extensions for Microsoft ASP.NET Core preferences renderers
    /// </summary>
    public static class AspNetCoreRenderersExtensions {
        /// <summary>
        /// Register Microsoft ASP.NET Core preferences renderers
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterAspNetCorePreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderersManager.AddPreferencesRenderer<AspNetCoreHelloWorldRenderer>();
        }
    }
}