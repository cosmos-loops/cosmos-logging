using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using EnumsNET;

namespace Cosmos.Logging.Configurations {
    public abstract class SinkConfiguration {
        public readonly string Name;
        private readonly NamespaceNavigatorCache _namespaceNavigatorCache;
        private readonly List<NamespaceNavigator> _namespaceFilterNavRoots = new List<NamespaceNavigator>();
        private readonly object _parsedLgLevelLock = new object();

        protected SinkConfiguration(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            _namespaceNavigatorCache = new NamespaceNavigatorCache(new NamespaceNavigationParser());
            Name = name;
        }

        public Dictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> Aliases { get; set; } = new Dictionary<string, string>();

        public IReadOnlyList<NamespaceNavigator> NamespaceFilterNavs => _namespaceFilterNavRoots;

        internal void ProcessLogLevel() {
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

        public LogEventLevel GetDefaultMinimumLevel() => NavigationFilterProcessor.GetDefault(Name);
    }
}