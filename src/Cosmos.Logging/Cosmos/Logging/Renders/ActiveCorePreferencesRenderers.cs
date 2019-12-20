using System;
using System.Collections.Generic;
using Cosmos.Logging.Renders.RendersLib;

namespace Cosmos.Logging.Renders {
    internal static class CoreRendererActivation {
        // ReSharper disable once InconsistentNaming
        private static readonly List<Type> _default = new List<Type> {
            typeof(DateRenderer),
            typeof(CallerMemberNameRenderer),
            typeof(CallerFilePathRenderer),
            typeof(CallerLineNumberRenderer),
            typeof(EventIdRenderer),
            typeof(ParentEventIdRenderer),
            typeof(EventIdChainsRenderer),
            typeof(ScopeTraceIdRenderer),
            typeof(BusinessTraceIdRenderer),
            typeof(EventLevelRenderer),
            typeof(EventNameRenderer),
            typeof(ExceptionRenderer)
        };

        public static IReadOnlyList<Type> Default => _default;

        public static void ActiveCorePreferencesRenderers() {
            PreferencesRenderersManager.AddPreferencesRenderer<DateRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<CallerMemberNameRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<CallerFilePathRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<CallerLineNumberRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<EventIdRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<ParentEventIdRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<EventIdChainsRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<ScopeTraceIdRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<BusinessTraceIdRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<EventLevelRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<EventNameRenderer>();
            PreferencesRenderersManager.AddPreferencesRenderer<ExceptionRenderer>();
        }
    }
}