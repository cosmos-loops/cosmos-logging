namespace Cosmos.Logging.MessageTemplates {
    public sealed class NullTextToken : TextToken {
        public NullTextToken(string originText, int index, int position) : base(originText, originText, index, position) { }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsRawText;

        public override string ToString() => RawText;

        public override string ToText() => ToString();

        public override string Render() => ToString();
    }
}