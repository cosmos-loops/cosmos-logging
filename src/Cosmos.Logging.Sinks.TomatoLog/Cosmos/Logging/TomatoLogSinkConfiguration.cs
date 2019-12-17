using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.TomatoLog;
using Cosmos.Logging.Sinks.TomatoLog.Core;
using EnumsNET;
using TomatoLog.Common.Config;

namespace Cosmos.Logging {
    /// <summary>
    /// TOmato log sink configuration
    /// </summary>
    public class TomatoLogSinkConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public TomatoLogSinkConfiguration() : base(Constants.SinkKey) { }

        /// <summary>
        /// Gets or sets flow type
        /// </summary>
        public string FlowType { get; set; }

        /// <summary>
        /// Gets or sets Redis options
        /// </summary>
        public EventRedisOptions Redis { get; set; }

        /// <summary>
        /// Gets or sets RabbitMQ options
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public EventRabbitMQOptions RabbitMQ { get; set; }

        /// <summary>
        /// Gets or sets Kafka options
        /// </summary>
        public EventKafkaOptions Kafka { get; set; }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is TomatoLogSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        /// <inheritdoc />
        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is TomatoLogSinkOptions options) {
                RegisterTomatoLogClients(options, this);
            }
        }

        private static void RegisterTomatoLogClients(TomatoLogSinkOptions options, TomatoLogSinkConfiguration configuration) {
            //优先级判断： option > configuration

            if (options.RedisOptions == null && options.RabbitMqOptions == null && options.KafkaOptions == null) {
                RegisterClientViaConfiguration(configuration);
            }
            else {
                RegisterClientsViaOptions(options);
            }
        }

        private static void RegisterClientViaConfiguration(TomatoLogSinkConfiguration configuration) {
            var flowType = configuration.GetRealFlowType();
            var client = TomatoLogClientCreator.Create(flowType, configuration);
            TomatoClientManager.Set(client, flowType);
        }

        private static void RegisterClientsViaOptions(TomatoLogSinkOptions options) {
            var client = TomatoLogClientCreator.Create(options);
            TomatoClientManager.Set(client, options.FlowType);
        }

        private LogFlowTypes GetRealFlowType() {
            var flowTypeStr = FlowType.ToLower();

            switch (flowTypeStr) {
                case "redis":
                    return LogFlowTypes.Redis;

                case "rabbitmq":
                    return LogFlowTypes.RabbitMq;

                case "kafka":
                    return LogFlowTypes.Kafka;

                default:
                    return LogFlowTypes.Redis;
            }
        }
    }
}