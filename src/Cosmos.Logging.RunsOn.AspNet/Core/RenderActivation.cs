using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.AspNet.RendersLib;

namespace Cosmos.Logging.RunsOn.AspNet.Core {
    public static class RenderActivation {
        public static void ActiveAspNetPreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderersManager.AddPreferencesRenderer<AspNetHelloWorldRenderer>();
        }
    }
}