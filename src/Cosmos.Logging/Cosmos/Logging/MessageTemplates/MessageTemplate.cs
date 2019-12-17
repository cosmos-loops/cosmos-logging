using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Message template
    /// </summary>
    public class MessageTemplate {
        /// <summary>
        /// Gets an empty message template
        /// </summary>

        public static MessageTemplate Empty { get; } = new MessageTemplate(Enumerable.Empty<MessageTemplateToken>());

        private readonly MessageTemplateToken[] _tokens;

        /// <summary>
        /// Create a new instance of <see cref="MessageTemplate"/>
        /// </summary>
        /// <param name="tokens"></param>
        // ReSharper disable PossibleMultipleEnumeration
        public MessageTemplate(IEnumerable<MessageTemplateToken> tokens) : this(string.Join("", tokens), tokens) { }
        
        /// <summary>
        /// Create a new instance of <see cref="MessageTemplate"/>
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="tokens"></param>
        // ReSharper enable PossibleMultipleEnumeration
        public MessageTemplate(string messageTemplate, IEnumerable<MessageTemplateToken> tokens) {
            Text = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            _tokens = tokens?.OrderBy(o => o.Index).ToArray() ?? throw new ArgumentNullException(nameof(tokens));
        }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; }

        internal char[] TextArray => Text.ToCharArray();

        /// <summary>
        /// Tokens
        /// </summary>
        public IEnumerable<MessageTemplateToken> Tokens => _tokens;

        internal MessageTemplateToken[] TokenArray => _tokens;

        internal int PropertyClassTokenCount
            => _tokens.Count(x => x.TokenRendererType == TokenRendererTypes.AsProperty || x.TokenRendererType == TokenRendererTypes.AsPositionalProperty);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="namedMessageProperties"></param>
        /// <param name="positionalMessageProperties"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="contextualLogEvent"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string Render(
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedMessageProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalMessageProperties,
            ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            RenderingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            using (var output = new StringWriter(provider)) {
                Render(namedMessageProperties, positionalMessageProperties, output, logEventInfo, contextualLogEvent, renderingOptions, provider);
                return output.ToString();
            }
        }

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="namedMessageProperties"></param>
        /// <param name="positionalMessageProperties"></param>
        /// <param name="output"></param>
        /// <param name="logEventInfo"></param>
        /// <param name="contextualLogEvent"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="provider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Render(
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedMessageProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalMessageProperties,
            TextWriter output, ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            RenderingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            if (namedMessageProperties == null) throw new ArgumentNullException(nameof(namedMessageProperties));
            if (positionalMessageProperties == null) throw new ArgumentNullException(nameof(positionalMessageProperties));
            if (output == null) throw new ArgumentNullException(nameof(output));
            MessageTemplateRenderer.Render(this, namedMessageProperties, positionalMessageProperties, output, logEventInfo, contextualLogEvent, null, renderingOptions, provider);
        }

        /// <inheritdoc />
        public override string ToString() => Text;
    }
}