namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Log field types
    /// </summary>
    public enum LogFieldTypes {
        /// <summary>
        /// Level
        /// </summary>
        LogEventLevel,

        /// <summary>
        /// Message template
        /// </summary>
        MessageTemplate,

        /// <summary>
        /// Exception
        /// </summary>
        Exception,

        /// <summary>
        /// Args
        /// </summary>
        Args,

        /// <summary>
        /// Tags
        /// </summary>
        Tags,

        /// <summary>
        /// Business event id, or names business trace id
        /// </summary>
        TrackId
    }
}