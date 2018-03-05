using System.Collections.Generic;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public class PropertyOutputMessageToken : OutputMessageToken {
        public readonly string RawFormatText;
        public readonly string RawParamsText;
        private readonly int ParamsFlagMode;
        public readonly List<FormatEvent> FormatEvents;

        public PropertyOutputMessageToken(string originText, string formatOriginText, string paramsOriginText,
            int index, int position, int paramsFlagMode, int fixOriginTextLength = 2)
            : base(originText, index, position, fixOriginTextLength) {
            FormatEvents = new List<FormatEvent>();
            RawFormatText = formatOriginText;
            RawParamsText = paramsOriginText;
            ParamsFlagMode = paramsFlagMode;
            Name = MachiningForTokenName(TokenString, 0);
            Format = MachiningForFormat(RawFormatText, FormatEvents);
            Params = MachiningForParams(RawParamsText);
        }

        public string Name { get; }

        public string Format { get; }

        public string Params { get; }

        public override TokenRenderTypes TokenRenderType { get; } = TokenRenderTypes.AsProperty;

        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        public override string ToString() => ToText();

        public override string Render() => ToString();

        #region private methods

        private static string MachiningForTokenName(string rawText, int position) {
            var colonIndex = rawText.IndexOf(':');
            position = position > 0 ? position + 1 : position;
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