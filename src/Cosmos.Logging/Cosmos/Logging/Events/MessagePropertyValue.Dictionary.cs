using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Dictionary value
    /// </summary>
    public class DictionaryValue : MessagePropertyValue {

        /// <inheritdoc />
        public DictionaryValue(IEnumerable<KeyValuePair<ScalarValue, MessagePropertyValue>> elements) {
            if (elements == null) throw new ArgumentNullException(nameof(elements));
            Elements = elements.ToDictionary(p => p.Key, p => p.Value);
        }

        /// <summary>
        /// Gets elements
        /// </summary>
        public IReadOnlyDictionary<ScalarValue, MessagePropertyValue> Elements { get; }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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