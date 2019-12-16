using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Navigators;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging {
    /// <summary>
    /// Logging configuration
    /// </summary>
    public partial class LoggingConfiguration {
        private readonly ILoggingOptions _loggingSettings;
        private readonly IConfigurationRoot _loggingConfiguration;
        private readonly NamespaceNavigatorCache _namespaceNavigatorCache;
        private readonly List<NamespaceNavigator> _namespaceFilterNavRoots = new List<NamespaceNavigator>();

        /// <summary>
        /// Create a new instance of <see cref="LoggingConfiguration"/>.
        /// </summary>
        public LoggingConfiguration() { }

        /// <summary>
        /// Create a new instance of <see cref="LoggingConfiguration"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public LoggingConfiguration(ILoggingOptions settings, IConfigurationRoot loggingConfiguration) {
            _loggingSettings = settings ?? throw new ArgumentNullException(nameof(settings));
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
            _namespaceNavigatorCache = new NamespaceNavigatorCache(new NamespaceNavigationParser());
            SetSelf(loggingConfiguration.GetSection("Logging").Get<LoggingConfiguration>());
        }

        /// <summary>
        /// Include scopes
        /// </summary>
        public bool IncludeScopes { get; set; }

        /// <summary>
        /// Log level
        /// </summary>
        public Dictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Aliases
        /// </summary>
        public Dictionary<string, string> Aliases { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Namespace filter navigations
        /// </summary>
        public IReadOnlyList<NamespaceNavigator> NamespaceFilterNavs => _namespaceFilterNavRoots;

        /// <summary>
        /// Gets default minimum level
        /// </summary>
        /// <returns></returns>
        public LogEventLevel GetDefaultMinimumLevel() => NavigationFilterProcessor.GetDefault();

        /// <summary>
        /// Get minimum level
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        public LogEventLevel GetMinimumLevel(string @namespace) {
            return string.IsNullOrWhiteSpace(@namespace)
                ? GetDefaultMinimumLevel()
                : _namespaceNavigatorCache.Match(@namespace, out var nav)
                    ? nav.GetValue().Level
                    : GetDefaultMinimumLevel();
        }

        /// <summary>
        /// Gets or sets rendering configuration
        /// </summary>
        public RenderingConfiguration Rendering { get; set; } = new RenderingConfiguration();

        /// <summary>
        /// Gets or sets destructure configuration
        /// </summary>
        public DestructureConfiguration Destructure { get; set; }

        /// <summary>
        /// Gets configuration root
        /// </summary>
        public IConfigurationRoot Configuration => _loggingConfiguration;
    }
}