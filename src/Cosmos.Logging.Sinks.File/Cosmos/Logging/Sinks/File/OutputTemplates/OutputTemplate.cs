using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Output template
    /// </summary>
    public class OutputTemplate {

        /// <summary>
        /// Get empty output template
        /// </summary>
        public static OutputTemplate Empty { get; } = new OutputTemplate(Enumerable.Empty<OutputMessageToken>());

        private readonly string _originOutputTemplate;

        private readonly OutputMessageToken[] _tokens;

        // ReSharper disable PossibleMultipleEnumeration
        /// <inheritdoc />
        public OutputTemplate(IEnumerable<OutputMessageToken> tokens) : this(string.Join("", tokens), tokens) { }

        /// <summary>
        /// Create a new instance of <see cref="OutputTemplate"/>
        /// </summary>
        /// <param name="originOutputTemplate"></param>
        /// <param name="tokens"></param>
        public OutputTemplate(string originOutputTemplate, IEnumerable<OutputMessageToken> tokens) {
            _originOutputTemplate = originOutputTemplate ?? throw new ArgumentNullException(nameof(originOutputTemplate));
            _tokens = tokens?.ToArray() ?? throw new ArgumentNullException(nameof(tokens));
        }

        /// <summary>
        /// Gets tokens
        /// </summary>
        public IReadOnlyList<OutputMessageToken> Tokens => _tokens;

        internal OutputMessageToken[] TokenArray => _tokens;

        /// <summary>
        /// Gets text
        /// </summary>
        public string Text => _originOutputTemplate;

        internal char[] TextArray => Text.ToCharArray();


        /// <inheritdoc />
        public override string ToString() => Text;
    }
}