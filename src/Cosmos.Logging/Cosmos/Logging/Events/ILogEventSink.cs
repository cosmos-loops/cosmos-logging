namespace Cosmos.Logging.Events {
    /// <summary>
    /// Interface for log event sink
    /// </summary>
    public interface ILogEventSink {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets log event leel
        /// </summary>
        LogEventLevel? Level { get; set; }
    }
}