using System;
using Exceptionless;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Sinks.Exceptionless.Core {
    public static class ExceptionlessExtensions {
        /// <summary>
        /// Sets the configuration from .net configuration settings.
        /// </summary>
        /// <param name="config">The configuration object you want to apply the settings to.</param>
        /// <param name="settings">The configuration settings</param>
        public static void ReadFromConfiguration(this ExceptionlessConfiguration config, IConfiguration settings) {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var section = settings.GetSection("Exceptionless");

            string apiKey = section["ApiKey"];
            if (!String.IsNullOrEmpty(apiKey) && apiKey != "API_KEY_HERE")
                config.ApiKey = apiKey;

            foreach (var data in section.GetSection("DefaultData").GetChildren())
                if (data.Value != null)
                    config.DefaultData[data.Key] = data.Value;

            foreach (var tag in section.GetSection("DefaultTags").GetChildren())
                config.DefaultTags.Add(tag.Value);

            bool enabled;
            if (Boolean.TryParse(section["Enabled"], out enabled) && !enabled)
                config.Enabled = false;

            bool includePrivateInformation;
            if (Boolean.TryParse(section["IncludePrivateInformation"], out includePrivateInformation) && !includePrivateInformation)
                config.IncludePrivateInformation = false;

            string serverUrl = section["ServerUrl"];
            if (!String.IsNullOrEmpty(serverUrl))
                config.ServerUrl = serverUrl;

            foreach (var setting in section.GetSection("Settings").GetChildren())
                if (setting.Value != null)
                    config.Settings[setting.Key] = setting.Value;
        }
    }
}