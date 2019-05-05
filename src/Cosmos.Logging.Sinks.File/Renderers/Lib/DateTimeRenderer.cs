using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Sinks.File.Core.Extensions;

namespace Cosmos.Logging.Sinks.File.Renderers.Lib {
    public class DateTimeRenderer : BasicOutputPreferencesRenderer {

        public override string Name => "Date";

        private static DateTime FixedDateTimeOffset(ILogEventInfo logEventInfo = null) {
            return logEventInfo?.Timestamp.DateTime ?? DateTime.Now;
        }

        private static string FixedFormat(string format, string paramsText) {
            return string.IsNullOrWhiteSpace(format)
                ? string.IsNullOrWhiteSpace(paramsText)
                    ? "yyyy/MM/dd HH:mm:ss.ffff, z"
                    : paramsText
                : format;
        }

        public override string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return FixedDateTimeOffset(logEvent).ToString(FixedFormat(format, paramsText));
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(FixedDateTimeOffset(logEvent).ToString(FixedFormat(null, paramsText)), formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(FixedDateTimeOffset(logEvent).ToString(FixedFormat(null, paramsText)), formatProvider);
        }
    }
}