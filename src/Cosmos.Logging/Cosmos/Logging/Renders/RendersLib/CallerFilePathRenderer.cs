using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib {
    /// <summary>
    /// CallerFilePathRenderer
    /// </summary>
    [Renderer("CallerFilePath")]
    public class CallerFilePathRenderer : BasicPreferencesRenderer {

        /// <inheritdoc />
        public override string Name => "CallerFilePath";

        private static string FixedFilePath(ILogEventInfo logEventInfo = null) {
            return logEventInfo?.CallerInfo.FilePath ?? string.Empty;
        }

        /// <inheritdoc />
        public override string ToString(string format, string paramsText, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return FixedFilePath(logEventInfo);
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingEvents.ToFormat(FixedFilePath(logEventInfo), formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(FixedFilePath(logEventInfo), formatProvider);
        }

        /// <inheritdoc />
        public override void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public override void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public override void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEventInfo, formatProvider));
        }
    }
}