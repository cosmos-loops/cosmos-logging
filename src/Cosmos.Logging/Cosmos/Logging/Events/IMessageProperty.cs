namespace Cosmos.Logging.Events {
    /// <summary>
    /// Interface for message property
    /// </summary>
    public interface IMessageProperty {
        /// <summary>
        /// Gets property name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets message property value
        /// </summary>
        MessagePropertyValue Value { get; }
    }
}