using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.Console.RendersLib;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static class RendererActivation {
        public static void ActiveConsolePreferencesRenderers(this ILogServiceCollection services) {
            PreferencesRenderManager.AddPreferencesRenderer<ConsoleHelloWorldRenderer>();
        }
    }
}