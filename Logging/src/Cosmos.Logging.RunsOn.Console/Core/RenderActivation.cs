using Cosmos.Logging.Core;
using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.Console.RendersLib;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static class RenderActivation {
        public static void ActiveConsolePreferencesRenders(this ILogServiceCollection services) {
            PreferencesRenderManager.AddPreferencesRender<ConsoleHelloWorld>();
        }
    }
}