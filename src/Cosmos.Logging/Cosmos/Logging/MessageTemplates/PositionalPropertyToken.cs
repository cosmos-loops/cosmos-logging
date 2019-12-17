using System.Collections.Generic;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Positional property token
    /// </summary>
    public class PositionalPropertyToken : MessageTemplateToken {
        /// <summary>
        /// Raw format text
        /// </summary>
        public readonly string RawFormatText;

        /// <summary>
        /// Raw params text
        /// </summary>
        public readonly string RawParamsText;

        /// <summary>
        /// Params flag mode
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private readonly int ParamsFlagMode;

        /// <summary>
        /// Format events
        /// </summary>
        public readonly List<FormatEvent> FormatEvents;

        /// <summary>
        /// Create a new instance of <see cref="PositionalPropertyToken"/>.
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="formatOriginText"></param>
        /// <param name="paramsOriginText"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <param name="paramsFlagMode"></param>
        /// <param name="fixOriginTextLength"></param>
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

        /// <summary>
        /// Gets token type
        /// </summary>
        public PropertyTokenTypes TokenType => PropertyTokenTypes.PositionalProperty;

        /// <inheritdoc />
        public override PropertyResolvingMode PropertyResolvingMode { get; }

        /// <summary>
        /// Gets positional parameter value
        /// </summary>
        public int PositionalParameterValue { get; }

        /// <summary>
        /// Gets format
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Gets params
        /// </summary>
        public string Params { get; }

        /// <inheritdoc />
        public override TokenRendererTypes TokenRendererType { get; } = TokenRendererTypes.AsPositionalProperty;

        /// <inheritdoc />
        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        /// <inheritdoc />
        public override string ToString() => ToText();

        /// <inheritdoc />
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