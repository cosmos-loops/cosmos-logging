using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Internals;

namespace Cosmos.Logging.Sinks.Console
{
    public class ConsoleSinkOptions : ILoggingSinkOptions<ConsoleSinkOptions>, ILoggingSinkOptions
    {
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public ConsoleSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public ConsoleSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level)
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

        public ConsoleSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public ConsoleSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public ConsoleSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level)
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

        public ConsoleSinkOptions UseMinimumLevel(LogEventLevel? level)
        {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public ConsoleSinkOptions UseAlias(string alias, LogEventLevel level)
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

        private readonly RenderingConfiguration _renderingOptions = new RenderingConfiguration();

        public ConsoleSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled)
        {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public ConsoleSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled)
        {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        public ConsoleSinkOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled)
        {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        #region Console configuration

        internal bool? InternalColorEnabled { get; set; }

        public bool ColorEnabled
        {
            get => InternalColorEnabled.HasValue ? InternalColorEnabled.Value : false;
            set => InternalColorEnabled = value;
        }

        #endregion

    }
}