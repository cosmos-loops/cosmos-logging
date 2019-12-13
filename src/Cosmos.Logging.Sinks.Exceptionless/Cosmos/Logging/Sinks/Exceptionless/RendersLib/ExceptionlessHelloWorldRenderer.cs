using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.Sinks.Exceptionless.RendersLib {
    /// <summary>
    /// ExceptionlessHelloWorldRenderer
    /// </summary>
    [Renderer("HelloWorld", Internals.Constants.SinkKey)]
    // ReSharper disable once InconsistentNaming
    public class ExceptionlessHelloWorldRenderer : BasicPreferencesSinkRenderer {

        private const string Content = "Exceptionless, Hello World";

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