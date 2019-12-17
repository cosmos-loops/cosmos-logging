using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.FreeSql.Core;
using FreeSql.Aop;

namespace Cosmos.Logging {
    /// <summary>
    /// FreeSql enricher options
    /// </summary>
    public class FreeSqlEnricherOptions : ILoggingSinkOptions<FreeSqlEnricherOptions>, ILoggingSinkOptions {

        /// <inheritdoc />
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public FreeSqlEnricherOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public FreeSqlEnricherOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type is null) throw new ArgumentNullException(nameof(type));
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
        public FreeSqlEnricherOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public FreeSqlEnricherOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type is null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public FreeSqlEnricherOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
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
        public FreeSqlEnricherOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public FreeSqlEnricherOptions UseAlias(string alias, LogEventLevel level) {
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

        #region Append Interceptor

        internal Action<Exception, CurdAfterEventArgs> ErrorInterceptorAction { get; set; }

        internal Action<CurdBeforeEventArgs> ExecutingInterceptorAction { get; set; }

        internal Action<CurdAfterEventArgs> ExecutedInterceptorAction { get; set; }

        /// <summary>
        /// Add executing interceptor
        /// </summary>
        /// <param name="executingInterceptor"></param>
        /// <returns></returns>
        public FreeSqlEnricherOptions AddExecutingInterceptor(Action<CurdBeforeEventArgs> executingInterceptor) {
            ExecutingInterceptorAction += executingInterceptor ?? throw new ArgumentNullException(nameof(executingInterceptor));
            return this;
        }

        /// <summary>
        /// Add executed interceptor
        /// </summary>
        /// <param name="executedInterceptor"></param>
        /// <returns></returns>
        public FreeSqlEnricherOptions AddExecutedInterceptor(Action<CurdAfterEventArgs> executedInterceptor) {
            ExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            return this;
        }

        /// <summary>
        /// Add error interceptor
        /// </summary>
        /// <param name="errorInterceptor"></param>
        /// <returns></returns>
        public FreeSqlEnricherOptions AddErrorInterceptor(Action<Exception, CurdAfterEventArgs> errorInterceptor) {
            ErrorInterceptorAction += errorInterceptor ?? throw new ArgumentNullException(nameof(errorInterceptor));
            return this;
        }

        #endregion

        #region Appeng filter

        internal Func<string, LogEventLevel, bool> Filter { get; set; }

        /// <summary>
        /// Add filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public FreeSqlEnricherOptions UseFilter(Func<string, LogEventLevel, bool> filter) {
            if (filter is null) throw new ArgumentNullException(nameof(filter));

            var temp = Filter;
            Filter = (s, l) => (temp?.Invoke(s, l) ?? true) && filter(s, l);

            return this;
        }

        #endregion

        #region Append output

        private readonly RenderingConfiguration _renderingOptions = new RenderingConfiguration();

        /// <inheritdoc />
        public FreeSqlEnricherOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public FreeSqlEnricherOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public FreeSqlEnricherOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        /// <inheritdoc />
        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

    }
}