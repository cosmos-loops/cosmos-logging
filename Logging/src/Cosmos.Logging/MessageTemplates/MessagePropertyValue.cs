using System;
using System.IO;

namespace Cosmos.Logging.MessageTemplates {
    public abstract class MessagePropertyValue : IFormattable {
        public abstract void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null);

        public string ToString(string format, IFormatProvider formatProvider) {
            using (var output = new StringWriter()) {
                Render(output, format, formatProvider);
                return output.ToString();
            }
        }

        public override string ToString() {
            return ToString(null, null);
        }
    }
}