using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    public class NullPreferencesSinkRenderer : IPreferencesSinkRenderer {
        private static readonly NullPreferencesSinkRenderer NullPreferencesSinkRendererCache;

        static NullPreferencesSinkRenderer() {
            NullPreferencesSinkRendererCache = new NullPreferencesSinkRenderer();
        }

        public static NullPreferencesSinkRenderer Instance => NullPreferencesSinkRendererCache;

        public string SinkPrefix => "Null";
        public string Name => "NullPreferencesSinkRender";
        public bool IsNull => true;

        public void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) { }

        public void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) { }

        public void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) { }

        public string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) => string.Empty;

        public string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) => string.Empty;

        public string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) => string.Empty;
    }
}