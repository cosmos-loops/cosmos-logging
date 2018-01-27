using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public interface ILoggingSinkOptions {
        string Key { get; }
        string Name { get; }
    }

    public interface ILoggingSinkOptions<out TOptions> where TOptions : class, ILoggingSinkOptions, new() {
        TOptions UseMinLevel(LogEventLevel level);
    }
}