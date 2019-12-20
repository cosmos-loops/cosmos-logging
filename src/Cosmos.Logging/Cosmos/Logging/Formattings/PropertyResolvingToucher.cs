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
                mode = c switch {
                    'S' => PropertyResolvingMode.Stringify,
                    's' => PropertyResolvingMode.Stringify,
                    'D' => PropertyResolvingMode.Destructure,
                    'd' => PropertyResolvingMode.Destructure,
                    _   => mode
                };

                position++;
            }

            return mode;
        }
    }
}