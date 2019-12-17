namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Message template field
    /// </summary>
    public class MessageTemplateField : ILogField<string> {
        /// <summary>
        /// Create a new instance of <see cref="MessageTemplateField"/>.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="append"></param>
        public MessageTemplateField(string template, bool append = false) {
            Value = template;
            Append = append;
        }

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.MessageTemplate;

        /// <inheritdoc />
        public string Value { get; }

        /// <summary>
        /// Append
        /// </summary>
        public bool Append { get; }

        /// <inheritdoc />
        public int Sort { get; set; } = 1;
    }
}