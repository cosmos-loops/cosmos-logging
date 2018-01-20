using System;

namespace Cosmos.Logging.Formattings.Helpers {
    public static class StringHelper {
        public static bool Check(out char command, string format = null) {
            command = char.MinValue;
            if (format == null || string.IsNullOrWhiteSpace(format)) return false;
            var position = 0;
            while (position < format.Length) {
                var c = format[position];
                switch (c) {
                    case 'S':
                    case 's':
                        command = c;
                        return true;
                }

                position++;
            }

            return false;
        }

        public static Func<char, Func<object, IFormatProvider, object>> Format() => c => {
            if (c == 'S') return ToStringForce;
            if (c == 's') return ToStringLightly;
            throw new ArgumentException("Undefined casing command");
        };

        private static object ToStringForce(object value, IFormatProvider formatProvider = null) {
            return value.ToString();
        }

        private static object ToStringLightly(object value, IFormatProvider formatProvider = null) {
            return value.ToString();
        }
    }
}