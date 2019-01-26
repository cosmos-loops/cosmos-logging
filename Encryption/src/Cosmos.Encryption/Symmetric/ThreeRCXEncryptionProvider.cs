/*
 * Reference to:
 *     https://github.com/toolgood/RCX/blob/master/ToolGood.RcxTest/ToolGood.RcxCrypto/RCX.cs
 *     Author: ToolGood
 *     GitHub: https://github.com/toolgood
 */


using System;
using System.Text;
using Cosmos.Encryption.Abstractions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption
{
    public sealed class ThreeRCXEncryptionProvider : ISymmetricEncyption
    {
        private ThreeRCXEncryptionProvider() { }

        public static string Encrypt(string data, string key, Encoding encoding = null, RCXOrder order = RCXOrder.DESC)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var dataBytes = encoding.GetBytes(data);
            var keyBytes = encoding.GetBytes(key);
            return Convert.ToBase64String(EncryptCore(dataBytes, keyBytes, order));
        }

        public static string Encrypt(byte[] data, string key, Encoding encoding = null, RCXOrder order = RCXOrder.DESC)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var keyBytes = encoding.GetBytes(key);
            return Convert.ToBase64String(EncryptCore(data, keyBytes, order));
        }

        public static byte[] Encrypt(byte[] data, byte[] key, RCXOrder order = RCXOrder.DESC)
        {
            return EncryptCore(data, key, order);
        }

        public static string Decrypt(string data, string key, Encoding encoding = null, RCXOrder order = RCXOrder.DESC)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var dataBytes = Convert.FromBase64String(data);
            var keyBytes = encoding.GetBytes(key);
            return encoding.GetString(EncryptCore(dataBytes, keyBytes, order));
        }

        public static byte[] Decrypt(byte[] data, byte[] key, RCXOrder order = RCXOrder.DESC)
        {
            return EncryptCore(data, key, order);
        }

        private static byte[] EncryptCore(byte[] dataBytes, byte[] keyBytes, RCXOrder order = RCXOrder.DESC)
        {
            var first = RCXEncryptionProvider.Encrypt(dataBytes, keyBytes, order);
            var second = RCXEncryptionProvider.Encrypt(first, keyBytes, order);
            return RCXEncryptionProvider.Encrypt(second, keyBytes, order);
        }
    }
}