namespace Cosmos.Logging.Events
{
    /// <summary>
    /// Descriptive aliases for <see cref="LogEventLevel"/>.
    /// </summary>
    public static class LevelAlias
    {
        /// <summary>
        /// The least significant level of event.
        /// </summary>
        public const LogEventLevel Minimum = LogEventLevel.Verbose;

        /// <summary>
        /// The most significant level of event.
        /// </summary>
        public const LogEventLevel Maximum = LogEventLevel.Fatal;
    }
}