using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib {
    public class ProcessUserProcessorTime : BasicPreferencesRenderer {

        public override string Name => "UserProcessorTime";

        private static string GetProcessStartTime(string paramsText) {
            var ts = Process.GetCurrentProcess().UserProcessorTime;
            switch (paramsText.ToLower()) {
                case "d": return ts.TotalDays.ToString(CultureInfo.InvariantCulture);
                case "h": return ts.TotalHours.ToString(CultureInfo.InvariantCulture);
                case "m": return ts.TotalMinutes.ToString(CultureInfo.InvariantCulture);
                case "s": return ts.TotalSeconds.ToString(CultureInfo.InvariantCulture);
                case "ms": return ts.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
                case "full":
                    var d = ts.Days;
                    var h = ts.Hours;
                    var m = ts.Minutes;
                    var s = ts.Seconds;
                    var ms = ts.Milliseconds;
                    return $"{d} {(d > 1 ? "days" : "day")} {h} {(d > 1 ? "Hours" : "Hour")} {m} {(m > 1 ? "Minutes" : "Minute")} {s}.{ms} {(s > 1 ? "Seconds" : "Second")}";
                default:
                    return ts.Ticks.ToString();
            }

        }

        public override string ToString(string format, string paramsText, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return GetProcessStartTime(paramsText);
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(GetProcessStartTime(paramsText), formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(GetProcessStartTime(paramsText), formatProvider);
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