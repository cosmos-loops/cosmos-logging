using System.Collections.Generic;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Property token
    /// </summary>
    public class PropertyToken : MessageTemplateToken {
        /// <summary>
        /// Raw format text
        /// </summary>
        public readonly string RawFormatText;

        /// <summary>
        /// Raw parameter text
        /// </summary>
        public readonly string RawParamsText;

        /// <summary>
        /// Params flag mode
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private readonly int ParamsFlagMode;

        /// <summary>
        /// Prefix pointer
        /// </summary>
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private int prefixPointer = 0;

        /// <summary>
        /// Format events
        /// </summary>
        public readonly List<FormatEvent> FormatEvents;

        /// <summary>
        /// Create a new instance of <see cref="PropertyToken"/>
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="formatOriginText"></param>
        /// <param name="paramsOriginText"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <param name="type"></param>
        /// <param name="paramsFlagMode"></param>
        /// <param name="fixOriginTextLength"></param>
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

        /// <summary>
        /// Gets token type
        /// </summary>
        public PropertyTokenTypes TokenType { get; }

        /// <summary>
        /// Gets prefix
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// Gets name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets format
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Gets params
        /// </summary>
        public string Params { get; }

        /// <inheritdoc />
        public override TokenRendererTypes TokenRendererType { get; } = TokenRendererTypes.AsProperty;

        /// <inheritdoc />
        public override PropertyResolvingMode PropertyResolvingMode { get; }

        /// <inheritdoc />
        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        /// <inheritdoc />
        public override string ToString() => ToText();

        /// <inheritdoc />
        public override string Render() => ToString();

        #region private methods

        private static string MachiningForTokenPrefix(string rawText, out int position) {
            var index = rawText.IndexOf('#');
            position = index <= 0 ? 0 : index;
            return index < 0 ? string.Empty : rawText.Substring(0, index);
        }

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