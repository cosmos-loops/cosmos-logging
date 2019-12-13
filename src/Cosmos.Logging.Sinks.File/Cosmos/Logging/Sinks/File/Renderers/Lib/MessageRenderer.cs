using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Renderers.Lib {
    /// <summary>
    /// Message renderer
    /// </summary>
    public class MessageRenderer : BasicOutputPreferencesRenderer {

        /// <inheritdoc />
        public override string Name => "Message";

        private static string GetMessage(StringBuilder targetMessageBuilder) {
            if (targetMessageBuilder == null || targetMessageBuilder.Length == 0) return string.Empty;
            return targetMessageBuilder.ToString();
        }

        /// <inheritdoc />
        public override string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return GetMessage(targetMessageBuilder);
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(GetMessage(targetMessageBuilder));
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(GetMessage(targetMessageBuilder));
        }
    }
}