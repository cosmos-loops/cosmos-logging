using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.AliyunSls.Configurations;
using Cosmos.Logging.Sinks.AliyunSls.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Aliyun SLS sink options
    /// </summary>
    public class AliyunSlsSinkOptions : ILoggingSinkOptions<AliyunSlsSinkOptions>, ILoggingSinkOptions {
        /// <inheritdoc />
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public AliyunSlsSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public AliyunSlsSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
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
        public AliyunSlsSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public AliyunSlsSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public AliyunSlsSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
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
        public AliyunSlsSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public AliyunSlsSinkOptions UseAlias(string alias, LogEventLevel level) {
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
        public AliyunSlsSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public AliyunSlsSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public AliyunSlsSinkOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        /// <inheritdoc />
        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        #region Aliyun SLS options

        internal Dictionary<string, AliyunSlsNativeConfig> AliyunSlsNativeConfigs { get; } = new Dictionary<string, AliyunSlsNativeConfig>();

        /// <summary>
        /// Gets or sets log store name
        /// </summary>
        public string LogStoreName { get; set; }

        /// <summary>
        /// Gets or sets end point
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Gets or sets project name
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets access key id
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets access key
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Use Aliyun SLS native config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="nativeAct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AliyunSlsSinkOptions UseNativeConfig(string key, Action<AliyunSlsNativeConfig> nativeAct) {
            if (nativeAct == null)
                throw new ArgumentNullException(nameof(nativeAct));

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var cfg = new AliyunSlsNativeConfig();
            nativeAct(cfg);

            cfg.Check();

            if (AliyunSlsNativeConfigs.ContainsKey(key))
                AliyunSlsNativeConfigs[key] = cfg;
            else
                AliyunSlsNativeConfigs.Add(key, cfg);

            return this;
        }

        #endregion

    }
}