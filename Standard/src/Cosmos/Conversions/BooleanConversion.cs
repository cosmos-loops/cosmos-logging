using Cosmos.Verba.Boolean;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Boolean Conversion Utilities
    /// </summary>
    public static class BooleanConversion
    {
        /// <summary>
        /// Convert from object to boolean
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var boolean = GetBoolean(obj);

            return boolean ?? bool.TryParse(obj.ToString(), out var ret) && ret;
        }

        /// <summary>
        /// Convert from object to nullable boolean
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool? ToNullableBoolean(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var boolean = GetBoolean(obj);

            if (boolean.HasValue)
            {
                return boolean.Value;
            }

            if (bool.TryParse(obj.ToString(), out var ret))
            {
                return ret;
            }

            return null;
        }

        private static bool? GetBoolean(object obj)
        {
            return GlobalBooleanVerbaManager.Determining(obj.ToString().Trim().ToLower());
        }
    }
}