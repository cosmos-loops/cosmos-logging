namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Tags field
    /// </summary>
    public class TagsField : ILogField<string[]> {
        /// <summary>
        /// Create a new instance of <see cref="TagsField"/>.
        /// </summary>
        /// <param name="tags"></param>
        public TagsField(params string[] tags) => Value = tags;

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.Tags;

        /// <inheritdoc />
        public string[] Value { get; }

        /// <inheritdoc />
        public int Sort { get; set; } = 1;
    }
}