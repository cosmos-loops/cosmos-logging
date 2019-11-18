using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;
using Cosmos.Logging.Extensions.Exceptions.Filters;

namespace Cosmos.Logging.Extensions.Exceptions.Configurations
{
    public class ExceptionOptions : ILoggingSinkOptions<ExceptionOptions>, ILoggingSinkOptions
    {
        private readonly DestructuringOptionsBuilder _builder;
        private readonly OptionUpdateStatus _builderChangedStatus;

        public ExceptionOptions()
        {
            _builder = new DestructuringOptionsBuilder();
            _builderChangedStatus = new OptionUpdateStatus();
        }

        public string Key => Constants.SinkKey;

        #region DestructuringOptionsBuilder ops

        public string Name
        {
            get => _builder.Name;
            set => OpsBuildSetter(b => b.WithName(value), c => c.NameChanged = true);
        }

        public int DestructureDepth
        {
            get => _builder.DestructureDepth;
            set => OpsBuildSetter(b => b.WithDepth(value), c => c.DepthChanged = true);
        }

        public IEnumerable<IExceptionDestructurer> Destructurers => _builder.Destructurers;

        public IExceptionPropertyFilter ExceptionPropertyFilter
        {
            get => _builder.Filter;
            set => OpsBuildSetter(b => b.WithFiler(value));
        }

        public ExceptionOptions UseName(string name)
        {
            Name = name;
            return this;
        }

        public ExceptionOptions UseDestructureDepth(int depth)
        {
            DestructureDepth = depth;
            return this;
        }

        public ExceptionOptions UseFilter(IExceptionPropertyFilter filter)
        {
            ExceptionPropertyFilter = filter;
            return this;
        }

        public ExceptionOptions UseFilter<TFilter>() where TFilter : class, IExceptionPropertyFilter, new()
        {
            var filter = new TFilter();
            return UseFilter(filter);
        }

        public ExceptionOptions UseDestucturer(IExceptionDestructurer destructurer)
        {
            OpsBuildSetter(b => b.WithDestructurers(new List<IExceptionDestructurer> {destructurer}));
            return this;
        }

        public ExceptionOptions UseDestucturer<TDestructurer>() where TDestructurer : class, IExceptionDestructurer, new()
        {
            var destructurer = new TDestructurer();
            return UseDestucturer(destructurer);
        }

        public ExceptionOptions UseDestucturers(IEnumerable<IExceptionDestructurer> destructurers)
        {
            OpsBuildSetter(b => b.WithDestructurers(destructurers));
            return this;
        }

        internal IDestructuringOptions Build(out OptionUpdateStatus status)
        {
            if (_builderChangedStatus.Built)
            {
                status = _builderChangedStatus;
                return _builder;
            }

            if (!_builder.Destructurers.Any())
                OpsBuildSetter(b => b.WithDefaultDestructurer());

            if (_builder.Filter == null)
                OpsBuildSetter(b => b.WithDefaultFilter());

            _builderChangedStatus.Built = true;

            status = _builderChangedStatus;

            return _builder;
        }

        private void OpsBuildSetter(
            Action<DestructuringOptionsBuilder> settingAct,
            Action<OptionUpdateStatus> changedAct = null)
        {
            if (settingAct == null)
                throw new ArgumentNullException(nameof(settingAct));

            if (_builderChangedStatus.Built)
                throw new InvalidOperationException("Destructuring options has been built.");

            settingAct(_builder);
            changedAct?.Invoke(_builderChangedStatus);
        }

        #endregion

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public ExceptionOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public ExceptionOptions UseMinimumLevelForType(Type type, LogEventLevel level)
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

        public ExceptionOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public ExceptionOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public ExceptionOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level)
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

        public ExceptionOptions UseMinimumLevel(LogEventLevel? level)
        {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public ExceptionOptions UseAlias(string alias, LogEventLevel level)
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

        #region Appeng filter

        internal Func<string, LogEventLevel, bool> Filter { get; set; }

        public ExceptionOptions UseFilter(Func<string, LogEventLevel, bool> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var temp = Filter;
            Filter = (s, l) => (temp?.Invoke(s, l) ?? true) && filter(s, l);

            return this;
        }

        #endregion

        #region Append output

        private readonly RendingConfiguration _renderingOptions = new RendingConfiguration();

        public ExceptionOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled)
        {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        public ExceptionOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled)
        {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        public ExceptionOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled)
        {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        public RendingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        internal class OptionUpdateStatus
        {
            public bool NameChanged { get; set; }
            public bool DepthChanged { get; set; }
            public bool Built { get; set; }
        }
    }
}