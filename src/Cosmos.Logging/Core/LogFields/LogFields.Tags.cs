namespace Cosmos.Logging.Core.LogFields {
    public class TagsField : ILogField<string[]> {
        public TagsField(params string[] tags) => Value = tags;
        public LogFieldTypes Type => LogFieldTypes.Tags;
        public string[] Value { get; }
        public int Sort { get; set; } = 1;
    }
}