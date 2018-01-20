namespace Cosmos.Logging.Renders {
    public interface IPreferencesSinkRender : IPreferencesRender {
        string SinkPrefix { get; }
    }
}