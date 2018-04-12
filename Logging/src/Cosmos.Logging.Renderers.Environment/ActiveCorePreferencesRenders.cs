using System;
using System.Collections.Generic;
using Cosmos.Logging.Renderers.Environment.RendersLib;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Renderers.Environment {
    public static class EnvironmentRenderersActivation {
        private static readonly List<Type> _default = new List<Type> {
            typeof(EnvironmentCommandLine),
            typeof(EnvironmentCurrentDirectory),
            typeof(EnvironmentCurrentThreadId),
            typeof(EnvironmentMachineName),
            typeof(EnvironmentOsBits),
            typeof(EnvironmentOsName),
            typeof(EnvironmentOsVersion),
            typeof(EnvironmentOsStandardVersion),
            typeof(EnvironmentOsInterimVersion),
            typeof(EnvironmentProcessBits),
            typeof(EnvironmentStackTrace),
            typeof(EnvironmentSystemProcessorCount),
            typeof(EnvironmentUserDomainName),
            typeof(EnvironmentUserName)
        };

        public static IReadOnlyList<Type> Default => _default;

        public static void ActiveEnvironmentPreferencesRenders() {
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentCommandLine>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentCurrentDirectory>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentCurrentThreadId>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentMachineName>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentOsBits>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentOsName>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentOsVersion>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentOsStandardVersion>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentOsInterimVersion>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentProcessBits>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentStackTrace>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentSystemProcessorCount>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentUserDomainName>();
            PreferencesRenderersManager.AddPreferencesRenderer<EnvironmentUserName>();
        }
    }
}