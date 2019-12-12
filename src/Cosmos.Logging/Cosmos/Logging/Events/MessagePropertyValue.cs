using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Message property value
    /// </summary>
    public abstract class MessagePropertyValue : IFormattable {
        /// <summary>
        /// Render
        /// </summary>
        /// <param name="output"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        public abstract void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="output"></param>
        /// <param name="formatFuncs"></param>
        /// <param name="originFormat"></param>
        /// <param name="formatProvider"></param>
        public abstract void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="output"></param>
        /// <param name="formatEvents"></param>
        /// <param name="originFormat"></param>
        /// <param name="formatProvider"></param>
        public abstract void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="formatFuncs"></param>
        /// <param name="originFormat"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null, IFormatProvider formatProvider = null) {
            using (var output = new StringWriter()) {
                Render(output, formatFuncs, originFormat, formatProvider);
                return output.ToString();
            }
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="formatEvents"></param>
        /// <param name="originFormat"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            using (var output = new StringWriter()) {
                Render(output, formatEvents, originFormat, formatProvider);
                return output.ToString();
            }
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider) {
            using (var output = new StringWriter()) {
                Render(output, format, formatProvider);
                return output.ToString();
            }
        }

        /// <inheritdoc />
        public override string ToString() {
            return ToString(null, null);
        }
    }
}