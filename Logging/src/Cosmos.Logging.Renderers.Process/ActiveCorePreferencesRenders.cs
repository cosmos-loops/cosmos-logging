using System;
using System.Collections.Generic;
using Cosmos.Logging.Renderers.Process.RendersLib;
using Cosmos.Logging.Renders;
using Cosmos.Logging.Renders.RendersLib;

namespace Cosmos.Logging.Renderers.Process {
    public static class ProcessRenderersActivation {
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

        public static IReadOnlyList<Type> Default => _default;

        public static void ActiveEnvironmentPreferencesRenders() {
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