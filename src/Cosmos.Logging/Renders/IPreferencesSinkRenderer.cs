namespace Cosmos.Logging.Renders {
    public interface IPreferencesSinkRenderer : IPreferencesRenderer {
        string SinkPrefix { get; }
    }
}