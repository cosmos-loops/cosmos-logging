using System;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Numeric Conversion Utilities
    /// </summary>
    public static class NumericConversion
    {
        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="int"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static int ToInt32(object obj, int defaultRet = 0)
        {
            if (obj == null)
            {
                return defaultRet;
            }

            if (int.TryParse(obj.ToString(), out int ret))
            {
                return ret;
            }

            try
            {
                return Convert.ToInt32(ToDouble(obj, (double) defaultRet));
            }
            catch
            {
                return defaultRet;
            }
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="int"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (int.TryParse(obj.ToString(), out int ret))
            {
                return ret;
            }

            return null;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static double ToDouble(object obj, double defaultRet = 0D)
        {
            if (obj == null)
            {
                return defaultRet;
            }

            return double.TryParse(obj.ToString(), out double ret) ? ret : defaultRet;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/> with specified precision
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
        /// Convert from an <see cref="object"/> to nullable <see cref="double"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (double.TryParse(obj.ToString(), out double ret))
            {
                return ret;
            }

            return null;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="double"/> with specified precision
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ToRoundNullableDouble(object obj, int digits)
        {
            var ret = ToNullableDouble(obj);
            if (ret == null)
            {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal defaultRet = 0M)
        {
            if (obj == null)
            {
                return defaultRet;
            }

            return decimal.TryParse(obj.ToString(), out decimal ret) ? ret : defaultRet;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="decimal"/> with specified precision
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
        /// Convert from an <see cref="object"/> to nullable <see cref="decimal"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (decimal.TryParse(obj.ToString(), out decimal ret))
            {
                return ret;
            }

            return null;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="decimal"/> with specified precision
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToRoundNullableDecimal(object obj, int digits)
        {
            var ret = ToNullableDecimal(obj);
            if (ret == null)
            {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }
    }
}