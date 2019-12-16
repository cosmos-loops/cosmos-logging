using System.Collections.Generic;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Sinks.File.Formatings;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Property output message token
    /// </summary>
    public class PropertyOutputMessageToken : OutputMessageToken {
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
        public readonly int ParamsFlagMode;
        
        /// <summary>
        /// Format events
        /// </summary>

        public readonly List<FormatEvent> FormatEvents;

        /// <inheritdoc />
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

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Params
        /// </summary>
        public string Params { get; }

        /// <inheritdoc />
        public override TokenRendererTypes TokenRendererType { get; } = TokenRendererTypes.AsProperty;

        /// <inheritdoc />
        public override string ToText() => $"{{{TokenString}}}, format={RawFormatText}, params={RawParamsText}";

        /// <inheritdoc />
        public override string ToString() => ToText();

        /// <inheritdoc />
        public override string Render() => ToString();

        #region private methods

        private static string MachiningForTokenName(string rawText, int position) {
            var colonIndex = rawText.IndexOf(':');
            position = position > 0 ? position + 1 : position;
            return colonIndex < 0 ? rawText.Substring(position, rawText.Length - position) : rawText.Substring(position, colonIndex - position);
        }

        private static string MachiningForFormat(string format, IList<FormatEvent> formatEvents) {
            foreach (var @event in OutputFormatCommandFactory.CreateCommandEvent(format)) {
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