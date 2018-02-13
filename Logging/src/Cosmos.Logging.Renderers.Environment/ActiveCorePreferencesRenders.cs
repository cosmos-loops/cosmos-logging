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
        }
    }
}