using Cosmos.Logging.Renders;
using Cosmos.Logging.RunsOn.Console.RendersLib;
using Cosmos.Logging.Settings;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static class ConsoleRenderActivation {
        public static void ActiveConsolePreferencesRenders(this ILogServiceCollection services) {
            PreferencesRenderManager.AddPreferencesRender<ConsoleHelloWorld>();
        }
    }
}