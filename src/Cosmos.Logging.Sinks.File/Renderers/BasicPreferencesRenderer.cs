using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Renderers {
    public abstract class BasicOutputPreferencesRenderer : IOutputPreferencesRenderer {
        public abstract string Name { get; }
        public virtual bool IsNull => false;

        public abstract string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        public abstract string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        public abstract string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null);

        public virtual void Render(string format, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEvent, targetMessageBuilder, formatProvider));
        }

        public virtual void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEvent, targetMessageBuilder, formatProvider));
        }

        public virtual void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEvent, targetMessageBuilder, formatProvider));
        }
    }
}