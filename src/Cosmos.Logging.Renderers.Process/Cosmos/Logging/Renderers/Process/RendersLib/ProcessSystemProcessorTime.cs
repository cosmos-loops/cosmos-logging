using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;
using Humanizer;

namespace Cosmos.Logging.Renderers.Process.RendersLib {
    /// <summary>
    /// SystemProcessorTime renderer
    /// </summary>
    [Renderer("SystemProcessorTime")]
    public class ProcessSystemProcessorTime : BasicPreferencesRenderer {

        /// <inheritdoc />
        public override string Name => "SystemProcessorTime";

        private static string GetSystemProcessorTime(string paramsText) {
            var ts = System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime;
            switch (paramsText.ToLower()) {
                case "d": return ts.TotalDays.ToString(CultureInfo.InvariantCulture);
                case "h": return ts.TotalHours.ToString(CultureInfo.InvariantCulture);
                case "m": return ts.TotalMinutes.ToString(CultureInfo.InvariantCulture);
                case "s": return ts.TotalSeconds.ToString(CultureInfo.InvariantCulture);
                case "ms": return ts.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
                case "full":
//                    var d = ts.Days;
//                    var h = ts.Hours;
//                    var m = ts.Minutes;
//                    var s = ts.Seconds;
//                    var ms = ts.Milliseconds;
                    return ts.Humanize();
//                    return $"{d} {(d > 1 ? "days" : "day")} {h} {(d > 1 ? "Hours" : "Hour")} {m} {(m > 1 ? "Minutes" : "Minute")} {s}.{ms} {(s > 1 ? "Seconds" : "Second")}";
                default:
                    return ts.Ticks.ToString();
            }

        }

        /// <inheritdoc />
        public override string ToString(string format, string paramsText, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return GetSystemProcessorTime(paramsText);
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(GetSystemProcessorTime(paramsText), formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(GetSystemProcessorTime(paramsText), formatProvider);
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