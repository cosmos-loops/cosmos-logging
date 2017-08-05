using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cosmos.Conversions.Scale
{
    /// <summary>
    /// Hexadecimal Conversion Utilities
    /// </summary>
    public static class HexadecimalConversion
    {
        /// <summary>
        /// Convert from hexadecimal to decimalism
        /// </summary>
        /// <example>in: 2E; out: 46</example>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int ToDecimalism(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        /// <summary>
        /// Convert from hexadecimal to binary
        /// </summary>
        /// <example>in: 2E; out: 101110</example>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string ToBinary(string hex)
        {
            return DecimalismConversion.ToBinary(ToDecimalism(hex));
        }

        /// <summary>
        /// Convert from hexadecimal to bytes
        /// </summary>
        /// <example>in: 2E3D; out: result[0] is 46, result[1] is 61</example>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] ToBytes(string hex)
        {
            var mc = Regex.Matches(hex, @"(?i)[\da-f]{2}");
            return (from Match m in mc select Convert.ToByte(m.Value, 16)).ToArray();
        }

        /// <summary>
        /// Convert from hexadecimal to string
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="encodingName">encoding name, default is "utf-8"</param>
        /// <returns></returns>
        public static string ToString(string hex, string encodingName = "utf-8")
        {
            hex = hex.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(hex))
            {
                return "";
            }

            var bytes = new byte[hex.Length / 2];
            for (var i = 0; i < hex.Length; i += 2)
            {
                if (!byte.TryParse(hex.Substring(i, 2), NumberStyles.HexNumber, null, out bytes[i / 2]))
                {
                    bytes[i / 2] = 0;
                }
            }

            return Encoding.GetEncoding(encodingName).GetString(bytes);
        }

        /// <summary>
        /// Convert from string to hexadecimal
        /// </summary>
        /// <example>in: A; out: 1000001</example>
        /// <param name="str"></param>
        /// <param name="encodingName">encoding name, default is "utf-8"</param>
        /// <returns></returns>
        public static string FromString(string str, string encodingName = "utf-8")
        {
            return BitConverter.ToString(Encoding.GetEncoding(encodingName).GetBytes(str)).Replace("-", " ");
        }
    }
}
