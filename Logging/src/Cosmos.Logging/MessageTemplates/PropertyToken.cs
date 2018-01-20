using System.Collections.Generic;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    public class PropertyToken : MessageTemplateToken {
        public readonly string RawFormatText;
        public readonly string RawParamsText;
        private readonly int ParamsFlagMode;
        private int prefixPointer = 0;
        public readonly List<FormatEvent> FormatEvents;

        public PropertyToken(string originText, string formatOriginText, string paramsOriginText,
            int index, int position, PropertyTokenTypes type, int paramsFlagMode, int fixOriginTextLength = 3)
            : base(originText, index, position, fixOriginTextLength) {
            FormatEvents = new List<FormatEvent>();
            TokenType = type;
            RawFormatText = formatOriginText;
            RawParamsText = paramsOriginText;
            ParamsFlagMode = paramsFlagMode;
            Prefix = MachiningForTokenPrefix(TokenString, out prefixPointer);
            Name = MachiningForTokenName(TokenString, prefixPointer);
            Format = MachiningForFormat(RawFormatText, FormatEvents);
            Params = MachiningForParams(RawParamsText);
            PropertyResolvingMode = PropertyResolvingToucher.Touch(RawFormatText);
        }

        public PropertyTokenTypes TokenType { get; }

        public string Prefix { get; }

        public string Name { get; }

        public string Format { get; }

        public string Params { get; }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsProperty;

        public override PropertyResolvingMode PropertyResolvingMode { get; }

        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        public override string ToString() => ToText();

        public override string Render() => ToString();

        #region private methods

        private static string MachiningForTokenPrefix(string rawText, out int position) {
            var index = rawText.IndexOf('#');
            position = index <= 0 ? 0 : index;
            return index < 0 ? string.Empty : rawText.Substring(0, index);
        }

        private static string MachiningForTokenName(string rawText, int position) {
            var colonIndex = rawText.IndexOf(':');
            return colonIndex < 0 ? rawText.Substring(position, rawText.Length - position) : rawText.Substring(position, colonIndex - position);
        }

        private static string MachiningForFormat(string format, IList<FormatEvent> formatEvents) {
            foreach (var @event in FormatCommandFactory.CreateCommandEvent(format)) {
                formatEvents.Add(@event);
            }

            return format;
        }

        private static string MachiningForParams(string paramsText) {
            return paramsText;
        }

        #endregion

    }
}