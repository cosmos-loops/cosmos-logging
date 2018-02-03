using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public class LoggingOptions : ILoggingOptions {

        #region Instance

        private static readonly LoggingOptions DefaultSetingsCache = new LoggingOptions();

        public static LoggingOptions Defaults => DefaultSetingsCache;

        #endregion

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public LoggingOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public LoggingOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public LoggingOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public LoggingOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public LoggingOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentNullException(nameof(categoryName));
            categoryName = $"{categoryName}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(categoryName)) {
                InternalNavigatorLogEventLevels[categoryName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(categoryName, level);
            }

            return this;
        }

        public LoggingOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public LoggingOptions UseAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias)) return this;
            if (InternalAliases.ContainsKey(alias)) {
                InternalAliases[alias] = level;
            } else {
                InternalAliases.Add(alias, level);
            }

            return this;
        }

        #endregion

        #region Append output

        internal bool? DisplayingCallerInfoEnabled { get; private set; }

        internal bool? DisplayingEventIdInfoEnabled { get; private set; }

        internal bool? DisplayingNewLineEomEnabled { get; private set; }

        public LoggingOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public LoggingOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        public LoggingOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled) {
            DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        #endregion

        public Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }
    }
}