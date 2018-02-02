using Cosmos.Logging.Renders.RendersLib;

namespace Cosmos.Logging.Renders {
    internal static class CoreRenderActivation {
        public static void ActiveCorePreferencesRenders() {
            PreferencesRenderManager.AddPreferencesRenderer<DateRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerMemberNameRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerFilePathRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerLineNumberRenderer>();
        }
    }
}