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
        
        //todo 注意，输出的时候结构为：{tokenString}，也就是说两个大括号变成一个，此处用于大括号转义
    }
}