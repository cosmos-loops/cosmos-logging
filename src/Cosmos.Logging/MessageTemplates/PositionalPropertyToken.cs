using System.Collections.Generic;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    public class PositionalPropertyToken : MessageTemplateToken {
        public readonly string RawFormatText;
        public readonly string RawParamsText;
        private readonly int ParamsFlagMode;
        public readonly List<FormatEvent> FormatEvents;

        public PositionalPropertyToken(string originText, string formatOriginText, string paramsOriginText,
            int index, int position, int paramsFlagMode, int fixOriginTextLength = 2)
            : base(originText, index, position, 1, fixOriginTextLength) {
            FormatEvents = new List<FormatEvent>();
            RawFormatText = formatOriginText;
            RawParamsText = paramsOriginText;
            ParamsFlagMode = paramsFlagMode;
            PositionalParameterValue = MachiningForPositionalValue(TokenString);
            Format = MachiningForFormat(RawFormatText, FormatEvents);
            Params = MachiningForParams(RawParamsText);
            PropertyResolvingMode = PropertyResolvingToucher.Touch(RawFormatText);
        }

        public PropertyTokenTypes TokenType => PropertyTokenTypes.PositionalProperty;

        public override PropertyResolvingMode PropertyResolvingMode { get; }

        public int PositionalParameterValue { get; }

        public string Format { get; }

        public string Params { get; }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsPositionalProperty;

        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        public override string ToString() => ToText();

        public override string Render() => ToString();

        #region private methods

        private static int MachiningForPositionalValue(string rawText) {
            var colonIndex = rawText.IndexOf(':');
            var str = colonIndex < 0 ? rawText : rawText.Substring(0, colonIndex);
            return int.TryParse(str, out var ret) ? ret : 0;
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