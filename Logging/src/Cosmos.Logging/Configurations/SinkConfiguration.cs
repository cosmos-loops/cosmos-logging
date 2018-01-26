using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using EnumsNET;

namespace Cosmos.Logging.Configurations {
    public abstract class SinkConfiguration {
        public readonly string Name;
        private readonly List<NamespaceFilterNav> _namespaceFilterNavRoots = new List<NamespaceFilterNav>();
        private readonly object _parsedLgLevelLock = new object();

        protected SinkConfiguration(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        public Dictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();

        public IReadOnlyList<NamespaceFilterNav> NamespaceFilterNavs => _namespaceFilterNavRoots;

        internal void UpdateParsedLogLevel(INamespaceFilterNavParser parser) {
            foreach (var item in LogLevel) {
                var nav = parser.Parse(item.Key, item.Value, out _);
                if (nav is EmptyNamespaceFilterNav) continue;
                if (!_namespaceFilterNavRoots.Contains(nav)) {
                    lock (_parsedLgLevelLock) {
                        if (!_namespaceFilterNavRoots.Contains(nav)) {
                            _namespaceFilterNavRoots.Add(nav);
                        }
                    }
                }
            }
        }

        public LogEventLevel GetDefaultMinimumLevel() {
            return LogLevel.TryGetValue("Default", out var strLevel)
                ? Enums.GetMember<LogEventLevel>(strLevel, true).Value
                : LogEventLevel.Verbose;
        }
    }
}