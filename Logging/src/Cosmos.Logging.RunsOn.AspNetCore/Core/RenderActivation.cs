using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.AspNetCore.RendersLib;

namespace Cosmos.Logging.RunsOn.AspNetCore.Core {
    internal static class RenderActivation {
        public static void ActiveAspNetCorePreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderManager.AddPreferencesRenderer<AspNetCoreHelloWorldRenderer>();
        }
    }
}