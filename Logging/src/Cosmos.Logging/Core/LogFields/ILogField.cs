namespace Cosmos.Logging.Core.LogFields {
    public interface ILogField {
        LogFieldTypes Type { get; }
    }

    public interface ILogField<out TTypeValue> : ILogField {
        TTypeValue Value { get; }
    }
}