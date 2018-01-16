using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cosmos.Logging.MessageTemplates {
    public class MessageTemplate {

        public static MessageTemplate Empty { get; } = new MessageTemplate(Enumerable.Empty<MessageTemplateToken>());

        private readonly MessageTemplateToken[] _tokens;

        // ReSharper disable PossibleMultipleEnumeration
        public MessageTemplate(IEnumerable<MessageTemplateToken> tokens) : this(string.Join("", tokens), tokens) { }
        // ReSharper enable PossibleMultipleEnumeration

        public MessageTemplate(string messageTemplate, IEnumerable<MessageTemplateToken> tokens) {
            Text = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            _tokens = tokens?.OrderBy(o => o.Index).ToArray() ?? throw new ArgumentNullException(nameof(tokens));
        }

        public string Text { get; }

        internal char[] TextArray => Text.ToCharArray();

        public IEnumerable<MessageTemplateToken> Tokens => _tokens;

        internal MessageTemplateToken[] TokenArray => _tokens;

        public string Render(IReadOnlyDictionary<string, MessagePropertyValue> properties, IFormatProvider provider = null) {
            using (var output = new StringWriter(provider)) {
                Render(properties, output, provider);
                return output.ToString();
            }
        }

        public void Render(IReadOnlyDictionary<string, MessagePropertyValue> properties, TextWriter output, IFormatProvider provider = null) {
            if (properties == null) throw new ArgumentNullException(nameof(properties));
            if (output == null) throw new ArgumentNullException(nameof(output));
            MessageTemplateRenderer.Render(this, properties, output, null, provider);
        }

        public override string ToString() => Text;
    }
}