using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Sinks.Log4Net.RendersLib {
    // ReSharper disable once InconsistentNaming
    [Renderer("HelloWorld", Internals.Constants.SinkKey)]
    public class Log4NetHelloWorldRenderer : BasicPreferencesSinkRenderer {

        private const string Content = "Log4Net, Hello World";

        public override string Name => "HelloWorld";

        public override string SinkPrefix => Internals.Constants.SinkKey;

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(Content, formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(Content, formatProvider);
        }

        public override string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return Content;
        }

        public override string ToString() {
            return ToString((string) null, null);
        }
    }
}