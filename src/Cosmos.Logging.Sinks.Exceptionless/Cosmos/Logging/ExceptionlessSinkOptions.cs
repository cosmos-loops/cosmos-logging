using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Exceptionless.Internals;

namespace Cosmos.Logging {
    /// <summary>
    /// Exceptionless sink options
    /// </summary>
    public class ExceptionlessSinkOptions : ILoggingSinkOptions<ExceptionlessSinkOptions>, ILoggingSinkOptions {
        /// <inheritdoc />
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public ExceptionlessSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public ExceptionlessSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
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
        public ExceptionlessSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public ExceptionlessSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public ExceptionlessSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
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
        public ExceptionlessSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public ExceptionlessSinkOptions UseAlias(string alias, LogEventLevel level) {
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

        #region Append configuration file path

        internal string OriginalConfigFilePath { get; set; }
        internal FileTypes OriginalConfigFileType { get; set; } = FileTypes.Json;

        /// <summary>
        /// Remove config
        /// </summary>
        /// <returns></returns>
        public ExceptionlessSinkOptions RemoveConfig() {
            OriginalConfigFilePath = string.Empty;
            OriginalConfigFileType = FileTypes.Json;
            return this;
        }

        /// <summary>
        /// Use app setting
        /// </summary>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        public ExceptionlessSinkOptions UseAppSettings(string environmentName = "") {
            UseJsonConfig(string.IsNullOrWhiteSpace(environmentName) ? "appsettings.json" : $"appsettings.{environmentName}.json");
            return this;
        }

        /// <summary>
        /// Use json config
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ExceptionlessSinkOptions UseJsonConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginalConfigFilePath = path;
            OriginalConfigFileType = FileTypes.Json;
            return this;
        }

        /// <summary>
        /// Use xml config
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ExceptionlessSinkOptions UseXmlConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginalConfigFilePath = path;
            OriginalConfigFileType = FileTypes.Xml;
            return this;
        }

        /// <summary>
        /// Yse yaml config
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ExceptionlessSinkOptions UseYamlConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginalConfigFilePath = path;
            OriginalConfigFileType = FileTypes.Yaml;
            return this;
        }

        #endregion

        #region Append api key

        internal string ApiKey { get; set; }

        /// <summary>
        /// Use ApiKey
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public ExceptionlessSinkOptions UseApiKey(string apiKey) {
            ApiKey = apiKey;
            return this;
        }

        #endregion

        #region Append output

        private readonly RenderingConfiguration _renderingOptions = new RenderingConfiguration();

        /// <inheritdoc />
        public ExceptionlessSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public ExceptionlessSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public ExceptionlessSinkOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        /// <inheritdoc />
        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

    }
}