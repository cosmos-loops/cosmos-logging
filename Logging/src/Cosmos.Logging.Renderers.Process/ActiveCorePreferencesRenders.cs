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
            PreferencesRenderManager.AddPreferencesRenderer<ProcessBasePriority>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessPagedMemorySize>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessNonpagedSystemMemorySize>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessPagedSystemMemorySize>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessVirtualMemorySize>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessPrivateMemorySize>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessName>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessId>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessSessionId>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessStartInfoArguments>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessStartInfoDomain>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessStartInfoFileName>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessStartInfoWorkingDirectory>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessStartTime>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessSystemProcessorTime>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessUserProcessorTime>();
            PreferencesRenderManager.AddPreferencesRenderer<ProcessWorkingSet>();
        }
    }
}