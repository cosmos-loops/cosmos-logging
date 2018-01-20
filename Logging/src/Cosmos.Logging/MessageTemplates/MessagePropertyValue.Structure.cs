using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    public class StructureValue : MessagePropertyValue {

        private readonly MessageProperty[] _messageProperties;

        public StructureValue(IEnumerable<MessageProperty> properties, string flag = null) {
            if (properties == null) throw new ArgumentNullException(nameof(properties));
            Flag = flag;
            _messageProperties = properties.ToArray();
        }

        public string Flag { get; }

        public IReadOnlyList<MessageProperty> Properties => _messageProperties;

        public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (Flag != null) {
                output.Write(Flag);
                output.Write(' ');
            }

            output.Write("{ ");
            var allBugLast = _messageProperties.Length - 1;
            for (var i = 0; i < allBugLast; i++) {
                RenderInternal(output, _messageProperties[i], format, formatProvider);
                output.Write(',');
            }

            if (_messageProperties.Length > 0) {
                RenderInternal(output, _messageProperties[_messageProperties.Length - 1], format, formatProvider);
            }

            output.Write(" }");
        }

        public override void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (Flag != null) {
                output.Write(Flag);
                output.Write(' ');
            }

            output.Write("{ ");
            var allBugLast = _messageProperties.Length - 1;
            for (var i = 0; i < allBugLast; i++) {
                RenderInternal(output, _messageProperties[i], formatFuncs, originFormat, formatProvider);
                output.Write(',');
            }

            if (_messageProperties.Length > 0) {
                RenderInternal(output, _messageProperties[_messageProperties.Length - 1], formatFuncs, originFormat, formatProvider);
            }

            output.Write(" }");
        }

        public override void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (Flag != null) {
                output.Write(Flag);
                output.Write(' ');
            }

            output.Write("{ ");
            var allBugLast = _messageProperties.Length - 1;
            for (var i = 0; i < allBugLast; i++) {
                RenderInternal(output, _messageProperties[i], formatEvents, originFormat, formatProvider);
                output.Write(',');
            }

            if (_messageProperties.Length > 0) {
                RenderInternal(output, _messageProperties[_messageProperties.Length - 1], formatEvents, originFormat, formatProvider);
            }

            output.Write(" }");
        }

        private static void RenderInternal(TextWriter output, MessageProperty property, string format = null, IFormatProvider formatProvider = null) {
            output.Write(property.Name);
            output.Write(": ");
            property.Value.Render(output, format, formatProvider);
        }

        private static void RenderInternal(TextWriter output, MessageProperty property, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            output.Write(property.Name);
            output.Write(": ");
            property.Value.Render(output, formatFuncs, originFormat, formatProvider);
        }

        private static void RenderInternal(TextWriter output, MessageProperty property, IList<FormatEvent> formatEvents, string originFormat = null,
            IFormatProvider formatProvider = null) {
            output.Write(property.Name);
            output.Write(": ");
            property.Value.Render(output, formatEvents, originFormat, formatProvider);
        }
    }
}