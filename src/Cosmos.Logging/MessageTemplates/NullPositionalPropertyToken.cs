namespace Cosmos.Logging.MessageTemplates {
    public class NullPositionalPropertyToken : PositionalPropertyToken {

        public NullPositionalPropertyToken(string originText, string formatOriginText, string paramsOriginText,
            int index, int position, int paramsFlagMode, int fixOriginTextLength = 2)
            : base(originText, formatOriginText, paramsOriginText, index, position, paramsFlagMode, fixOriginTextLength) { }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsRawText;

        public override string ToString() => RawText;

        public override string ToText() => ToString();

        public override string Render() => ToString();
    }
}