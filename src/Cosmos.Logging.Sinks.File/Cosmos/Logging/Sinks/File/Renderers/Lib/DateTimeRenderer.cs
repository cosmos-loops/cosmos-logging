using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Sinks.File.Core.Extensions;

namespace Cosmos.Logging.Sinks.File.Renderers.Lib {
    /// <summary>
    /// Datetime renderer
    /// </summary>
    public class DateTimeRenderer : BasicOutputPreferencesRenderer {

        /// <inheritdoc />
        public override string Name => "Date";

        private static DateTime FixedDateTimeOffset(ILogEventInfo logEventInfo = null) {
            return logEventInfo?.Timestamp.DateTime ?? DateTime.Now;
        }

        private static string FixedFormat(string format, string paramsText) {
            return string.IsNullOrWhiteSpace(format)
                ? string.IsNullOrWhiteSpace(paramsText)
                    ? "yyyy/MM/dd HH:mm:ss.fff, z"
                    : paramsText
                : format;
        }

        /// <inheritdoc />
        public override string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return FixedDateTimeOffset(logEvent).ToString(FixedFormat(format, paramsText));
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(FixedDateTimeOffset(logEvent).ToString(FixedFormat(null, paramsText)), formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(FixedDateTimeOffset(logEvent).ToString(FixedFormat(null, paramsText)), formatProvider);
        }
    }
}