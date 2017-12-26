using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Hash/SHA1 hashing provider.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/SHAHashingBase/SHA1.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class SHA1HashingProvider : SHAHashingBase {
        private SHA1HashingProvider() { }

        /// <summary>
        /// SHA1 encrypt mehtod
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Signature(string data, Encoding encoding = null)
            => Encrypt<SHA1CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// Verify 
        /// </summary>
        /// <param name="comparison"></param>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool Verify(string comparison, string data, Encoding encoding = null)
            => comparison == Signature(data, encoding);
    }
}