using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib {
    public class DateRenderer : BasicPreferencesRenderer {

        public override string Name => "Date";

        private static DateTimeOffset FixedDateTimeOffset(ILogEventInfo logEventInfo = null) {
            return logEventInfo?.Timestamp ?? DateTimeOffset.Now;
        }

        private static string FixedFormat(string format, string paramsText) {
            return string.IsNullOrWhiteSpace(format)
                ? string.IsNullOrWhiteSpace(paramsText)
                    ? "yyyy/MM/dd HH:mm:ss.ffff, z"
                    : paramsText
                : format;
        }

        public override string ToString(string format, string paramsText, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return FixedDateTimeOffset(logEventInfo).ToString(FixedFormat(format, paramsText));
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(FixedDateTimeOffset(logEventInfo).ToString(FixedFormat(null, paramsText)), formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(FixedDateTimeOffset(logEventInfo).ToString(FixedFormat(null, paramsText)), formatProvider);
        }

        public override void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEventInfo, formatProvider));
        }

        public override void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEventInfo, formatProvider));
        }

        public override void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEventInfo, formatProvider));
        }
    }
}