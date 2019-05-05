using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Exceptionless.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class ExceptionlessSinkOptions : ILoggingSinkOptions<ExceptionlessSinkOptions>, ILoggingSinkOptions {
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public ExceptionlessSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public ExceptionlessSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public ExceptionlessSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public ExceptionlessSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public ExceptionlessSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentNullException(nameof(categoryName));
            categoryName = $"{categoryName}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(categoryName)) {
                InternalNavigatorLogEventLevels[categoryName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(categoryName, level);
            }

            return this;
        }

        public ExceptionlessSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public ExceptionlessSinkOptions UseAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias)) return this;
            if (InternalAliases.ContainsKey(alias)) {
                InternalAliases[alias] = level;
            } else {
                InternalAliases.Add(alias, level);
            }

            return this;
        }

        #endregion

        #region Append configuration file path

        internal string OriginConfigFilePath { get; set; }
        internal FileTypes OriginConfigFileType { get; set; } = FileTypes.Json;

        public ExceptionlessSinkOptions RemoveConfig() {
            OriginConfigFilePath = string.Empty;
            OriginConfigFileType = FileTypes.Json;
            return this;
        }

        public ExceptionlessSinkOptions UseAppSettings(string environmentName = "") {
            UseJsonConfig(string.IsNullOrWhiteSpace(environmentName) ? "appsettings.json" : $"appsettings.{environmentName}.json");
            return this;
        }

        public ExceptionlessSinkOptions UseJsonConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.Json;
            return this;
        }

        public ExceptionlessSinkOptions UseXmlConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.Xml;
            return this;
        }

        #endregion

        #region Append api key

        internal string ApiKey { get; set; }

        public ExceptionlessSinkOptions UseApiKey(string apiKey) {
            ApiKey = apiKey;
            return this;
        }

        #endregion
        
        #region Append output

        private readonly RendingConfiguration _renderingOptions = new RendingConfiguration();

        public ExceptionlessSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public ExceptionlessSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        public ExceptionlessSinkOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        public RendingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion
    }
}