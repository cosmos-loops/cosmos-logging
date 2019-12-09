using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Sequence value
    /// </summary>
    public class SequenceValue : MessagePropertyValue {
        private readonly MessagePropertyValue[] _elements;

        /// <inheritdoc />
        public SequenceValue(IEnumerable<MessagePropertyValue> elements) {
            if (elements == null) throw new ArgumentNullException(nameof(elements));
            _elements = elements.ToArray();
        }

        /// <summary>
        /// Gets all elements
        /// </summary>
        public IReadOnlyList<MessagePropertyValue> Elements => _elements;

        /// <inheritdoc />
        public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.Write('[');
            var allButLast = _elements.Length - 1;
            for (var i = 0; i < allButLast; i++) {
                _elements[i].Render(output, format, formatProvider);
                output.Write(", ");
            }

            if (_elements.Length > 0)
                _elements[_elements.Length - 1].Render(output, format, formatProvider);

            output.Write(']');
        }

        /// <inheritdoc />
        public override void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.Write('[');
            var allButLast = _elements.Length - 1;
            for (var i = 0; i < allButLast; i++) {
                _elements[i].Render(output, formatFuncs, originFormat, formatProvider);
                output.Write(", ");
            }

            if (_elements.Length > 0)
                _elements[_elements.Length - 1].Render(output, formatFuncs, originFormat, formatProvider);

            output.Write(']');
        }

        /// <inheritdoc />
        public override void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.Write('[');
            var allButLast = _elements.Length - 1;
            for (var i = 0; i < allButLast; i++) {
                _elements[i].Render(output, formatEvents, originFormat, formatProvider);
                output.Write(", ");
            }

            if (_elements.Length > 0)
                _elements[_elements.Length - 1].Render(output, formatEvents, originFormat, formatProvider);

            output.Write(']');
        }
    }
}