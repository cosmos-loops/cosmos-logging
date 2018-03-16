using System;
using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.OutputTemplates;

namespace Cosmos.Logging.Sinks.File.Strategies {
    public class FormattingStrategy {
        public FormattingStrategy(OutputTemplate template) {
            OutputTemplate = template ?? throw new ArgumentNullException(nameof(template));
        }

        public OutputTemplate OutputTemplate { get; }
        public IReadOnlyList<OutputMessageToken> Tokens => OutputTemplate.Tokens;
    }
}