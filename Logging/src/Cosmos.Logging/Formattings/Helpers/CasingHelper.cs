using System;

namespace Cosmos.Logging.Formattings.Helpers {
    public static class CasingHelper {
        internal static bool Check(out char command, string format = null) {
            command = char.MinValue;
            if (format == null || string.IsNullOrWhiteSpace(format)) return false;
            var position = 0;
            while (position < format.Length) {
                var c = format[position];
                switch (c) {
                    case 'U':
                    case 'w':
                        command = c;
                        return true;
                }

                position++;
            }

            return false;
        }

        public static Func<char, Func<object, IFormatProvider, object>> Format() => c => {
            if (c == 'U') return ToUpperInvariant;
            if (c == 'w') return ToLowerInvariant;
            throw new ArgumentException("Undefined casing command");
        };

        private static object ToUpperInvariant(object value, IFormatProvider formatProvider = null) {
            if (value is string s) {
                return s.ToUpperInvariant();
            }

            return value;
        }

        private static object ToLowerInvariant(object value, IFormatProvider formatProvider = null) {
            if (value is string s) {
                return s.ToLowerInvariant();
            }

            return value;
        }
    }
}