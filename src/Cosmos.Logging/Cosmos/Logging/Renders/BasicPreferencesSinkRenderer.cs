namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Basic preferences sink renderer
    /// </summary>
    public abstract class BasicPreferencesSinkRenderer : BasicPreferencesRenderer, IPreferencesSinkRenderer {
        /// <inheritdoc />
        public abstract string SinkPrefix { get; }
    }
}