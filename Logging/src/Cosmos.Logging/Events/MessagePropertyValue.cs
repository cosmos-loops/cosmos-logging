using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Events {
    public abstract class MessagePropertyValue : IFormattable {
        public abstract void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null);
        public abstract void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null, IFormatProvider formatProvider = null);
        public abstract void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null);

        public string ToString(IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null, IFormatProvider formatProvider = null) {
            using (var output = new StringWriter()) {
                Render(output, formatFuncs, originFormat, formatProvider);
                return output.ToString();
            }
        }

        public string ToString(IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            using (var output = new StringWriter()) {
                Render(output, formatEvents, originFormat, formatProvider);
                return output.ToString();
            }
        }

        public string ToString(string format, IFormatProvider formatProvider) {
            using (var output = new StringWriter()) {
                Render(output, format, formatProvider);
                return output.ToString();
            }
        }

        public override string ToString() {
            return ToString((string) null, null);
        }
    }
}