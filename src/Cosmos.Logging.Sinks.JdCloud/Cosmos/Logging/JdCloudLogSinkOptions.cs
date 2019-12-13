using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.JdCloud.Configurations;
using Cosmos.Logging.Sinks.JdCloud.Internals;

namespace Cosmos.Logging {
    /// <summary>
    /// JdCLoud log service sink options
    /// </summary>
    public class JdCloudLogSinkOptions : ILoggingSinkOptions<JdCloudLogSinkOptions>, ILoggingSinkOptions {
        /// <inheritdoc />
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public JdCloudLogSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public JdCloudLogSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
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
        public JdCloudLogSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public JdCloudLogSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public JdCloudLogSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
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
        public JdCloudLogSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public JdCloudLogSinkOptions UseAlias(string alias, LogEventLevel level) {
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

        private readonly RenderingConfiguration _renderingOptions = new RenderingConfiguration();

        /// <inheritdoc />
        public JdCloudLogSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public JdCloudLogSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public JdCloudLogSinkOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        /// <inheritdoc />
        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        #region JD Cloud Log Service options

        internal Dictionary<string, JdCloudNativeConfig> JdCloudLogNativeConfigs { get; } = new Dictionary<string, JdCloudNativeConfig>();

        /// <summary>
        /// Gets or sets LogStreamName
        /// </summary>
        public string LogStreamName { get; set; }

        /// <summary>
        /// Gets or sets AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets security
        /// </summary>
        public bool Security { get; set; }

        /// <summary>
        /// Gets or sets retry time, default is 3
        /// </summary>
        public int RetryTimes { get; set; } = 3;

        /// <summary>
        /// Gets or sets request timeout value, default is 5
        /// </summary>
        public int RequestTimeout { get; set; } = 5;

        /// <summary>
        /// Use JdCloud Log Service native config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="nativeAct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public JdCloudLogSinkOptions UseNativeConfig(string key, Action<JdCloudNativeConfig> nativeAct) {
            if (nativeAct == null)
                throw new ArgumentNullException(nameof(nativeAct));

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var cfg = new JdCloudNativeConfig();
            nativeAct(cfg);

            cfg.Check();

            if (JdCloudLogNativeConfigs.ContainsKey(key))
                JdCloudLogNativeConfigs[key] = cfg;
            else
                JdCloudLogNativeConfigs.Add(key, cfg);

            return this;
        }

        #endregion

    }
}