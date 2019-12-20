namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event level converter
    /// </summary>
    public static class LogEventLevelConverter {
        /// <summary>
        /// Convert alias to log event level. If do not matched, return the default level.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="defaultLevel"></param>
        /// <returns></returns>
        internal static LogEventLevel Convert(string level, LogEventLevel defaultLevel = LogEventLevel.Verbose) {
            return EnumsNET.Enums.TryParse(level, false, out LogEventLevel logEventLevel)
                ? logEventLevel
                : LogEventLevelAliasManager.AliasToRealLevel(level, defaultLevel);
        }

        /// <summary>
        /// Convert level to system level alias.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string Convert(LogEventLevel level) {
            return LogEventLevelAliasManager.LevelToSystemLevelAlias(level);
        }
        
        /// <summary>
        /// Convert level to system level alias.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string Convert(LogEventLevel? level) {
            return LogEventLevelAliasManager.LevelToSystemLevelAlias(level);
        }

        /// <summary>
        /// Convert level to alias with length limited.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="aliasLength"></param>
        /// <returns></returns>
        public static string Convert(LogEventLevel level, int aliasLength) {
            return LogEventLevelAliasManager.LevelToAlias(level, aliasLength);
        }
        
        /// <summary>
        /// Convert level to alias with length limited.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="aliasLength"></param>
        /// <returns></returns>
        public static string Convert(LogEventLevel? level, int aliasLength) {
            return LogEventLevelAliasManager.LevelToAlias(level, aliasLength);
        }
    }
}