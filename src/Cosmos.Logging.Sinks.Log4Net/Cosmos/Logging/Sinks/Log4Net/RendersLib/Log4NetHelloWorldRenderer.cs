using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Sinks.Log4Net.RendersLib {
    /// <summary>
    /// Log4NetHelloWorldRenderer
    /// </summary>
    // ReSharper disable once InconsistentNaming
    [Renderer("HelloWorld", Internals.Constants.SinkKey)]
    public class Log4NetHelloWorldRenderer : BasicPreferencesSinkRenderer {

        private const string Content = "Log4Net, Hello World";

        /// <inheritdoc />
        public override string Name => "HelloWorld";

        /// <inheritdoc />
        public override string SinkPrefix => Internals.Constants.SinkKey;

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(Content, formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(Content, formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return Content;
        }

        /// <inheritdoc />
        public override string ToString() {
            return ToString((string) null, null);
        }
    }
}