using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Navigators;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Sink configuration
    /// </summary>
    public abstract class SinkConfiguration {
        /// <summary>
        /// Name
        /// </summary>
        public readonly string Name;

        private readonly NamespaceNavigatorCache _namespaceNavigatorCache;
        private readonly List<NamespaceNavigator> _namespaceFilterNavRoots = new List<NamespaceNavigator>();
        private readonly object _parsedLgLevelLock = new object();

        /// <summary>
        /// Create a new instance of <see cref="SinkConfiguration"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected SinkConfiguration(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            _namespaceNavigatorCache = new NamespaceNavigatorCache(new NamespaceNavigationParser());
            Name = name;
        }

        /// <summary>
        /// Gets or sets log level
        /// </summary>
        public Dictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets aliases
        /// </summary>
        public Dictionary<string, string> Aliases { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets namespace filter navs
        /// </summary>
        public IReadOnlyList<NamespaceNavigator> NamespaceFilterNavs => _namespaceFilterNavRoots;

        /// <summary>
        /// Before provessing
        /// </summary>
        /// <param name="settings"></param>
        protected internal abstract void BeforeProcessing(ILoggingSinkOptions settings);

        internal void ProcessLogLevel<TSinkSettings>(TSinkSettings settings) where TSinkSettings : class, ILoggingSinkOptions, new() {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            foreach (var item in LogLevel) {
                var nav = _namespaceNavigatorCache.Parse(item.Key, item.Value, out _);
                if (nav is EmptyNamespaceNavigationNode) continue;
                if (!_namespaceFilterNavRoots.Contains(nav)) {
                    lock (_parsedLgLevelLock) {
                        if (!_namespaceFilterNavRoots.Contains(nav)) {
                            _namespaceFilterNavRoots.Add(nav);
                        }
                    }
                }
            }

            NavigationFilterProcessor.SetSinkFilterNavMatcher(Name, _namespaceNavigatorCache,
                LogLevel.TryGetValue("Default", out var x) ? x : LogEventLevelConstants.Verbose);

            foreach (var item in Aliases) {
                LogEventLevelAliasManager.AddAlias(item.Key, LogEventLevelConverter.Convert(item.Value));
            }
        }

        /// <summary>
        /// Post processing
        /// </summary>
        /// <param name="settings"></param>
        protected internal virtual void PostProcessing(ILoggingSinkOptions settings) { }

        /// <summary>
        /// Get default minimum level
        /// </summary>
        /// <returns></returns>
        public LogEventLevel GetDefaultMinimumLevel() => NavigationFilterProcessor.GetDefault(Name);

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
        /// Gets or sets rendering.
        /// </summary>
        public RenderingConfiguration Rendering { get; set; } = new RenderingConfiguration();

        internal void ProcessRenderingOptions<TSinkSettings>(TSinkSettings settings) where TSinkSettings : class, ILoggingSinkOptions, new() {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            Rendering.ImportFromSettings(settings.GetRenderingOptions());
        }
    }
}