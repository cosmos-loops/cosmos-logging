using Cosmos.Logging.Events;

namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Text token
    /// </summary>
    public class TextToken : MessageTemplateToken {
        /// <inheritdoc />
        public TextToken(string originText, int index, int position)
            : base(originText, index, position, 4) { }

        /// <inheritdoc />
        protected TextToken(string originText, string tokenString, int index, int position)
            : base(originText, tokenString, index, position) { }

        /// <inheritdoc />
        public override TokenRendererTypes TokenRendererType { get; } = TokenRendererTypes.AsText;

        /// <inheritdoc />
        public override PropertyResolvingMode PropertyResolvingMode { get; } = PropertyResolvingMode.Stringify;

        /// <inheritdoc />
        public override string ToString() => $"{{{TokenString}}}";

        /// <inheritdoc />
        public override string ToText() => ToString();

        /// <inheritdoc />
        public override string Render() => ToString();
    }
}