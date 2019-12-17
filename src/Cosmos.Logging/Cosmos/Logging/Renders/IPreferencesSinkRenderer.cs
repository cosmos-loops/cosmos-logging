namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Interface for preferences sink renderer
    /// </summary>
    public interface IPreferencesSinkRenderer : IPreferencesRenderer {
        /// <summary>
        /// Sink prefix
        /// </summary>
        string SinkPrefix { get; }
    }
}