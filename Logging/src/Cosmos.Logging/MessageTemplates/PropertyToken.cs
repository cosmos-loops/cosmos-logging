using System.Collections.Generic;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    public class PropertyToken : MessageTemplateToken {
        public readonly string RawFormatText;
        public readonly string RawParamsText;
        private readonly int ParamsFlagMode;
        private int prefixPointer = 0;
        public readonly List<FormatEvent> FormatEvents;

        public PropertyToken(string originText, string formatOriginText, string paramsOriginText, int index, int position, PropertyTokenTypes type, int paramsFlagMode,
            int fixOriginTextLength = 3)
            : base(originText, index, position, fixOriginTextLength) {
            FormatEvents = new List<FormatEvent>();

            TokenType = type;
            RawFormatText = formatOriginText;
            RawParamsText = paramsOriginText;
            ParamsFlagMode = paramsFlagMode;

            Prefix = ClearUpPrefix(TokenString, out prefixPointer);
            Name = ClearUpName(TokenString, prefixPointer);

            Format = ClearUpFormat(RawFormatText);
            Params = ClearUpParams(RawParamsText);
        }

        public PropertyTokenTypes TokenType { get; }

        private static string ClearUpPrefix(string rawText, out int position) {
            var index = rawText.IndexOf('#');
            position = index <= 0 ? 0 : index;
            return index < 0 ? string.Empty : rawText.Substring(0, index);
        }

        private static string ClearUpName(string rawText, int position) {
            var colon_index = rawText.IndexOf(':');
            return colon_index < 0 ? rawText.Substring(position, rawText.Length - position) : rawText.Substring(position, colon_index - position);
        }

        public string Prefix { get; }

        public string Name { get; }

        private string ClearUpFormat(string format) {
            foreach (var @event in FormatCommandFactory.CreateCommandEvent(format)) {
                FormatEvents.Add(@event);
            }

            return format;
        }

        public string Format { get; }

        private static string ClearUpParams(string paramsText) {
            return paramsText;
        }

        public string Params { get; }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsProperty;

        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        //以下为临时性代码
        public override string ToString() => ToText();

        public string ToString(string format) {
            return ToText();
        }

        public override string Render() => ToString();
    }
}