using Cosmos.Logging.Sinks.File.Renderers.Lib;

namespace Cosmos.Logging.Sinks.File.Renderers {
    public static class InternalRendererActivation {
        public static void Action() {
            OutputPreferencesRenderManager.AddPreferencesRenderer<CallerInfoRenderer>();
            OutputPreferencesRenderManager.AddPreferencesRenderer<DateTimeRenderer>();
            OutputPreferencesRenderManager.AddPreferencesRenderer<EventInfoRenderer>();
            OutputPreferencesRenderManager.AddPreferencesRenderer<LevelRenderer>();
            OutputPreferencesRenderManager.AddPreferencesRenderer<MessageRenderer>();
            OutputPreferencesRenderManager.AddPreferencesRenderer<NameRenderer>();
            OutputPreferencesRenderManager.AddPreferencesRenderer<NewLineRenderer>();
        }
    }
}