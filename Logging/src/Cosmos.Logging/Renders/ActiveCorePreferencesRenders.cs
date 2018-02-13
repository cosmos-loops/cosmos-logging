using System;
using System.Collections.Generic;
using Cosmos.Logging.Renders.RendersLib;

namespace Cosmos.Logging.Renders {
    internal static class CoreRenderActivation {
        private static readonly List<Type> _default = new List<Type> {
            typeof(DateRenderer),
            typeof(CallerMemberNameRenderer),
            typeof(CallerFilePathRenderer),
            typeof(CallerLineNumberRenderer),
            typeof(EventIdRenderer),
            typeof(EventNameRenderer)
        };

        public static IReadOnlyList<Type> Default => _default;

        public static void ActiveCorePreferencesRenders() {
            PreferencesRenderManager.AddPreferencesRenderer<DateRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerMemberNameRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerFilePathRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerLineNumberRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<EventIdRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<EventNameRenderer>();
        }
    }
}