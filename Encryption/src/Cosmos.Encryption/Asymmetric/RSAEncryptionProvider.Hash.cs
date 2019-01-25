using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption
{
    /// <summary>
    /// Asymmetric/RSA encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Asymmetric/RSA.cs
    /// Reference: myloveCc
    ///     https://github.com/myloveCc/NETCore.Encrypt/blob/master/src/NETCore.Encrypt/EncryptProvider.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class RSAEncryptionProvider
    {
        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hash"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool GetHash(string data, ref byte[] hash, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            hash = HashStringFunc()(data)(encoding);
            return true;
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hash"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool GetHash(string data, ref string hash, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            hash = Convert.ToBase64String(HashStringFunc()(data)(encoding));
            return true;
        }

        private static Func<string, Func<Encoding, byte[]>> HashStringFunc() =>
            data => encoding => HashAlgorithm.Create("MD5")?.ComputeHash(encoding.GetBytes(data));

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool GetHash(FileStream fs, ref byte[] hash)
        {
            hash = HashFileFunc()(fs);
            return true;
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool GetHash(FileStream fs, ref string hash)
        {
            hash = Convert.ToBase64String(HashFileFunc()(fs));
            return true;
        }

        private static Func<FileStream, byte[]> HashFileFunc() => fs =>
        {
            var ret = HashAlgorithm.Create("MD5")?.ComputeHash(fs);
            fs.Close();
            return ret;
        };
    }
}