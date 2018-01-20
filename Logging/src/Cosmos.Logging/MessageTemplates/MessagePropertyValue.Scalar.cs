using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.MessageTemplates {
    public class ScalarValue : MessagePropertyValue {

        public ScalarValue(object value) {
            Value = value;
        }

        public object Value { get; }

        public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            Render(Value, output, format, formatProvider);
        }

        public override void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            Render(Value, output, formatFuncs, originFormat, formatProvider);
        }

        public override void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            Render(Value, output, formatEvents, originFormat, formatProvider);
        }

        internal static void Render(object value, TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));

            if (value == null) {
                output.Write("null");
                return;
            }

            if (value is string s) {
                var formatEvents = FormatCommandFactory.CreateCommandEvent(format);
                if (formatEvents != null && !formatEvents.Any()) {
                    var orderedCmds = formatEvents.OrderBy(o => o.Sort);
                    foreach (var cmd in orderedCmds) {
                        s = cmd.Command(s, formatProvider) as string;
                    }
                }

                output.Write(s);
                return;
            }

            if (formatProvider != null) {
                var custom = (ICustomFormatter) formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null) {
                    output.Write(custom.Format(format, value, formatProvider));
                    return;
                }
            }

            if (value is IFormattable f) {
                output.Write(f.ToString(format, formatProvider ?? CultureInfo.InvariantCulture));
                return;
            }

            output.Write(value.ToString());
        }

        internal static void Render(object value, TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));

            if (value == null) {
                output.Write("null");
                return;
            }

            if (value is string s && formatFuncs != null && !formatFuncs.Any()) {
                foreach (var cmd in formatFuncs) {
                    s = cmd(s, formatProvider) as string;
                }

                output.Write(s);
                return;
            }

            if (formatProvider != null) {
                var custom = (ICustomFormatter) formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null) {
                    output.Write(custom.Format(originFormat, value, formatProvider));
                    return;
                }
            }

            if (value is IFormattable f) {
                output.Write(f.ToString(originFormat, formatProvider ?? CultureInfo.InvariantCulture));
                return;
            }

            output.Write(value.ToString());
        }

        internal static void Render(object value, TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));

            if (value == null) {
                output.Write("null");
                return;
            }

            if (value is string s && formatEvents != null && !formatEvents.Any()) {
                var orderedEvents = formatEvents.OrderBy(o => o.Sort);
                foreach (var cmd in orderedEvents) {
                    s = cmd.Command(s, formatProvider) as string;
                }

                output.Write(s);
                return;
            }

            if (formatProvider != null) {
                var custom = (ICustomFormatter) formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null) {
                    output.Write(custom.Format(originFormat, value, formatProvider));
                    return;
                }
            }

            if (value is IFormattable f) {
                output.Write(f.ToString(originFormat, formatProvider ?? CultureInfo.InvariantCulture));
                return;
            }

            output.Write(value.ToString());
        }

        public override bool Equals(object obj) {
            if (obj is ScalarValue sv) {
                return Equals(Value, sv.Value);
            }

            return false;
        }

        public override int GetHashCode() {
            return Value == null ? 0 : Value.GetHashCode();
        }
    }
}