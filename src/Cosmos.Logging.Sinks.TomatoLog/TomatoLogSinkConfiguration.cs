using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.TomatoLog;
using Cosmos.Logging.Sinks.TomatoLog.Core;
using EnumsNET;
using TomatoLog.Common.Config;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public class TomatoLogSinkConfiguration : SinkConfiguration
    {
        public TomatoLogSinkConfiguration() : base(Constants.SinkKey) { }

        public string FlowType { get; set; }

        public EventRedisOptions Redis { get; set; }

        public EventRabbitMQOptions RabbitMQ { get; set; }

        public EventKafkaOptions Kafka { get; set; }

        protected override void BeforeProcessing(ILoggingSinkOptions settings)
        {
            if (settings is TomatoLogSinkOptions options)
            {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        protected override void PostProcessing(ILoggingSinkOptions settings)
        {
            if (settings is TomatoLogSinkOptions options)
            {
                RegisterTomatoLogClients(options, this);
            }
        }

        private static void RegisterTomatoLogClients(TomatoLogSinkOptions options, TomatoLogSinkConfiguration configuration)
        {
            //优先级判断： option > configuration
            
            if (options.RedisOptions == null && options.RabbitMqOptions == null && options.KafkaOptions == null)
            {
                RegisterClientViaConfiguration(configuration);
            }
            else
            {
                RegisterClientsViaOptions(options);
            }
        }

        private static void RegisterClientViaConfiguration(TomatoLogSinkConfiguration configuration)
        {
            var flowType = configuration.GetRealFlowType();
            var client = TomatoLogClientCreator.Create(flowType, configuration);
            TomatoClientManager.Set(client, flowType);
        }

        private static void RegisterClientsViaOptions(TomatoLogSinkOptions options)
        {
            var client = TomatoLogClientCreator.Create(options);
            TomatoClientManager.Set(client, options.FlowType);
        }

        private LogFlowTypes GetRealFlowType()
        {
            var flowTypeStr = FlowType.ToLower();
            
            switch (flowTypeStr)
            {
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