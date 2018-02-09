using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.NancyFX.RendersLib;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    public static class RenderActivation {
        public static void ActiveNancyPreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderManager.AddPreferencesRenderer<NancyHelloWorldRenderer>();
        }
    }
}