using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Hash/HMACMD5 hashing provider.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/HMAC/HMACSHA384.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class HMACSHA384HashingProvider : HMACHashingBase {
        private HMACSHA384HashingProvider() { }

        /// <summary>
        /// HMACSHA384 encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, string key, Encoding encoding = null) =>
            Encrypt<HMACSHA384>(data, key, encoding);
    }
}