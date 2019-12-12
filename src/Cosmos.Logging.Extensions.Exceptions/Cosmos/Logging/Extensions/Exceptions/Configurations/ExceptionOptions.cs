using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;
using Cosmos.Logging.Extensions.Exceptions.Filters;

namespace Cosmos.Logging.Extensions.Exceptions.Configurations {
    /// <summary>
    /// Exception options
    /// </summary>
    public class ExceptionOptions : ILoggingSinkOptions<ExceptionOptions>, ILoggingSinkOptions {
        private readonly DestructuringOptionsBuilder _builder;
        private readonly OptionUpdateStatus _builderChangedStatus;
        private Action<DestructuringOptionsBuilder> _additionalUpdateDestructurerOps { get; set; }

        /// <inheritdoc />
        public ExceptionOptions() {
            _builder = new DestructuringOptionsBuilder();
            _builderChangedStatus = new OptionUpdateStatus();
        }

        /// <inheritdoc />
        public string Key => Constants.SinkKey;

        #region DestructuringOptionsBuilder ops

        /// <summary>
        /// Gets or sets root name
        /// </summary>
        public string Name {
            get => _builder.Name;
            set => OpsBuildSetter(b => b.WithName(value), c => c.NameChanged = true);
        }

        /// <summary>
        /// Gets or sets destrcuture depth
        /// </summary>
        public int DestructureDepth {
            get => _builder.DestructureDepth;
            set => OpsBuildSetter(b => b.WithDepth(value), c => c.DepthChanged = true);
        }

        /// <summary>
        /// Gets destructurers witch have been set into the builder
        /// </summary>
        public IEnumerable<IExceptionDestructurer> Destructurers => _builder.Destructurers;

        /// <summary>
        /// Gets or sets exception property filter
        /// </summary>
        public IExceptionPropertyFilter ExceptionPropertyFilter {
            get => _builder.Filter;
            set => OpsBuildSetter(b => b.WithFilter(value));
        }

        /// <summary>
        /// Use root name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExceptionOptions UseName(string name) {
            Name = name;
            return this;
        }

        /// <summary>
        /// Use destrcuture depth
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public ExceptionOptions UseDestructureDepth(int depth) {
            DestructureDepth = depth;
            return this;
        }

        /// <summary>
        /// Use exception property filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ExceptionOptions UseFilter(IExceptionPropertyFilter filter) {
            ExceptionPropertyFilter = filter;
            return this;
        }

        /// <summary>
        /// Use exception property filter
        /// </summary>
        /// <typeparam name="TFilter"></typeparam>
        /// <returns></returns>
        public ExceptionOptions UseFilter<TFilter>() where TFilter : class, IExceptionPropertyFilter, new() {
            var filter = new TFilter();
            return UseFilter(filter);
        }

        /// <summary>
        /// Use destructurer
        /// </summary>
        /// <param name="destructurer"></param>
        /// <param name="appendMode"></param>
        /// <returns></returns>
        public ExceptionOptions UseDestucturer(IExceptionDestructurer destructurer, bool appendMode = true) {
            if (appendMode)
                OpsBuildSetter(b => OpsBuildAdditionalUpdate(destructurer));
            else
                OpsBuildSetter(b => b.WithDestructurer(destructurer));
            return this;
        }

        /// <summary>
        /// Use destructurers
        /// </summary>
        /// <param name="appendMode"></param>
        /// <typeparam name="TDestructurer"></typeparam>
        /// <returns></returns>
        public ExceptionOptions UseDestucturer<TDestructurer>(bool appendMode = true) where TDestructurer : class, IExceptionDestructurer, new() {
            return UseDestucturer(new TDestructurer(), appendMode);
        }

        /// <summary>
        /// Use destructurers
        /// </summary>
        /// <param name="destructurers"></param>
        /// <param name="appendMode"></param>
        /// <returns></returns>
        public ExceptionOptions UseDestucturers(IEnumerable<IExceptionDestructurer> destructurers, bool appendMode = true) {
            if (appendMode)
                OpsBuildSetter(b => OpsBuildAdditionalUpdate(destructurers));
            else
                OpsBuildSetter(b => b.WithDestructurers(destructurers));
            return this;
        }

        internal IDestructuringOptions Build(out OptionUpdateStatus status) {
            if (_builderChangedStatus.Built) {
                status = _builderChangedStatus;
                return _builder;
            }

            if (!_builder.Destructurers.Any())
                OpsBuildSetter(b => b.WithDefaultDestructurer());

            if (_builder.Filter == null)
                OpsBuildSetter(b => b.WithDefaultFilter());

            _additionalUpdateDestructurerOps?.Invoke(_builder);

            _builderChangedStatus.Built = true;

            status = _builderChangedStatus;

            return _builder;
        }

        private void OpsBuildSetter(
            Action<DestructuringOptionsBuilder> settingAct,
            Action<OptionUpdateStatus> changedAct = null) {
            if (settingAct == null)
                throw new ArgumentNullException(nameof(settingAct));

            if (_builderChangedStatus.Built)
                throw new InvalidOperationException("Destructuring options has been built.");

            settingAct(_builder);
            changedAct?.Invoke(_builderChangedStatus);
        }

        private void OpsBuildAdditionalUpdate(IExceptionDestructurer destructurer) {
            if (destructurer == null)
                return;

            if (_additionalUpdateDestructurerOps == null)
                _additionalUpdateDestructurerOps = b => b.WithDestructurer(destructurer);
        }

        private void OpsBuildAdditionalUpdate(IEnumerable<IExceptionDestructurer> destructurers) {
            if (destructurers == null)
                return;

            foreach (var destructure in destructurers)
                OpsBuildAdditionalUpdate(destructure);
        }

        #endregion

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public ExceptionOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public ExceptionOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
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
        public ExceptionOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public ExceptionOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public ExceptionOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
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
        public ExceptionOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public ExceptionOptions UseAlias(string alias, LogEventLevel level) {
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

        #region Appeng filter

        internal Func<string, LogEventLevel, bool> Filter { get; set; }

        /// <summary>
        /// Use filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ExceptionOptions UseFilter(Func<string, LogEventLevel, bool> filter) {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var temp = Filter;
            Filter = (s, l) => (temp?.Invoke(s, l) ?? true) && filter(s, l);

            return this;
        }

        #endregion

        #region Append output

        private readonly RenderingConfiguration _renderingOptions = new RenderingConfiguration();

        /// <inheritdoc />
        public ExceptionOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public ExceptionOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public ExceptionOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        /// <inheritdoc />
        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        internal class OptionUpdateStatus {
            public bool NameChanged { get; set; }
            public bool DepthChanged { get; set; }
            public bool Built { get; set; }
        }
    }
}