using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    public class DictionaryValue : MessagePropertyValue {

        public DictionaryValue(IEnumerable<KeyValuePair<ScalarValue, MessagePropertyValue>> elements) {
            if (elements == null) throw new ArgumentNullException(nameof(elements));
            Elements = elements.ToDictionary(p => p.Key, p => p.Value);
        }

        public IReadOnlyDictionary<ScalarValue, MessagePropertyValue> Elements { get; }

        public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.Write('[');
            var delim = "(";
            foreach (var kvp in Elements) {
                output.Write(delim);
                delim = ", (";
                kvp.Key.Render(output, format, formatProvider);
                output.Write(": ");
                kvp.Value.Render(output, format, formatProvider);
                output.Write(")");
            }

            output.Write(']');
        }

        public override void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.Write('[');
            var delim = "(";
            foreach (var kvp in Elements) {
                output.Write(delim);
                delim = ", (";
                kvp.Key.Render(output, formatFuncs, originFormat, formatProvider);
                output.Write(": ");
                kvp.Value.Render(output, formatFuncs, originFormat, formatProvider);
                output.Write(")");
            }

            output.Write(']');
        }

        public override void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.Write('[');
            var delim = "(";
            foreach (var kvp in Elements) {
                output.Write(delim);
                delim = ", (";
                kvp.Key.Render(output, formatEvents, originFormat, formatProvider);
                output.Write(": ");
                kvp.Value.Render(output, formatEvents, originFormat, formatProvider);
                output.Write(")");
            }

            output.Write(']');
        }
    }
}