using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Text output message token
    /// </summary>
    public class TextOutputMessageToken : OutputMessageToken {

        /// <inheritdoc />
        public TextOutputMessageToken(string originText, int index, int position)
            : base(originText, originText, index, position) { }

        /// <inheritdoc />
        public override TokenRendererTypes TokenRendererType { get; } = TokenRendererTypes.AsText;

        /// <inheritdoc />
        public override string ToString() => RawText;

        /// <inheritdoc />
        public override string ToText() => ToString();

        /// <inheritdoc />
        public override string Render() => ToString();
    }
}