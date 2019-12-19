using System.Collections.Generic;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Events {
    internal static class LogEventLevelAliasManager {
        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<int, LogEventLevel> _aliasToRealLevelCache = new Dictionary<int, LogEventLevel>();
        private static readonly Dictionary<LogEventLevel, string> _systemLevelAlias = new Dictionary<LogEventLevel, string>();
        private static readonly Dictionary<(LogEventLevel, int), string> _lengthLimitedAlias = new Dictionary<(LogEventLevel, int), string>();

        // ReSharper disable once InconsistentNaming
        private static readonly object _aliasToRealLevelLock = new object();

        // ReSharper disable once InconsistentNaming
        private const string LEVEL_OFF = LogEventLevelConstants.Off;

        static LogEventLevelAliasManager() {
            InitToRealLevel();
            InitToSystemLevelAlias();
        }

        #region Init

        private static void InitToRealLevel() {
#if NETCOREAPP3_1 || NETSTANDARD2_1
            foreach (var (key, value) in LogEventLevelAlias.InlineAlias) {
#else
            foreach (var aliasList in LogEventLevelAlias.InlineAlias) {
                var key = aliasList.Key;
                var value = aliasList.Value;
#endif
                foreach (var alias in value) {
                    AddAlias(alias, key);
                }
            }
        }

        private static void InitToSystemLevelAlias() {
            _systemLevelAlias.Add(LogEventLevel.Verbose, LogEventLevelConstants.Verbose);
            _systemLevelAlias.Add(LogEventLevel.Debug, LogEventLevelConstants.Debug);
            _systemLevelAlias.Add(LogEventLevel.Information, LogEventLevelConstants.Information);
            _systemLevelAlias.Add(LogEventLevel.Warning, LogEventLevelConstants.Warning);
            _systemLevelAlias.Add(LogEventLevel.Error, LogEventLevelConstants.Error);
            _systemLevelAlias.Add(LogEventLevel.Fatal, LogEventLevelConstants.Fatal);
            _systemLevelAlias.Add(LogEventLevel.Off, LogEventLevelConstants.Off);
        }

        #endregion

        public static void AddAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias))
                return;

            lock (_aliasToRealLevelLock) {
                if (!_aliasToRealLevelCache.ContainsKey(alias.GetHashCode())) {
                    _aliasToRealLevelCache.Add(alias.GetHashCode(), level);
                }

                if (!_lengthLimitedAlias.ContainsKey((level, alias.Length))) {
                    _lengthLimitedAlias.Add((level, alias.Length), alias);
                }
            }
        }

        public static LogEventLevel? AliasToLevel(string alias) {
            return _aliasToRealLevelCache.TryGetValue(alias.GetHashCode(), out var ret) ? ret : default(LogEventLevel?);
        }

        public static LogEventLevel AliasToRealLevel(string alias, LogEventLevel defaultLevel = LogEventLevel.Verbose) {
            return AliasToLevel(alias) ?? defaultLevel;
        }

        public static string LevelToSystemLevelAlias(LogEventLevel level) {
            return _systemLevelAlias.TryGetValue(level, out var alias) ? alias : LEVEL_OFF;
        }

        public static string LevelToSystemLevelAlias(LogEventLevel? level) {
            return level.HasValue ? LevelToSystemLevelAlias(level.Value) : LEVEL_OFF;
        }

        public static string LevelToAlias(LogEventLevel level, int aliasLength) {
            return _lengthLimitedAlias.TryGetValue((level, aliasLength), out var alias) ? alias : LevelToSystemLevelAlias(level);
        }

        public static string LevelToAlias(LogEventLevel? level, int aliasLength) {
            return level.HasValue ? LevelToAlias(level.Value, aliasLength) : LevelToAlias(LogEventLevel.Off, aliasLength);
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