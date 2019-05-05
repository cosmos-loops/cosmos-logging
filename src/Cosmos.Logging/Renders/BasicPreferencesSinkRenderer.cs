namespace Cosmos.Logging.Renders {
    public abstract class BasicPreferencesSinkRenderer : BasicPreferencesRenderer, IPreferencesSinkRenderer {
        public abstract string SinkPrefix { get; }
    }
}