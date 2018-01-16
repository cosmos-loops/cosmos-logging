namespace Cosmos.Logging.Core.Extensions {
    internal static class CharsExtensions {
        public static char[] Read(this char[] chars, int start, int length) {
            var ret = new char[length];
            for (var i = 0; i < length; i++) {
                ret[i] = chars[start + i];
            }

            return ret;
        }
    }
}