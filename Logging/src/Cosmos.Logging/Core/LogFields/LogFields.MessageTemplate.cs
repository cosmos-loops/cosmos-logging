namespace Cosmos.Logging.Core.LogFields {
    public class MessageTemplateField : ILogField<string> {
        public MessageTemplateField(string template, bool append = false) {
            Value = template;
            Append = append;
        }

        public LogFieldTypes Type => LogFieldTypes.MessageTemplate;
        public string Value { get; }
        public bool Append { get; }
    }
}