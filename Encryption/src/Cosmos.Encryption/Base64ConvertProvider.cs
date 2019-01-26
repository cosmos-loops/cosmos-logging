using System;
using System.Text;

/*
 * Base64UrlString Reference to:
 *     https://github.com/toolgood/RCX/blob/master/ToolGood.RcxTest/ToolGood.RcxTest/Base64.cs
 *     Author: ToolGood
 */

namespace Cosmos.Encryption
{
    public static class Base64ConvertProvider
    {
        private const string BASE64 = "===========================================+=+=/0123456789=======ABCDEFGHIJKLMNOPQRSTUVWXYZ====/=abcdefghijklmnopqrstuvwxyz=====";

        /// <summary>
        /// Convert from bytes to base64 string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64 encode.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string ToBase64String(string data, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return ToBase64String(encoding.GetBytes(data));
        }

        /// <summary>
        /// Base64 decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The decrypted string.</returns>
        public static string FromBase64String(string data, Encoding encoding = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return encoding.GetString(Convert.FromBase64String(data));
        }

        /// <summary>
        /// Convert from string to base64url string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64UrlString(byte[] bytes)
        {
            var result = new StringBuilder(Convert.ToBase64String(bytes).TrimEnd('='));
            result.Replace('+', '-');
            result.Replace('/', '_');
            return result.ToString();
        }

        /// <summary>
        /// Convert from string to base64url string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64UrlString(string str, Encoding encoding)
        {
            return ToBase64UrlString(encoding.GetBytes(str));
        }

        /// <summary>
        /// Convert from base64url string to string
        /// </summary>
        /// <param name="base64UrlString"></param>
        public static byte[] FromBase64UrlString(string base64UrlString)
        {
            var sb = new StringBuilder();
            foreach (var c in base64UrlString)
            {
                if ((int) c >= 128) continue;
                var k = BASE64[c];
                if (k == '=') continue;
                sb.Append(k);
            }

            var len = sb.Length;
            int padChars = (len % 4) == 0 ? 0 : (4 - (len % 4));
            if (padChars > 0) sb.Append(string.Empty.PadRight(padChars, '='));
            return Convert.FromBase64String(sb.ToString());
        }

        /// <summary>
        /// Convert from base64url string to string
        /// </summary>
        /// <param name="base64UrlString"></param>
        /// <param name="encoding"></param>
        public static string FromBase64UrlString(string base64UrlString, Encoding encoding)
        {
            return encoding.GetString(FromBase64UrlString(base64UrlString));
        }
    }
}