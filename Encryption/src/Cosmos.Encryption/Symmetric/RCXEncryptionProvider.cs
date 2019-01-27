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
    /// <summary>
    /// Symmetric/RCX encryption.
    /// Reference: https://github.com/toolgood/RCX/
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class RCXEncryptionProvider : ISymmetricEncyption
    {
        private const int KEY_LENGTH = 256;

        private RCXEncryptionProvider() { }

        public static string Encrypt(string data, string key, Encoding encoding = null, RCXOrder order = RCXOrder.ASC)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return Convert.ToBase64String(EncryptCore(encoding.GetBytes(data), encoding.GetBytes(key), order));
        }

        public static string Encrypt(byte[] data, string key, Encoding encoding = null, RCXOrder order = RCXOrder.ASC)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return Convert.ToBase64String(EncryptCore(data, encoding.GetBytes(key), order));
        }

        public static byte[] Encrypt(byte[] data, byte[] key, RCXOrder order = RCXOrder.ASC)
        {
            return EncryptCore(data, key, order);
        }

        public static string Decrypt(string data, string key, Encoding encoding = null, RCXOrder order = RCXOrder.ASC)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return encoding.GetString(EncryptCore(Convert.FromBase64String(data), encoding.GetBytes(key), order));
        }

        public static byte[] Decrypt(byte[] data, byte[] key, RCXOrder order = RCXOrder.ASC)
        {
            return EncryptCore(data, key, order);
        }

        private static byte[] EncryptCore(byte[] data, byte[] pass, RCXOrder order)
        {
            byte[] mBox = GetKey(pass, KEY_LENGTH);
            byte[] output = new byte[data.Length];
            int i = 0, j = 0;

            if (order == RCXOrder.ASC)
            {
                for (int offset = 0; offset < data.Length; offset++)
                {
                    i = (++i) & 0xFF;
                    j = (j + mBox[i]) & 0xFF;

                    byte a = data[offset];
                    byte c = (byte) (a ^ mBox[(mBox[i] + mBox[j]) & 0xFF]);
                    output[offset] = c;

                    byte temp2 = mBox[c];
                    mBox[c] = mBox[a];
                    mBox[a] = temp2;
                    j = (j + a + c);
                }
            }
            else
            {
                for (int offset = data.Length - 1; offset >= 0; offset--)
                {
                    i = (++i) & 0xFF;
                    j = (j + mBox[i]) & 0xFF;

                    byte a = data[offset];
                    byte c = (byte) (a ^ mBox[(mBox[i] + mBox[j]) & 0xFF]);
                    output[offset] = c;

                    byte temp2 = mBox[c];
                    mBox[c] = mBox[a];
                    mBox[a] = temp2;
                    j = (j + a + c);
                }
            }

            return output;
        }

        private static byte[] GetKey(byte[] pass, int kLen)
        {
            byte[] mBox = new byte[kLen];
            for (Int64 i = 0; i < kLen; i++)
            {
                mBox[i] = (byte) i;
            }

            Int64 j = 0;
            for (Int64 i = 0; i < kLen; i++)
            {
                j = (j + mBox[i] + pass[i % pass.Length]) % kLen;
                byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
            }

            return mBox;
        }
    }
}