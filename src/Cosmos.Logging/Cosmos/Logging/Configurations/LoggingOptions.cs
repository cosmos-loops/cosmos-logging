using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Logging options
    /// </summary>
    public class LoggingOptions : ILoggingOptions {

        #region Instance

        private static readonly LoggingOptions DefaultSettingsCache = new LoggingOptions();

        /// <summary>
        /// Gets default logging options
        /// </summary>
        public static LoggingOptions Defaults => DefaultSettingsCache;

        #endregion

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public LoggingOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public LoggingOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            }
            else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        /// <inheritdoc />
        public LoggingOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public LoggingOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public LoggingOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentNullException(nameof(categoryName));
            categoryName = $"{categoryName}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(categoryName)) {
                InternalNavigatorLogEventLevels[categoryName] = level;
            }
            else {
                InternalNavigatorLogEventLevels.Add(categoryName, level);
            }

            return this;
        }

        /// <inheritdoc />
        public LoggingOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public LoggingOptions UseAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias)) return this;
            if (InternalAliases.ContainsKey(alias)) {
                InternalAliases[alias] = level;
            }
            else {
                InternalAliases.Add(alias, level);
            }

            return this;
        }

        #endregion

        #region Append output

        internal RenderingConfiguration Rendering = new RenderingConfiguration();

        /// <inheritdoc />
        public LoggingOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            Rendering.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public LoggingOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            Rendering.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public LoggingOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            Rendering.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        #endregion

        #region Append scan renderers

        internal bool AutomaticScanRendererEnabled { get; set; } = true;

        internal List<Type> ManuallyRendererTypes { get; set; } = new List<Type>();

        /// <inheritdoc />
        public LoggingOptions AutomaticScanRenderers() {
            AutomaticScanRendererEnabled = true;
            return this;
        }

        /// <inheritdoc />
        public LoggingOptions ManuallyRendererConfigure(params Type[] preferencesRendererTypes) {
            AutomaticScanRendererEnabled = false;
            ManuallyRendererTypes.AddRange(preferencesRendererTypes);
            return this;
        }

        #endregion

        /// <inheritdoc />
        public Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }
    }
}