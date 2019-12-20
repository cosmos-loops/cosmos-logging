using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Scalar value
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ScalarValue : MessagePropertyValue {

        /// <inheritdoc />
        public ScalarValue(object value) {
            Value = value;
        }

        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; }

        /// <inheritdoc />
        public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            Render(Value, output, format, formatProvider);
        }

        /// <inheritdoc />
        public override void Render(TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            Render(Value, output, formatFuncs, originFormat, formatProvider);
        }

        /// <inheritdoc />
        public override void Render(TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            Render(Value, output, formatEvents, originFormat, formatProvider);
        }

        internal static void Render(object value, TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            if (output is null) throw new ArgumentNullException(nameof(output));
            IEnumerable<FormatEvent> __f(string ____f) => FormatCommandFactory.CreateCommandEvent(null, ____f);

            if (value is null) {
                output.Write(__f(format).ToFormat("null", formatProvider));
                return;
            }

            if (value is string s) {
                output.Write(__f(format).ToFormat(s, formatProvider));
                return;
            }

            if (formatProvider != null) {
                var custom = (ICustomFormatter) formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null) {
                    output.Write(__f(format).ToFormat(custom.Format(format, value, formatProvider), formatProvider));
                    return;
                }
            }

            if (value is IFormattable f) {
                output.Write(__f(format).ToFormat(f.ToString(format, formatProvider ?? CultureInfo.InvariantCulture), formatProvider));
                return;
            }

            output.Write(value.ToString());
        }

        internal static void Render(object value, TextWriter output, IList<Func<object, IFormatProvider, object>> formatFuncs, string originFormat = null,
            IFormatProvider formatProvider = null) {
            if (output is null) throw new ArgumentNullException(nameof(output));

            if (value is null) {
                output.Write(formatFuncs.ToFormat("null", formatProvider));
                return;
            }

            if (value is string s) {
                output.Write(formatFuncs.ToFormat(s, formatProvider));
                return;
            }

            if (formatProvider != null) {
                var custom = (ICustomFormatter) formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null) {
                    output.Write(formatFuncs.ToFormat(custom.Format(originFormat, value, formatProvider), formatProvider));
                    return;
                }
            }

            if (value is IFormattable f) {
                output.Write(formatFuncs.ToFormat(f.ToString(originFormat, formatProvider ?? CultureInfo.InvariantCulture), formatProvider));
                return;
            }

            output.Write(value.ToString());
        }

        internal static void Render(object value, TextWriter output, IList<FormatEvent> formatEvents, string originFormat = null, IFormatProvider formatProvider = null) {
            if (output == null) throw new ArgumentNullException(nameof(output));

            if (value == null) {
                output.Write(formatEvents.ToFormat("null", formatProvider));
                return;
            }

            if (value is string s) {
                output.Write(formatEvents.ToFormat(s, formatProvider));
                return;
            }

            if (formatProvider != null) {
                var custom = (ICustomFormatter) formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null) {
                    output.Write(formatEvents.ToFormat(custom.Format(originFormat, value, formatProvider), formatProvider));
                    return;
                }
            }

            if (value is IFormattable f) {
                output.Write(formatEvents.ToFormat(f.ToString(originFormat, formatProvider ?? CultureInfo.InvariantCulture), formatProvider));
                return;
            }

            output.Write(value.ToString());
        }

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (obj is ScalarValue sv) {
                return Equals(Value, sv.Value);
            }

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return Value == null ? 0 : Value.GetHashCode();
        }
    }
}