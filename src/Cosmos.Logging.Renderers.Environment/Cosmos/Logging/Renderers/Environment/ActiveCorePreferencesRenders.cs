using System;
using System.Collections.Generic;
using Cosmos.Logging.Renderers.Environment.RendersLib;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Renderers.Environment {
    /// <summary>
    /// Environment renderers activation
    /// </summary>
    public static class EnvironmentRenderersActivation {
        // ReSharper disable once InconsistentNaming
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

        /// <summary>
        /// Gets default renderer types
        /// </summary>
        public static IReadOnlyList<Type> Default => _default;

        /// <summary>
        /// Active environment preferences renderers
        /// </summary>
        public static void ActiveEnvironmentPreferencesRenderers() {
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