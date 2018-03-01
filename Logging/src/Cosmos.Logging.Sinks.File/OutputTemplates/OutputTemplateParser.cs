using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public class OutputTemplateParser : IOutputTemplateParser {
        public OutputTemplate Parse(string outputTemplate) {
            if (string.IsNullOrWhiteSpace(outputTemplate)) throw new ArgumentNullException(nameof(outputTemplate));
            return new OutputTemplate(outputTemplate, Tokenize(outputTemplate));
        }

        static IEnumerable<OutputMessageToken> Tokenize(string outputTemplate) {
            return null;
        }
    }
}