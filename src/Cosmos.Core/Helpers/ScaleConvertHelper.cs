using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Scale convert helper
    /// </summary>
    public static class ScaleConvertHelper
    {
        /// <summary>
        /// Bytes converter
        /// </summary>
        public static class BytesConverter
        {
            /// <summary>
            /// Convert from bytes to ascii
            /// </summary>
            /// <example>in: new byte[] {65, 66, 67}; out: ABC</example>
            /// <param name="bytes"></param>
            /// <returns></returns>
            public static string ToAscii(byte[] bytes)
            {
                return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            }

            /// <summary>
            /// Convert from byte to binary
            /// </summary>
            /// <example>in: (byte)128; out: 10000000</example>
            /// <param name="byte"></param>
            /// <returns></returns>
            public static string ToBinary(byte @byte)
            {
                return DecimalismConverter.ToBinary(@byte);
            }

            /// <summary>
            /// Convert high address byte and low address byte to decimalsim
            /// </summary>
            /// <example>in: (byte)65, (byte)66; out: 16706</example>
            /// <example>in: (byte)66, (byte)65; out: 16961</example>
            /// <param name="h">high address byte</param>
            /// <param name="l">low address byte</param>
            /// <returns></returns>
            public static int ToDecimalism(byte h, byte l)
            {
                return h << 8 | l;
            }

            /// <summary>
            /// Convert high address byte and low address byte to decimalism
            /// </summary>
            /// <example>in: (byte)255, (byte)66; out: 65346</example>
            /// <example>in: (byte)66, (byte)255; out: -190</example>
            /// <param name="h">high address byte</param>
            /// <param name="l">low address byte</param>
            /// <param name="isRadix"></param>
            /// <returns></returns>
            public static int ToDecimalism(byte h, byte l, bool isRadix)
            {
                var v = (ushort)(h << 0 | l);

                if (isRadix && h > 127)
                {
                    v = (ushort)~v;
                    v = (ushort)(v + 1);
                    return -1 * v;
                }

                return v;
            }

            /// <summary>
            /// Convert from byte to hexadecimal
            /// </summary>
            /// <example>in: (byte)128; out: 80</example>
            /// <param name="byte"></param>
            /// <returns></returns>
            public static string ToHexadecimal(byte @byte)
            {
                return @byte.ToString("X2");
            }

            /// <summary>
            /// Convert from bytes to hexadecimal
            /// </summary>
            /// <example>in: new byte[] {65, 66, 67}; out: 414243</example>
            /// <param name="bytes"></param>
            /// <returns></returns>
            public static string ToHexadecimal(byte[] bytes)
            {
                var ret = "";
                if (bytes != null)
                    ret = bytes.Aggregate(ret, (current, t) => $"{current}{t:X2}");
                return ret;
            }

            /// <summary>
            /// Convert from high address byte and low address byte to hexadecimal
            /// </summary>
            /// <example>in: (byte)65, (byte)66; out: 4142</example>
            /// <example>in: (byte)66, (byte)65; out: 4241</example>
            /// <param name="h">high address byte</param>
            /// <param name="l">low address byte</param>
            /// <returns></returns>
            public static string ToHexadecimal(byte h, byte l)
            {
                return $"{BytesConverter.ToHexadecimal(h)}{BytesConverter.ToHexadecimal(l)}";
            }


        }
        /// <summary>
        /// Binary converter
        /// </summary>
        public static class BinaryConverter
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
                return DecimalismConverter.ToHexadecimal(BinaryConverter.ToDecimalism(bin));
            }
        }

        /// <summary>
        /// Decimalism converter
        /// </summary>
        public static class DecimalismConverter
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
                var hex = DecimalismConverter.ToHexadecimal(dec);
                if (hex.Length > formatLength)
                    return hex;

                return hex.PadLeft(formatLength, '0');
            }
        }

        /// <summary>
        /// Hexadecimal converter
        /// </summary>
        public static class HexadecimalConverter
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
                return DecimalismConverter.ToBinary(HexadecimalConverter.ToDecimalism(hex));
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
                    return "";
                var bytes = new byte[hex.Length / 2];
                for (var i = 0; i < hex.Length; i += 2)
                    if (!byte.TryParse(hex.Substring(i, 2), NumberStyles.HexNumber, null, out bytes[i / 2]))
                        bytes[i / 2] = 0;
                return Encoding.GetEncoding(encodingName).GetString(bytes);
            }
        }

        /// <summary>
        /// String converter
        /// </summary>
        public static class StringConverter
        {
            /// <summary>
            /// Convert from string to hexadecimal
            /// </summary>
            /// <example>in: A; out: 1000001</example>
            /// <param name="str"></param>
            /// <param name="encodingName">encoding name, default is "utf-8"</param>
            /// <returns></returns>
            public static string ToHexadecimal(string str, string encodingName = "utf-8")
            {
                return BitConverter.ToString(Encoding.GetEncoding(encodingName).GetBytes(str)).Replace("-", " ");
            }
        }
    }
}