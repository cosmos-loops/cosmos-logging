using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Sinks.File.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Renderers.Lib {
    /// <summary>
    /// Caller info renderer
    /// </summary>
    public class CallerInfoRenderer : BasicOutputPreferencesRenderer {

        /// <inheritdoc />
        public override string Name => "CallerInfo";

        /// <inheritdoc />
        public override string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return Formatings.Helpers.Internals.InternalCallerInfoHelper.GetCallerInfoString(logEvent);
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(formattingEvents.ToFormat(logEvent, formatProvider));
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(formattingFuncs.ToFormat(logEvent, formatProvider));
        }
    }
}