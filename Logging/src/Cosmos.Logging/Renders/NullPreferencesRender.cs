using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    public class NullPreferencesRender : IPreferencesRender {
        private static readonly NullPreferencesRender NullPreferencesRenderCache;

        static NullPreferencesRender() {
            NullPreferencesRenderCache = new NullPreferencesRender();
        }

        public static NullPreferencesRender Instance => NullPreferencesRenderCache;

        public string Name => "NullPreferencesRender";
        public bool IsNull => true;

        public void Render(string format, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) { }
        public void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) { }
        public void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder, IFormatProvider formatProvider = null) { }
        public string ToString(string format, string paramsText, IFormatProvider formatProvider = null) => string.Empty;
        public string ToString(IList<FormatEvent> formattingEvents, string paramsText, IFormatProvider formatProvider = null) => string.Empty;
        public string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, IFormatProvider formatProvider = null) => string.Empty;
    }
}