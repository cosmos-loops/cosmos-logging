using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Core.Piplelines;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib {
    public class ProcessStartTime : BasicPreferencesRenderer {

        public override string Name => "ProcessStartTime";

        private static DateTime? StarTimeCache { get; set; }

        private static string GetProcessStartTime(string format, string paramsText) {
            return (StarTimeCache ?? (StarTimeCache = Process.GetCurrentProcess().StartTime)).Value.ToString(FixedFormat(format, paramsText));
        }

        private static string FixedFormat(string format, string paramsText) {
            return string.IsNullOrWhiteSpace(format)
                ? string.IsNullOrWhiteSpace(paramsText)
                    ? "yyyy/MM/dd HH:mm:ss.ffff, z"
                    : paramsText
                : format;
        }

        public override string ToString(string format, string paramsText, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return GetProcessStartTime(format, paramsText);
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(GetProcessStartTime(null, paramsText), formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(GetProcessStartTime(null, paramsText), formatProvider);
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