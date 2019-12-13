namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Interface for output template parser
    /// </summary>
    public interface IOutputTemplateParser {
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="outputTemplate"></param>
        /// <returns></returns>
        OutputTemplate Parse(string outputTemplate);
    }
}