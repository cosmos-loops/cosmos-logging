using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Sinks.File.Renderers {
    /// <summary>
    /// Null output preferences renderer
    /// </summary>
    [NonScanRenderer]
    public class NullOutputPreferencesRenderer : IOutputPreferencesRenderer {
        private static readonly NullOutputPreferencesRenderer NullOutputPreferencesRendererCache;

        static NullOutputPreferencesRenderer() {
            NullOutputPreferencesRendererCache = new NullOutputPreferencesRenderer();
        }

        /// <summary>
        /// Gets an instance of <see cref="NullOutputPreferencesRenderer"/>
        /// </summary>
        public static NullOutputPreferencesRenderer Instance => NullOutputPreferencesRendererCache;

        /// <inheritdoc />
        public string Name => "NullOutputPreferencesRender";

        /// <inheritdoc />
        public bool IsNull => true;

        /// <inheritdoc />
        public void Render(string format, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) { }

        /// <inheritdoc />
        public void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) { }

        /// <inheritdoc />
        public void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) { }

        /// <inheritdoc />
        public string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) => string.Empty;

        /// <inheritdoc />
        public string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) => string.Empty;

        /// <inheritdoc />
        public string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) => string.Empty;
    }
}