using System;
using System.Collections.Generic;
using Cosmos.Logging.Renderers.Process.RendersLib;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Renderers.Process {
    /// <summary>
    /// Process renderers activation
    /// </summary>
    public static class ProcessRenderersActivation {
        // ReSharper disable once InconsistentNaming
        private static readonly List<Type> _default = new List<Type> {
            typeof(ProcessBasePriority),
            typeof(ProcessPagedMemorySize),
            typeof(ProcessNonpagedSystemMemorySize),
            typeof(ProcessPagedSystemMemorySize),
            typeof(ProcessVirtualMemorySize),
            typeof(ProcessPrivateMemorySize),
            typeof(ProcessName),
            typeof(ProcessId),
            typeof(ProcessSessionId),
            typeof(ProcessStartInfoArguments),
            typeof(ProcessStartInfoDomain),
            typeof(ProcessStartInfoFileName),
            typeof(ProcessStartInfoWorkingDirectory),
            typeof(ProcessStartTime),
            typeof(ProcessSystemProcessorTime),
            typeof(ProcessUserProcessorTime),
            typeof(ProcessWorkingSet)
        };

        /// <summary>
        /// Gets default renderer types
        /// </summary>
        public static IReadOnlyList<Type> Default => _default;

        /// <summary>
        /// Active process preferences renderers
        /// </summary>
        public static void ActiveProcesstPreferencesRenderers() {
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessBasePriority>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessPagedMemorySize>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessNonpagedSystemMemorySize>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessPagedSystemMemorySize>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessVirtualMemorySize>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessPrivateMemorySize>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessName>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessId>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessSessionId>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessStartInfoArguments>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessStartInfoDomain>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessStartInfoFileName>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessStartInfoWorkingDirectory>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessStartTime>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessSystemProcessorTime>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessUserProcessorTime>();
            PreferencesRenderersManager.AddPreferencesRenderer<ProcessWorkingSet>();
        }
    }
}