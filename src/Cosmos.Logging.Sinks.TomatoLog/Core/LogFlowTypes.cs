namespace Cosmos.Logging.Sinks.TomatoLog.Core
{
    /// <summary>
    /// Data flow types
    /// </summary>
    public enum LogFlowTypes
    {
        /// <summary>
        /// Use redis (default)
        /// </summary>
        Redis,

        /// <summary>
        /// Use RabbitMQ
        /// </summary>
        RabbitMq,

        /// <summary>
        /// Use Kafka
        /// </summary>
        Kafka
    }
}