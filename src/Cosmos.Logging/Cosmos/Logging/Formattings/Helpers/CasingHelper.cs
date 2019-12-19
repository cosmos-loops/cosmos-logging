using System;

namespace Cosmos.Logging.Formattings.Helpers {
    /// <summary>
    /// Casing helper
    /// </summary>
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
                    case 't':
                        command = c;
                        return true;
                }

                position++;
            }

            return false;
        }

        /// <summary>
        /// Format
        /// </summary>
        /// <returns></returns>
        public static Func<char, Func<object, IFormatProvider, object>> Format() => c => {
            return c switch {
                'U' => ToUpperInvariant,
                'w' => ToLowerInvariant,
                't' => ToTitleInvariant,
                _   => ReturnOneself
            };
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

        private static object ToTitleInvariant(object value, IFormatProvider formatProvider = null) {
            if (value is string s) {
                if (s.Length == 0)
                    return s;

                if (s.Length == 1)
                    return $"{s[0]}".ToUpperInvariant();

                if (s.Length > 1)
                    return $"{$"{s[0]}".ToUpperInvariant()}{s.Substring(1, s.Length - 1)}";

                return s;
            }

            return value;
        }

        private static object ReturnOneself(object value, IFormatProvider formatProvider = null) {
            return value;
        }
    }
}