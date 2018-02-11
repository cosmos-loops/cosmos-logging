namespace Cosmos.Logging.Core.LogFields {
    public class ArgsField : ILogField<object[]> {
        public ArgsField(params object[] args) => Value = args;
        public LogFieldTypes Type => LogFieldTypes.Args;
        public object[] Value { get; }
    }
}