using System;

namespace Cosmos.Logging.Formattings.Helpers {
    public static class PaddingHelper {
        internal static bool Check(out char command, out int width, string format = null) {
            command = char.MinValue;
            width = 0;
            if (format == null || string.IsNullOrWhiteSpace(format)) return false;
            var position = 0;

            while (position < format.Length) {
                if (Peek() == 'p') {
                    if (Next() == 'l' && TouchWidth(out var width1)) {
                        command = 'l';
                        width = width1;
                        return true;
                    }

                    if (Next() == 'r' && TouchWidth(out var width2)) {
                        command = 'r';
                        width = width2;
                        return true;
                    }
                }

                Skip();
            }

            return false;

            char Peek() => format[position];
            char Next(int step = 1) => position + step >= format.Length ? char.MinValue : format[position + step];
            void Skip() => position++;

            bool TouchWidth(out int totalWidth) {
                totalWidth = 0;
                var pointer = position + 2;
                while (pointer < format.Length) {
                    var c = format[pointer];
                    var a = (int) c;
                    if (a < 48 || a > 57) {
                        position = pointer;
                        break;
                    }

                    totalWidth = 10 * totalWidth + a - 48;

                    pointer++;
                }

                position = pointer;
                return totalWidth > 0;
            }

        }

        public static Func<char, Func<int, Func<object, IFormatProvider, object>>> Format() => c => w => {
            if (c == 'l') return PaddingLeft(w);
            if (c == 'r') return PaddingRight(w);
            throw new ArgumentException("Undefined casing command");
        };

        private static Func<object, IFormatProvider, object> PaddingLeft(int width) => (value, formatProvider) => {
            if (value is string s) {
                return s.Length >= width ? s : s.PadLeft(width, ' ');
            }

            return value;
        };

        private static Func<object, IFormatProvider, object> PaddingRight(int width) => (value, formatProvider) => {
            if (value is string s) {
                return s.Length >= width ? s : s.PadRight(width, ' ');
            }

            return value;
        };
    }
}