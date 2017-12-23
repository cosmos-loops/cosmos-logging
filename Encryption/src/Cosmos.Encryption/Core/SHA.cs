using System;
using System.Security.Cryptography;
using System.Text;

namespace Cosmos.Encryption.Core {
    /// <summary>
    /// Abstrace SHA encryption.
    /// Author: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/SHA/SHA.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public abstract class SHA {
        /// <summary>
        /// SHA encryption algoritm core.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected static string Encrypt<T>(string data, Encoding encoding = null) where T : HashAlgorithm, new() {
            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            using (HashAlgorithm hash = new T()) {
                var bytes = hash.ComputeHash(encoding.GetBytes(data));

                var sbStr = new StringBuilder();
                foreach (var b in bytes) {
                    sbStr.Append(b.ToString("X2"));
                }

                return sbStr.ToString();
            }
        }
    }
}