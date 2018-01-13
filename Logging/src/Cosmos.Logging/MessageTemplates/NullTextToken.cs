namespace Cosmos.Logging.MessageTemplates {
    public sealed class NullTextToken : TextToken {
        public NullTextToken(string originText, int index, int position) : base(originText, originText, index, position) { }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsRawText;

        public override string ToString() => RawText;

        //todo 注意，此类的输出结果为完成输出 RawText
    }
}