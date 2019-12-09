namespace Cosmos.Logging.Core.LogFields {
    public interface ILogField {
        LogFieldTypes Type { get; }
        int Sort { get; set; }
    }

    public interface ILogField<out TTypeValue> : ILogField {
        TTypeValue Value { get; }
    }
}