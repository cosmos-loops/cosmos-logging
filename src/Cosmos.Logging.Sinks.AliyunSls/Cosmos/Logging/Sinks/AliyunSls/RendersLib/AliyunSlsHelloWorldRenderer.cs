using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;
using Cosmos.Logging.Sinks.AliyunSls.Internals;

namespace Cosmos.Logging.Sinks.AliyunSls.RendersLib {
    /// <summary>
    /// AliyunHelloWorld renderer
    /// </summary>
    [Renderer("HelloWorld", Constants.SinkKey)]
    // ReSharper disable once InconsistentNaming
    public class AliyunSlsHelloWorldRenderer : BasicPreferencesSinkRenderer {
        private const string Content = "Aliyun SLS, Hello World";

        /// <inheritdoc />
        public override string Name => "HelloWorld";

        /// <inheritdoc />
        public override string SinkPrefix => Constants.SinkKey;

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