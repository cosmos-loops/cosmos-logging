namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public sealed class DefaultOutputTemplate {
        private static DefaultOutputTemplate _instance = new DefaultOutputTemplate();

        private const string Template = "{Date} {Name}[{Level}]{EventInfo}{CallerInfo} {Message}{NewLine}";

        public static DefaultOutputTemplate Instance => _instance;

        public static implicit operator string(DefaultOutputTemplate template) {
            return template.ToString();
        }

        public override string ToString() {
            return Template;
        }
    }
}