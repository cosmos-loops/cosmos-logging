namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public interface IOutputTemplateParser {
        OutputTemplate Parse(string outputTemplate);
    }
}