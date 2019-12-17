using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Renderers {
    /// <summary>
    /// Basic output preferences renderer
    /// </summary>
    public abstract class BasicOutputPreferencesRenderer : IOutputPreferencesRenderer {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public virtual bool IsNull => false;

        /// <inheritdoc />
        public abstract string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <inheritdoc />
        public abstract string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <inheritdoc />
        public abstract string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        /// <inheritdoc />
        public virtual void Render(string format, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEvent, targetMessageBuilder, formatProvider));
        }

        /// <inheritdoc />
        public virtual void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEvent, targetMessageBuilder, formatProvider));
        }

        /// <inheritdoc />
        public virtual void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEvent, targetMessageBuilder, formatProvider));
        }
    }
}