using System;
using System.Linq;
using System.Text;
using Cosmos.Encryption.Abstractions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption
{
    /// <summary>
    /// Symmetric/RC4 encryption.
    /// Reference: https://bitlush.com/blog/rc4-encryption-in-c-sharp
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class RC4EncryptionProvider : ISymmetricEncyption
    {
        private RC4EncryptionProvider() { }

        public static string Encrypt(string data, string key, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return Convert.ToBase64String(EncryptCore(encoding.GetBytes(data), encoding.GetBytes(key)));
        }

        public static string Encrypt(byte[] data, string key, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return Convert.ToBase64String(EncryptCore(data, encoding.GetBytes(key)));
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            return EncryptCore(data, key);
        }

        public static string Decrypt(string data, string key, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return encoding.GetString(EncryptCore(Convert.FromBase64String(data), encoding.GetBytes(key)));
        }

        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            return EncryptCore(data, key);
        }

        private static byte[] EncryptCore(byte[] data, byte[] key)
        {
            var s = Initalize(key);
            int i = 0, j = 0;

            return data.Select(b =>
            {
                i = (i + 1) & 255;
                j = (j + s[i]) & 255;
                Swap(s, i, j);
                return (byte) (b ^ s[(s[i] + s[j]) & 255]);
            }).ToArray();
        }

        private static byte[] Initalize(byte[] key)
        {
            var s = Enumerable.Range(0, 256).Select(i => (byte) i).ToArray();
            for (int i = 0, j = 0; i < 256; i++)
            {
                j = (j + key[i % key.Length] + s[i]) & 255;
                Swap(s, i, j);
            }

            return s;
        }

        private static void Swap(byte[] s, int i, int j)
        {
            var b = s[i];
            s[i] = s[j];
            s[j] = b;
        }
    }
}