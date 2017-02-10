using System;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Datetime convert helper
    /// </summary>
    public static class DateTimeConvertHelper
    {
        /// <summary>
        /// Convert from an object to datetime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultRet = default(DateTime))
        {
            if (obj == null)
                return defaultRet;
            DateTime ret;
            return DateTime.TryParse(obj.ToString(), out ret) ? ret : defaultRet;
        }
    }
}
