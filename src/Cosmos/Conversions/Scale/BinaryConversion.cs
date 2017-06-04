using System;

namespace Cosmos.Conversions.Scale
{
    /// <summary>
    /// Binary Conversion Utilities
    /// </summary>
    public static class BinaryConversion
    {
        /// <summary>
        /// Convert from binary to decimalism
        /// </summary>
        /// <example>in: 101110; out: 46</example>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static int ToDecimalism(string bin)
        {
            return Convert.ToInt32(bin, 2);
        }

        /// <summary>
        /// Convert from binary to hexadecimal
        /// </summary>
        /// <example>in: 101110; out: 2E</example>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static string ToHexadecimal(string bin)
        {
            return DecimalismConversion.ToHexadecimal(ToDecimalism(bin));
        }
    }
}
