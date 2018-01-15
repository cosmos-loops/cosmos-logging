namespace Cosmos.Logging.MessageTemplates {
    public class PropertyToken : MessageTemplateToken {
        public readonly string RawFormatText;
        public readonly string RawParamsText;
        private readonly int ParamsFlagMode;

        public PropertyToken(string originText, string formatOriginText, string paramsOriginText, int index, int position, PropertyTokenTypes type, int paramsFlagMode,
            int fixOriginTextLength = 3)
            : base(originText, index, position, fixOriginTextLength) {
            TokenType = type;
            RawFormatText = formatOriginText;
            RawParamsText = paramsOriginText;
            ParamsFlagMode = paramsFlagMode;
        }

        public PropertyTokenTypes TokenType { get; }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsProperty;

        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        //以下为临时性代码
        public override string ToString() => ToText();
    }
}