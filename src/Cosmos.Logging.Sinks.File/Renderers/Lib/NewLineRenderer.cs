using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Renderers.Lib {
    public class NewLineRenderer : BasicOutputPreferencesRenderer {

        public override string Name => "NewLine";

        public override string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return Environment.NewLine;
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return Environment.NewLine;
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return Environment.NewLine;
        }
    }
}