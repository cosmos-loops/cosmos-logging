using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib {
    /// <summary>
    /// EventLevelRenderer
    /// </summary>
    [Renderer("Level")]
    public class EventLevelRenderer : BasicPreferencesRenderer {
        /// <inheritdoc />
        public override string Name => "Level";

        private static string FixedEventLevel(ILogEventInfo logEventInfo, int aliasLength) {
            var alias = aliasLength <= 0
                ? LogEventLevelConverter.Convert(logEventInfo?.Level)
                : LogEventLevelConverter.Convert(logEventInfo?.Level, aliasLength);
            return alias;
        }

        private static int GetLength(string format, string paramsText) {

            if (!string.IsNullOrWhiteSpace(format)) {
                var chars = format.ToCharArray();

                if (chars.All(c => c == '#')) {
                    return chars.Length;
                }
            }

            if (!string.IsNullOrWhiteSpace(paramsText)) {
                var @params = paramsText.ToLower();
                var index = @params.IndexOf("length=", StringComparison.Ordinal);

                if (index < 0) return 0;

                var chars2 = @params.Substring(index + 7).ToCharArray();
                var sb = new StringBuilder();

                foreach (var @char in chars2) {
                    if (!@char.IsNumber())
                        break;
                    sb.Append(@char);
                }

                return sb.Length == 0
                    ? 0
                    : int.TryParse(sb.ToString(), out var ret)
                        ? ret
                        : 0;
            }

            return 0;
        }

        /// <inheritdoc />
        public override string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return FixedEventLevel(logEventInfo, GetLength(format, paramsText));
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(FixedEventLevel(logEventInfo, GetLength(null, paramsText)), formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(FixedEventLevel(logEventInfo, GetLength(null, paramsText)), formatProvider);
        }

        /// <inheritdoc />
        public override void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public override void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public override void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEventInfo, formatProvider));
        }
    }
}