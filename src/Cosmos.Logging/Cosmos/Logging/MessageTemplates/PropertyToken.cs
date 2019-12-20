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

            SymbolicLocation(TokenString, out var c, out var p);
            Prefix = MachiningForTokenPrefix(TokenString, c, p, out prefixPointer);
            Name = MachiningForTokenName(TokenString, c, prefixPointer);
            Format = MachiningForFormat(RawFormatText, FormatEvents, Name);
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

        private static void SymbolicLocation(string rawText, out int colonIndex, out int poundIndex) {
            colonIndex = rawText.IndexOf(':');
            poundIndex = rawText.IndexOf('#');
        }

        private static string MachiningForTokenPrefix(string rawText, int colonIndex, int poundIndex, out int position) {
            if (colonIndex > 0 && poundIndex >= colonIndex)
                poundIndex = 0;
            position = poundIndex <= 0 ? 0 : poundIndex;
            return poundIndex < 0 ? string.Empty : rawText.Substring(0, poundIndex);
        }

        private static string MachiningForTokenName(string rawText, int colonIndex, int position) {
            position = position > 0 ? position + 1 : position;
            return colonIndex < 0 ? rawText.Substring(position, rawText.Length - position) : rawText.Substring(position, colonIndex - position);
        }

        private static string MachiningForFormat(string format, IList<FormatEvent> targetFormatEvents, string rendererName) {
            foreach (var @event in FormatCommandFactory.CreateCommandEvent(rendererName, format)) {
                targetFormatEvents.Add(@event);
            }

            //NOTE:
            //If this token is a PreferencesRender type, the name of token is same as the name of renderer.
            //So, here, i used 'rendererName' given by 'Name', which means the name of such token.

            return format;
        }

        private static string MachiningForParams(string paramsText) {
            return paramsText;
        }

        #endregion

    }
}