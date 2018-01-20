using Cosmos.Logging.Events;

namespace Cosmos.Logging.Formattings {
    public static class PropertyResolvingToucher {

        public static PropertyResolvingMode Touch(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format))
                return PropertyResolvingMode.Default;

            var mode = PropertyResolvingMode.Default;
            var position = 0;
            while (position < format.Length) {
                var c = format[position];
                switch (c) {
                    case 'S':
                    case 's':
                        mode = PropertyResolvingMode.Stringify;
                        break;

                    case 'D':
                    case 'd':
                        mode = PropertyResolvingMode.Destructure;
                        break;
                }

                position++;
            }

            return mode;
        }
    }
}