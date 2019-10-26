using System;
using TomatoLog.Client.Kafka;
using TomatoLog.Client.RabbitMQ;
using TomatoLog.Client.Redis;
using TomatoLog.Common.Interface;

namespace Cosmos.Logging.Sinks.TomatoLog.Core
{
    internal static class TomatoLogClientCreator
    {
        public static ITomatoLogClient Create(LogFlowTypes flowType, TomatoLogSinkConfiguration configuration)
        {
            switch (flowType)
            {
                case LogFlowTypes.Redis:
                {
                    var eventOption = configuration.Redis;
                    if (eventOption == null)
                        throw new ArgumentNullException(nameof(eventOption));
                    return new TomatoLogClientRedis(eventOption);
                }

                case LogFlowTypes.RabbitMq:
                {
                    var eventOption = configuration.RabbitMQ;
                    if (eventOption == null)
                        throw new ArgumentNullException(nameof(eventOption));
                    return new TomatoLogClientRabbitMQ(eventOption);
                }

                case LogFlowTypes.Kafka:
                {
                    var eventOption = configuration.Kafka;
                    if (eventOption == null)
                        throw new ArgumentNullException(nameof(eventOption));
                    return new TomatoLogClientKafka(eventOption);
                }

                default:
                    throw new InvalidOperationException("Unknown flow type.");
            }
        }

        public static ITomatoLogClient Create(TomatoLogSinkOptions options)
        {
            switch (options.FlowType)
            {
                case LogFlowTypes.Redis:
                {
                    var eventOption = options.RedisOptions;
                    if (eventOption == null)
                        throw new ArgumentNullException(nameof(eventOption));
                    return new TomatoLogClientRedis(eventOption);
                }

                case LogFlowTypes.RabbitMq:
                {
                    var eventOption = options.RabbitMqOptions;
                    if (eventOption == null)
                        throw new ArgumentNullException(nameof(eventOption));
                    return new TomatoLogClientRabbitMQ(eventOption);
                }

                case LogFlowTypes.Kafka:
                {
                    var eventOption = options.KafkaOptions;
                    if (eventOption == null)
                        throw new ArgumentNullException(nameof(eventOption));
                    return new TomatoLogClientKafka(eventOption);
                }

                default:
                    throw new InvalidOperationException("Unknown flow type.");
            }
        }
    }
}