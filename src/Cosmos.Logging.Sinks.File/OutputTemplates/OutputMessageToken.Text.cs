using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public class TextOutputMessageToken : OutputMessageToken {

        public TextOutputMessageToken(string originText, int index, int position)
            : base(originText, originText, index, position) { }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsText;

        public override string ToString() => RawText;

        public override string ToText() => ToString();

        public override string Render() => ToString();
    }
}