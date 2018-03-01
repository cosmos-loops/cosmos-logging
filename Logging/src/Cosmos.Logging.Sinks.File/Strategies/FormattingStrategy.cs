using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.OutputTemplates;

namespace Cosmos.Logging.Sinks.File.Strategies {
    public class FormattingStrategy {
        public OutputTemplate OutputTemplate { get; set; }
        public List<OutputMessageToken> Tokens { get; set; }
    }
}