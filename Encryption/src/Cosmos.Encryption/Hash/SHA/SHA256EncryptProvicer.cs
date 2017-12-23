using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Hash/SHA256 encryption.
    /// Author: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/SHA/SHA256.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class SHA256EncryptProvicer : SHA {
        private SHA256EncryptProvicer() { }

        /// <summary>
        /// SHA256 encrypt mehtod
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, Encoding encoding = null) => Encrypt<SHA256CryptoServiceProvider>(data, encoding);
    }
}