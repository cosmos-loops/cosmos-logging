namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Args field
    /// </summary>
    public class ArgsField : ILogField<object[]> {
        /// <summary>
        /// Create a new instance of <see cref="ArgsField"/>
        /// </summary>
        /// <param name="args"></param>
        public ArgsField(params object[] args) => Value = args;

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.Args;

        /// <inheritdoc />
        public object[] Value { get; }

        /// <inheritdoc />
        public int Sort { get; set; } = 1;
    }
}