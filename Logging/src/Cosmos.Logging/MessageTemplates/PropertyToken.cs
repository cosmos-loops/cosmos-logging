namespace Cosmos.Logging.MessageTemplates {
    public class PropertyToken : MessageTemplateToken {
        public PropertyToken(string originText, int index, int position, PropertyTokenTypes type)
            : base(originText, index,position) {
            TokenType = type;
        }

        public PropertyTokenTypes TokenType { get; }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsProperty;
    }
}