using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    [NonScanRenderer]
    public class NullPreferencesRenderer : IPreferencesRenderer {
        private static readonly NullPreferencesRenderer NullPreferencesRendererCache;

        static NullPreferencesRenderer() {
            NullPreferencesRendererCache = new NullPreferencesRenderer();
        }

        public static NullPreferencesRenderer Instance => NullPreferencesRendererCache;

        public string Name => "NullPreferencesRender";
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

        public virtual CustomFormatProvider CustomFormatProvider => null;
    }
}