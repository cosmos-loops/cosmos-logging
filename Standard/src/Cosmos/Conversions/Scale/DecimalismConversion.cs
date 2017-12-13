using System;

namespace Cosmos.Conversions.Scale
{
    /// <summary>
    /// Decimalism Conversion Utilities
    /// </summary>
    public static class DecimalismConversion
    {
        /// <summary>
        /// Convert from decimalism to binary
        /// </summary>
        /// <example>in: 46; out: 101110</example>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string ToBinary(int dec)
        {
            return Convert.ToString(dec, 2);
        }

        /// <summary>
        /// Convert from decimal to hexadecimal
        /// </summary>
        /// <example>in: 46; out: 2E</example>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string ToHexadecimal(int dec)
        {
            return Convert.ToString(dec, 16).ToUpper();
        }

        /// <summary>
        /// Convert from decimal to hexadecimal
        /// </summary>
        /// <example>in: 46, 4; out: 002E</example>
        /// <param name="dec"></param>
        /// <param name="formatLength"></param>
        /// <returns></returns>
        public static string ToHexadecimal(int dec, int formatLength)
        {
            var hex = ToHexadecimal(dec);
            return hex.Length > formatLength ? hex : hex.PadLeft(formatLength, '0');
        }
    }
}