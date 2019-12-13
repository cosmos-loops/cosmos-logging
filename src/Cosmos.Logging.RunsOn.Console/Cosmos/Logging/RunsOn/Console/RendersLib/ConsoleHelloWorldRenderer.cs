using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.RunsOn.Console.RendersLib {
    /// <summary>
    /// ConsoleHelloWorld renderer
    /// </summary>
    [Renderer("ConsoleHelloWorld")]
    public class ConsoleHelloWorldRenderer : BasicPreferencesRenderer {

        private const string Content = "Console, Hello World";

        /// <inheritdoc />
        public override string Name => "ConsoleHelloWorld";

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