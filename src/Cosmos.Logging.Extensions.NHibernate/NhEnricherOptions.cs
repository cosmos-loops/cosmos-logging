using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.NHibernate.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class NhEnricherOptions : ILoggingSinkOptions<NhEnricherOptions>, ILoggingSinkOptions {

        public NhEnricherOptions() { }

        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public NhEnricherOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public NhEnricherOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public NhEnricherOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public NhEnricherOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public NhEnricherOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentNullException(nameof(categoryName));
            categoryName = $"{categoryName}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(categoryName)) {
                InternalNavigatorLogEventLevels[categoryName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(categoryName, level);
            }

            return this;
        }

        public NhEnricherOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public NhEnricherOptions UseAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias)) return this;
            if (InternalAliases.ContainsKey(alias)) {
                InternalAliases[alias] = level;
            } else {
                InternalAliases.Add(alias, level);
            }

            return this;
        }

        #endregion

        #region Appeng filter

        internal Func<string, LogEventLevel, bool> Filter { get; set; }

        public NhEnricherOptions UseFilter(Func<string, LogEventLevel, bool> filter) {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var temp = Filter;
            Filter = (s, l) => (temp?.Invoke(s, l) ?? true) && filter(s, l);

            return this;
        }

        #endregion
        
        #region Append output

        private readonly RendingConfiguration _renderingOptions = new RendingConfiguration();

        public NhEnricherOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public NhEnricherOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }
        
        public NhEnricherOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        public RendingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

    }
}