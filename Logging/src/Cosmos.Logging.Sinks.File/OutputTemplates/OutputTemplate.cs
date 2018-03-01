using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public class OutputTemplate {

        public static OutputTemplate Empty { get; } = new OutputTemplate(Enumerable.Empty<OutputMessageToken>());

        private readonly string _originOutputTemplate;

        private readonly OutputMessageToken[] _tokens;

        // ReSharper disable PossibleMultipleEnumeration
        public OutputTemplate(IEnumerable<OutputMessageToken> tokens) : this(string.Join("", tokens), tokens) { }

        public OutputTemplate(string originOutputTemplate, IEnumerable<OutputMessageToken> tokens) {
            _originOutputTemplate = originOutputTemplate ?? throw new ArgumentNullException(nameof(originOutputTemplate));
            _tokens = tokens?.ToArray() ?? throw new ArgumentNullException(nameof(tokens));
        }

        public IReadOnlyList<OutputMessageToken> Tokens => _tokens;

        public string Text => _originOutputTemplate;

        internal char[] TextArray => Text.ToCharArray();


        public override string ToString() => Text;
    }
}