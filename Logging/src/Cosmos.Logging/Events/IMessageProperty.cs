namespace Cosmos.Logging.Events {
    public interface IMessageProperty {
        string Name { get; }
        MessagePropertyValue Value { get; }
    }
}