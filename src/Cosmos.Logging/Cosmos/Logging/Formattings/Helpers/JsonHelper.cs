using System;
using Cosmos.Serialization.Json;

namespace Cosmos.Logging.Formattings.Helpers {
    /// <summary>
    /// Json helper
    /// </summary>
    public static class JsonHelper {
        internal static bool Check(string format = null) {
            if (format is null || string.IsNullOrWhiteSpace(format)) return false;
            return format.Contains("j");
        }

        /// <summary>
        /// Format
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static object Format(object value, IFormatProvider formatProvider = null) {
            if (value is string s) {
                return s.ToJson();
            }

            return value.ToJson();
        }
    }
}