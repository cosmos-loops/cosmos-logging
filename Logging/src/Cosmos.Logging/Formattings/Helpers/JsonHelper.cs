using System;

namespace Cosmos.Logging.Formattings.Helpers {
    public static class JsonHelper {
        internal static bool Check(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) return false;
            return format.Contains("j");
        }

        public static object Format(object value, IFormatProvider formatProvider = null) {
            if (value is string s) {
                return Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }
    }
}