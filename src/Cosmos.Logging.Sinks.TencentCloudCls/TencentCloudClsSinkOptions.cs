using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.TencentCloudCls.Configurations;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public class TencentCloudClsSinkOptions : ILoggingSinkOptions<TencentCloudClsSinkOptions>, ILoggingSinkOptions
    {
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public TencentCloudClsSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public TencentCloudClsSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName))
            {
                InternalNavigatorLogEventLevels[typeName] = level;
            }
            else
            {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public TencentCloudClsSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public TencentCloudClsSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public TencentCloudClsSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level)
        {
            if (string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentNullException(nameof(categoryName));
            categoryName = $"{categoryName}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(categoryName))
            {
                InternalNavigatorLogEventLevels[categoryName] = level;
            }
            else
            {
                InternalNavigatorLogEventLevels.Add(categoryName, level);
            }

            return this;
        }

        public TencentCloudClsSinkOptions UseMinimumLevel(LogEventLevel? level)
        {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public TencentCloudClsSinkOptions UseAlias(string alias, LogEventLevel level)
        {
            if (string.IsNullOrWhiteSpace(alias)) return this;
            if (InternalAliases.ContainsKey(alias))
            {
                InternalAliases[alias] = level;
            }
            else
            {
                InternalAliases.Add(alias, level);
            }

            return this;
        }

        #endregion

        #region Append output

        private readonly RendingConfiguration _renderingOptions = new RendingConfiguration();

        public TencentCloudClsSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled)
        {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public TencentCloudClsSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled)
        {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        public TencentCloudClsSinkOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled)
        {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        public RendingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        #region JD Cloud Log Service options

        internal Dictionary<string, TencentCloudClsNativeConfig> TencentCloudClsNativeConfigs { get; } = new Dictionary<string, TencentCloudClsNativeConfig>();

        public string RequestUri { get; set; }

        public string SecretId { get; set; }

        public string SecretKey { get; set; }

        public string TopicId { get; set; }

        public int RequestTimeout { get; set; } = 5;

        public TencentCloudClsSinkOptions UseNativeConfig(string key, Action<TencentCloudClsNativeConfig> nativeAct)
        {
            if (nativeAct == null)
                throw new ArgumentNullException(nameof(nativeAct));

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var cfg = new TencentCloudClsNativeConfig();
            nativeAct(cfg);

            cfg.Check();

            if (TencentCloudClsNativeConfigs.ContainsKey(key))
                TencentCloudClsNativeConfigs[key] = cfg;
            else
                TencentCloudClsNativeConfigs.Add(key, cfg);

            return this;
        }

        #endregion

    }
}