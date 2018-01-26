using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Filters {
    internal static class NavigationFilterProcessor {
        private static INamespaceNavigationMatcher GlobalNavigationMatcher { get; set; }
        private static readonly Dictionary<string, INamespaceNavigationMatcher> _sinkFilterNavMatchers;
        private static readonly Dictionary<string, LogEventLevel> _defaultLevel;
        private static readonly object _sinkFilterNavMatcherLock = new object();


        static NavigationFilterProcessor() {
            _sinkFilterNavMatchers = new Dictionary<string, INamespaceNavigationMatcher>();
            _defaultLevel = new Dictionary<string, LogEventLevel>();
        }

        internal static void SetGlobalFilterNavMatcher(INamespaceNavigationMatcher matcher, string defaultLevel) {
            GlobalNavigationMatcher = matcher ?? throw new ArgumentNullException(nameof(matcher));

            lock (_sinkFilterNavMatcherLock) {
                if (_defaultLevel.ContainsKey("Global")) {
                    _defaultLevel["Global"] = LogEventLevelConverter.Convert(defaultLevel);
                } else {
                    _defaultLevel.Add("Global", LogEventLevelConverter.Convert(defaultLevel));
                }
            }
        }

        internal static void SetSinkFilterNavMatcher(string name, INamespaceNavigationMatcher matcher, string defaultLevel) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (matcher == null) throw new ArgumentNullException(nameof(matcher));

            lock (_sinkFilterNavMatcherLock) {
                if (_sinkFilterNavMatchers.ContainsKey(name)) {
                    _sinkFilterNavMatchers[name] = matcher;
                    _defaultLevel[name] = LogEventLevelConverter.Convert(defaultLevel);
                } else {
                    _sinkFilterNavMatchers.Add(name, matcher);
                    _defaultLevel.Add(name, LogEventLevelConverter.Convert(defaultLevel));
                }
            }
        }

        public static LogEventLevel GetDefault() => _defaultLevel.TryGetValue("Global", out var ret) ? ret : LogEventLevel.Verbose;

        public static LogEventLevel GetDefault(string sinkName) => _defaultLevel.TryGetValue(sinkName, out var ret) ? ret : LogEventLevel.Verbose;
    }
}