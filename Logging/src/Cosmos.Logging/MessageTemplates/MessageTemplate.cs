using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

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

        internal int PropertyClassTokenCount
            => _tokens.Count(x => x.TokenRenderType == TokenRenderTypes.AsProperty || x.TokenRenderType == TokenRenderTypes.AsPositionalProperty);

        public string Render(
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedMessageProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalMessageProperties,
            ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            RendingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            using (var output = new StringWriter(provider)) {
                Render(namedMessageProperties, positionalMessageProperties, output, logEventInfo, contextualLogEvent, renderingOptions, provider);
                return output.ToString();
            }
        }

        public void Render(
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedMessageProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalMessageProperties,
            TextWriter output, ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            RendingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            if (namedMessageProperties == null) throw new ArgumentNullException(nameof(namedMessageProperties));
            if (positionalMessageProperties == null) throw new ArgumentNullException(nameof(positionalMessageProperties));
            if (output == null) throw new ArgumentNullException(nameof(output));
            MessageTemplateRenderer.Render(this, namedMessageProperties, positionalMessageProperties, output, logEventInfo, contextualLogEvent, null, renderingOptions, provider);
        }

        public override string ToString() => Text;
    }
}