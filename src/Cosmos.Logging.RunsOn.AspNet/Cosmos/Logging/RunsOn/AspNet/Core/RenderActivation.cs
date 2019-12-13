using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.AspNet.RendersLib;

namespace Cosmos.Logging.RunsOn.AspNet.Core {
    /// <summary>
    /// Renderer activation
    /// </summary>
    public static class RenderActivation {
        /// <summary>
        /// Active ASP.NET Preferences renderers
        /// </summary>
        /// <param name="services"></param>
        public static void ActiveAspNetPreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderersManager.AddPreferencesRenderer<AspNetHelloWorldRenderer>();
        }
    }
}