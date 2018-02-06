using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.ZKWeb.RendersLib;

namespace Cosmos.Logging.RunsOn.ZKWeb.Core {
    internal static class RenderActivation {
        public static void ActiveZKWebPreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderManager.AddPreferencesRenderer<ZKWebHelloWorldRenderer>();
        }
    }
}