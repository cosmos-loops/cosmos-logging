using System;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Numeric convert helper
    /// </summary>
    public static class NumericConvertHelper
    {
        /// <summary>
        /// Convert from an object to integer
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static int ToInt32(object obj, int defaultRet = 0)
        {
            if (obj == null)
                return defaultRet;

            int ret;
            if (int.TryParse(obj.ToString(), out ret))
                return ret;

            try
            {
                return Convert.ToInt32(ToDouble(obj, (double)defaultRet));
            }
            catch
            {
                return defaultRet;
            }
        }

        /// <summary>
        /// Convert from an object to nullable integer
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(object obj)
        {
            if (obj == null)
                return null;

            int ret;
            if (int.TryParse(obj.ToString(), out ret))
                return ret;

            return null;
        }

        /// <summary>
        /// Convert from an object to double
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static double ToDouble(object obj, double defaultRet = 0D)
        {
            if (obj == null)
                return defaultRet;

            double ret;
            return double.TryParse(obj.ToString(), out ret) ? ret : defaultRet;
        }

        /// <summary>
        /// Convert from an object to double with specified precision
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static double ToRoundDouble(object obj, int digits, double defaultRet = 0D)
        {
            return Math.Round(ToDouble(obj, defaultRet), digits);
        }

        /// <summary>
        /// Convert from an object to nullable double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(object obj)
        {
            if (obj == null)
                return null;

            double ret;
            if (double.TryParse(obj.ToString(), out ret))
                return ret;

            return null;
        }

        /// <summary>
        /// Convert from an object to nullable double with specified precision
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ToRoundNullableDouble(object obj, int digits)
        {
            var ret = ToNullableDouble(obj);
            if (ret == null)
                return null;
            return Math.Round(ret.Value, digits);
        }

        /// <summary>
        /// Convert from an object to decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal defaultRet = 0M)
        {
            if (obj == null)
                return defaultRet;

            decimal ret;
            return decimal.TryParse(obj.ToString(), out ret) ? ret : defaultRet;
        }

        /// <summary>
        /// Convert from an object to decimal with specified precision
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static decimal ToRoundDecimal(object obj, int digits, decimal defaultRet = 0M)
        {
            return Math.Round(ToDecimal(obj, defaultRet), digits);
        }

        /// <summary>
        /// Convert from an object to nullable decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(object obj)
        {
            if (obj == null)
                return null;

            decimal ret;
            if (decimal.TryParse(obj.ToString(), out ret))
                return ret;

            return null;
        }

        /// <summary>
        /// Convert from an object to nullable decimal with specified precision
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToRoundNullableDecimal(object obj, int digits)
        {
            var ret = ToNullableDecimal(obj);
            if (ret == null)
                return null;
            return Math.Round(ret.Value, digits);
        }
    }
}
