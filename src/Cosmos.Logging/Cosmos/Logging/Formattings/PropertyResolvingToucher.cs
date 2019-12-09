using Cosmos.Logging.Events;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Property resolving toucher
    /// </summary>
    public static class PropertyResolvingToucher {

        /// <summary>
        /// Touch
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
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