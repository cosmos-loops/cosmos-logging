using Cosmos.Verba;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Boolean convert helper
    /// </summary>
    public static class BooleanConvertHelper
    {
        /// <summary>
        /// Convert from object to boolean
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj)
        {
            if (obj == null)
                return false;

            var boolean = GetBoolean(obj);
            if (boolean.HasValue)
                return boolean.Value;


            bool ret;
            return bool.TryParse(obj.ToString(), out ret) && ret;
        }

        /// <summary>
        /// Convert from object to nullable boolean
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool? ToNullableBoolean(object obj)
        {
            if (obj == null)
                return null;

            var boolean = GetBoolean(obj);
            if (boolean.HasValue)
                return boolean.Value;

            bool ret;
            if (bool.TryParse(obj.ToString(), out ret))
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
