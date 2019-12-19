using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Basic preferences renderer
    /// </summary>
    public abstract class BasicPreferencesRenderer : IPreferencesRenderer {

        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public virtual bool IsNull => false;

        /// <inheritdoc />
        public abstract string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <inheritdoc />
        public abstract string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <inheritdoc />
        public abstract string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null);

        /// <inheritdoc />
        public virtual void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public virtual void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public virtual void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public virtual CustomFormatProvider CustomFormatProvider => null;

        /// <summary>
        /// Contains command or not.
        /// </summary>
        /// <param name="formatEvents"></param>
        /// <param name="commandAlias"></param>
        /// <returns></returns>
        protected static bool ContainsCommand(IList<FormatEvent> formatEvents, string commandAlias) {
            if (formatEvents is null || string.IsNullOrWhiteSpace(commandAlias))
                return false;
            return formatEvents.Any(x => x.CmdAlias2 == commandAlias);
        }

        /// <summary>
        /// Contains command or not.
        /// </summary>
        /// <param name="formatEvents"></param>
        /// <param name="commandAlias"></param>
        /// <returns></returns>
        protected static bool ContainsCommand(IList<FormatEvent> formatEvents, char commandAlias) {
            if (formatEvents is null || commandAlias == char.MinValue)
                return false;
            return formatEvents.Any(x => x.CmdAlias == commandAlias);
        }
    }
}