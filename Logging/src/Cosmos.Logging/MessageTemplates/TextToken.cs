namespace Cosmos.Logging.MessageTemplates {
    public class TextToken : MessageTemplateToken {
        public TextToken(string originText, int index, int position)
            : base(originText, index, position, 4) { }

        protected TextToken(string originText, string tokenString, int index, int position)
            : base(originText, tokenString, index, position) { }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsText;

        public override string ToString() => $"{{{TokenString}}}";

        public override string ToText() => ToString();

        public override string Render() => ToString();
    }
}