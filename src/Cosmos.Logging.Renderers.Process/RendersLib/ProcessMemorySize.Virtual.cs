using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Renderers.Process.RendersLib {
    [Renderer("VirtualMemorySize")]
    public class ProcessVirtualMemorySize : BasicPreferencesRenderer {

        public override string Name => "VirtualMemorySize";

        private static string GetVirtualMemorySize(string format, string paramsText) {
            var cmd = FixedFormat(format, paramsText);
            switch (cmd) {
#pragma warning disable 618
                case 32: return System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize.ToString();
#pragma warning restore 618
                case 64: return System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64.ToString();
                default: throw new InvalidOperationException("can not resolve such params text");
            }
        }

        private static int FixedFormat(string format, string paramsText) {
            if (string.IsNullOrWhiteSpace(format)) return TryConvert(paramsText);
            return TryConvert(format);

            int TryConvert(string v) {
                return int.TryParse(v, out var n)
                    ? n == 32
                        ? 32
                        : 64
                    : 64;
            }
        }


        public override string ToString(string format, string paramsText, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return GetVirtualMemorySize(format, paramsText);
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(GetVirtualMemorySize(null, paramsText), formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(GetVirtualMemorySize(null, paramsText), formatProvider);
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