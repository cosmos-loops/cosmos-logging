using System.Collections.Generic;
using Cosmos.Encryption.Core.Internals.Extensions;

/*
 * Reference to:
 *     https://github.com/stulzq/RSAUtil/blob/master/XC.RSAUtil/RsaPemFormatHelper.cs
 *     Author:Zhiqiang Li
 */

namespace Cosmos.Encryption.Core
{
    public static class RSAPemFormatHelper
    {
        /// <summary>
        /// Format Pkcs1 format private key
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs1PrivateKeyFormat(string str)
        {
            if (str.StartsWith(RSAConstants.RSA_PRIVATE_KEY_START))
            {
                return str;
            }

            var res = new List<string> {RSAConstants.RSA_PRIVATE_KEY_START};

            var pos = 0;

            while (pos < str.Length)
            {
                var count = str.Length - pos < 64 ? str.Length - pos : 64;
                res.Add(str.Substring(pos, count));
                pos += count;
            }

            res.Add(RSAConstants.RSA_PRIVATE_KEY_END);
            var resStr = string.Join(RSAConstants.R_N, res);
            return resStr;
        }

        /// <summary>
        /// Remove the Pkcs1 format private key format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs1PrivateKeyFormatRemove(string str)
        {
            if (!str.StartsWith(RSAConstants.RSA_PRIVATE_KEY_START))
            {
                return str;
            }

            return str
                .ReplaceToEmpty(RSAConstants.RSA_PRIVATE_KEY_START)
                .ReplaceToEmpty(RSAConstants.RSA_PRIVATE_KEY_END)
                .ReplaceToEmpty(RSAConstants.R_N);
        }

        /// <summary>
        /// Format Pkcs8 format private key
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs8PrivateKeyFormat(string str)
        {
            if (str.StartsWith(RSAConstants.PRIVATE_KEY_START))
            {
                return str;
            }

            var res = new List<string> {RSAConstants.PRIVATE_KEY_START};

            var pos = 0;

            while (pos < str.Length)
            {
                var count = str.Length - pos < 64 ? str.Length - pos : 64;
                res.Add(str.Substring(pos, count));
                pos += count;
            }

            res.Add(RSAConstants.PRIVATE_KEY_END);
            var resStr = string.Join(RSAConstants.R_N, res);
            return resStr;
        }

        /// <summary>
        /// Remove the Pkcs8 format private key format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs8PrivateKeyFormatRemove(string str)
        {
            if (!str.StartsWith(RSAConstants.PRIVATE_KEY_START))
            {
                return str;
            }

            return str
                .ReplaceToEmpty(RSAConstants.PRIVATE_KEY_START)
                .ReplaceToEmpty(RSAConstants.PRIVATE_KEY_END)
                .ReplaceToEmpty(RSAConstants.R_N);
        }

        /// <summary>
        /// Format public key
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PublicKeyFormat(string str)
        {
            if (str.StartsWith(RSAConstants.PUBLIC_KEY_START))
            {
                return str;
            }

            var res = new List<string> {RSAConstants.PUBLIC_KEY_START};
            var pos = 0;

            while (pos < str.Length)
            {
                var count = str.Length - pos < 64 ? str.Length - pos : 64;
                res.Add(str.Substring(pos, count));
                pos += count;
            }

            res.Add(RSAConstants.PUBLIC_KEY_END);
            var resStr = string.Join(RSAConstants.R_N, res);
            return resStr;
        }

        /// <summary>
        /// Public key format removed
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PublicKeyFormatRemove(string str)
        {
            if (!str.StartsWith(RSAConstants.PUBLIC_KEY_START))
            {
                return str;
            }

            return str
                .ReplaceToEmpty(RSAConstants.PUBLIC_KEY_START)
                .ReplaceToEmpty(RSAConstants.PUBLIC_KEY_END)
                .ReplaceToEmpty(RSAConstants.R_N);
        }
    }
}