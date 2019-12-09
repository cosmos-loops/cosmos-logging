using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    internal static class LogEventLevelAliasManager {
        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<int, LogEventLevel> _aliasToRealLevelCache = new Dictionary<int, LogEventLevel>();

        // ReSharper disable once InconsistentNaming
        private static readonly object _aliasToRealLevelLock = new object();

        static LogEventLevelAliasManager() {
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Verbose.GetHashCode(), LogEventLevel.Verbose);
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Debug.GetHashCode(), LogEventLevel.Debug);
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Information.GetHashCode(), LogEventLevel.Information);
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Warning.GetHashCode(), LogEventLevel.Warning);
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Error.GetHashCode(), LogEventLevel.Error);
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Fatal.GetHashCode(), LogEventLevel.Fatal);
            _aliasToRealLevelCache.Add(LogEventLevelConstants.Off.GetHashCode(), LogEventLevel.Off);
        }

        public static void AddAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias)) return;
            if (!_aliasToRealLevelCache.ContainsKey(alias.GetHashCode())) {
                lock (_aliasToRealLevelLock) {
                    if (!_aliasToRealLevelCache.ContainsKey(alias.GetHashCode())) {
                        _aliasToRealLevelCache.Add(alias.GetHashCode(), level);
                    }
                }
            }
        }

        public static LogEventLevel? AliasToLevel(string alias) {
            return _aliasToRealLevelCache.TryGetValue(alias.GetHashCode(), out var ret) ? ret : default(LogEventLevel?);
        }

        public static LogEventLevel AliasToRealLevel(string alias, LogEventLevel defaultLevel = LogEventLevel.Verbose) {
            return AliasToLevel(alias) ?? defaultLevel;
        }

        public static bool SameMeaning(string alias1, string alias2) {
            if (string.IsNullOrWhiteSpace(alias1) || string.IsNullOrWhiteSpace(alias2)) return false;
            var hc1 = alias1.GetHashCode();
            var hc2 = alias2.GetHashCode();
            if (!_aliasToRealLevelCache.ContainsKey(hc1)) return false;
            if (!_aliasToRealLevelCache.ContainsKey(hc2)) return false;
            return _aliasToRealLevelCache[hc1] == _aliasToRealLevelCache[hc2];
        }
    }
}