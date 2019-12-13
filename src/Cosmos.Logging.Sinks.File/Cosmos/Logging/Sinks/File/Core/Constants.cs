namespace Cosmos.Logging.Sinks.File.Core {
    internal class Constants {
        public const string SinkKey = "File";
        public const string DefaultOutputTemplate = "{Date} {Name}[{Level}]{EventInfo}{CallerInfo} {Message}{NewLine}";
    }
}