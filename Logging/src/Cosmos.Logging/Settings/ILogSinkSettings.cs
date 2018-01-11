using Cosmos.Logging.Events;

namespace Cosmos.Logging.Settings {
    public interface ILogSinkSettings {
        string Key { get; }
        string Name { get; set; }
        LogEventLevel? Level { get; set; }
    }
}