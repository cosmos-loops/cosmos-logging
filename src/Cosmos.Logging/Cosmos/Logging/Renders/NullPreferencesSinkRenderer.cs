using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Null preferences sink renderer
    /// </summary>
    [NonScanRenderer]
    public class NullPreferencesSinkRenderer : IPreferencesSinkRenderer {
        private static readonly NullPreferencesSinkRenderer NullPreferencesSinkRendererCache;

        static NullPreferencesSinkRenderer() {
            NullPreferencesSinkRendererCache = new NullPreferencesSinkRenderer();
        }

        /// <summary>
        /// Gets an instance of <see cref="NullPreferencesSinkRenderer"/>.
        /// </summary>
        public static NullPreferencesSinkRenderer Instance => NullPreferencesSinkRendererCache;

        /// <inheritdoc />
        public string SinkPrefix => "Null";

        /// <inheritdoc />
        public string Name => "NullPreferencesSinkRender";

        /// <inheritdoc />
        public bool IsNull => true;

        /// <inheritdoc />
        public void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) { }

        /// <inheritdoc />
        public void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) { }

        /// <inheritdoc />
        public void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) { }

        /// <inheritdoc />
        public string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) => string.Empty;

        /// <inheritdoc />
        public string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) => string.Empty;

        /// <inheritdoc />
        public string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) => string.Empty;

        /// <inheritdoc />
        public virtual CustomFormatProvider CustomFormatProvider => null;
    }
}