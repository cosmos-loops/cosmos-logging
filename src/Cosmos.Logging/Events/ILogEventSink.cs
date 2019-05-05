namespace Cosmos.Logging.Events {
    public interface ILogEventSink {
        string Name { get; set; }
        LogEventLevel? Level { get; set; }
    }
}