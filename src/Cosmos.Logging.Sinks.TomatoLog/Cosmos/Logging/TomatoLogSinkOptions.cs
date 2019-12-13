using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.TomatoLog.Core;
using TomatoLog.Common.Config;

namespace Cosmos.Logging {
    /// <summary>
    /// TomatoLog sink options
    /// </summary>
    public class TomatoLogSinkOptions : ILoggingSinkOptions<TomatoLogSinkOptions>, ILoggingSinkOptions {
        /// <inheritdoc />
        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public TomatoLogSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        /// <inheritdoc />
        public TomatoLogSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
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
        public TomatoLogSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        /// <inheritdoc />
        public TomatoLogSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        /// <inheritdoc />
        public TomatoLogSinkOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level) {
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
        public TomatoLogSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        /// <inheritdoc />
        public TomatoLogSinkOptions UseAlias(string alias, LogEventLevel level) {
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
        public TomatoLogSinkOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled) {
            _renderingOptions.DisplayingCallerInfoEnabled = displayingCallerInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public TomatoLogSinkOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled) {
            _renderingOptions.DisplayingEventIdInfoEnabled = displayingEventIdInfoEnabled;
            return this;
        }

        /// <inheritdoc />
        public TomatoLogSinkOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled) {
            _renderingOptions.DisplayingNewLineEomEnabled = displayingNewLineEomEnabled;
            return this;
        }

        /// <inheritdoc />
        public RenderingConfiguration GetRenderingOptions() => _renderingOptions;

        #endregion

        #region MQ implementation

        internal LogFlowTypes FlowType { get; private set; } = LogFlowTypes.Redis;

        internal EventRedisOptions RedisOptions { get; set; }

        /// <summary>
        /// Use Redis with options
        /// </summary>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public TomatoLogSinkOptions UseRedis(Action<EventRedisOptions> optionAction = null) {
            if (optionAction != null) {
                var option = RedisOptions ?? new EventRedisOptions();
                optionAction(option);
                RedisOptions = option;
            }

            FlowType = LogFlowTypes.Redis;
            return this;
        }

        internal EventRabbitMQOptions RabbitMqOptions { get; set; }

        /// <summary>
        /// Use RabbitMQ with options
        /// </summary>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public TomatoLogSinkOptions UseRabbitMq(Action<EventRabbitMQOptions> optionAction = null) {
            if (optionAction != null) {
                var option = RabbitMqOptions ?? new EventRabbitMQOptions();
                optionAction(option);
                RabbitMqOptions = option;
            }

            FlowType = LogFlowTypes.RabbitMq;
            return this;
        }

        internal EventKafkaOptions KafkaOptions { get; set; }

        /// <summary>
        /// Use Kafka with options
        /// </summary>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public TomatoLogSinkOptions UseKafka(Action<EventKafkaOptions> optionAction = null) {
            if (optionAction != null) {
                var option = KafkaOptions ?? new EventKafkaOptions();
                optionAction(option);
                KafkaOptions = option;
            }

            FlowType = LogFlowTypes.Kafka;
            return this;
        }

        #endregion

        #region Tomato options

        #endregion

    }
}