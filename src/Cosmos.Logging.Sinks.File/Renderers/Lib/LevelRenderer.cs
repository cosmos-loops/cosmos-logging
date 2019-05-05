using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;
using EnumsNET;

namespace Cosmos.Logging.Sinks.File.Renderers.Lib {
    public class LevelRenderer : BasicOutputPreferencesRenderer {

        public override string Name => "Level";

        public override string ToString(string format, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return logEvent.Level.GetName();
        }

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(logEvent.Level.GetName());
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            LogEvent logEvent, StringBuilder targetMessageBuilder, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(logEvent.Level.GetName());
        }
    }
}