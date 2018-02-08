using Cosmos.Logging.Renders.RendersLib;

namespace Cosmos.Logging.Renders {
    internal static class CoreRenderActivation {
        public static void ActiveCorePreferencesRenders() {
            PreferencesRenderManager.AddPreferencesRenderer<DateRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerMemberNameRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerFilePathRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<CallerLineNumberRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<EventIdRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<EventNameRenderer>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentCommandLine>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentCurrentDirectory>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentCurrentThreadId>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentMachineName>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentOsBits>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentOsName>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentOsVersion>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentOsStandardVersion>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentOsInterimVersion>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentProcessBits>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentStackTrace>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentSystemProcessorCount>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentUserDomainName>();
            PreferencesRenderManager.AddPreferencesRenderer<EnvironmentUserName>();
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