using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.File;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class FileSinkOptions : ILoggingSinkOptions<FileSinkOptions>, ILoggingSinkOptions {
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public FileSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public FileSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public FileSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public FileSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public FileSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentNullException(nameof(categoryName));
            categoryName = $"{categoryName}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(categoryName)) {
                InternalNavigatorLogEventLevels[categoryName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(categoryName, level);
            }

            return this;
        }

        public FileSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public FileSinkOptions UseAlias(string alias, LogEventLevel level) {
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

        private readonly RenderingConfiguration _renderingOptions = new RenderingConfiguration();

        public FileSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public FileSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        public FileSinkOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        #region Append output template

        internal string RealDefaultOutputTemplate { get; set; } = Constants.DefaultOutputTemplate;

        public FileSinkOptions SetDefaultOutputTemplate(string template) {
            RealDefaultOutputTemplate = string.IsNullOrWhiteSpace(template) ? Constants.DefaultOutputTemplate : template;
            return this;
        }

        #endregion

        #region Append writing options

        internal Dictionary<string, OutputOptions> OutputOptionsInternal { get; set; } = new Dictionary<string, OutputOptions>();
        private readonly List<string> _registeredPath = new List<string>();

        public FileSinkOptions AddStrategy(
            string strategyName,
            string fileName,
            PathType pathType = PathType.Relative,
            TimeSpan? flushToDiskInterval = null,
            RollingInterval rollingInterval = RollingInterval.Infinite,
            List<string> namespaceList = null, string outputTemplate = null) {
            if (string.IsNullOrWhiteSpace(strategyName)) throw new ArgumentNullException(nameof(strategyName));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            var u = $"{_registeredPath}-{pathType.GetName()}";

            if (_registeredPath.Contains(u)) throw new ArgumentException("Multiple definitions");
            if (string.IsNullOrWhiteSpace(outputTemplate)) outputTemplate = RealDefaultOutputTemplate;
            if (namespaceList == null || !namespaceList.Any()) namespaceList = new List<string> {"*"};

            OutputOptionsInternal.Add(
                strategyName,
                new OutputOptions {
                    Path = fileName,
                    Template = outputTemplate,
                    PathType = pathType,
                    FlushToDiskInterval = flushToDiskInterval,
                    Rolling = rollingInterval,
                    Navigators = namespaceList
                });
            _registeredPath.Add(u);

            return this;
        }

        #endregion

    }
}