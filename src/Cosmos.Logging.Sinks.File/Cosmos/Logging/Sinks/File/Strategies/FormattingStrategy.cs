using System;
using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.OutputTemplates;

namespace Cosmos.Logging.Sinks.File.Strategies {
    /// <summary>
    /// Formatting strategy
    /// </summary>
    public class FormattingStrategy {
        /// <summary>
        /// Create a new instance of <see cref="FormattingStrategy"/>
        /// </summary>
        /// <param name="template"></param>
        public FormattingStrategy(OutputTemplate template) {
            OutputTemplate = template ?? throw new ArgumentNullException(nameof(template));
        }

        /// <summary>
        /// Output template
        /// </summary>
        public OutputTemplate OutputTemplate { get; }

        /// <summary>
        /// Gets all tokens in <see cref="OutputTemplate"/>
        /// </summary>
        public IReadOnlyList<OutputMessageToken> Tokens => OutputTemplate.Tokens;
    }
}