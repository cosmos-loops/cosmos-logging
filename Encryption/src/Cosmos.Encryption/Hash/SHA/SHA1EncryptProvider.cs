using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Hash/SHA1 encryption.
    /// Author: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/SHA/SHA1.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class SHA1EncryptProvicer : SHA {
        private SHA1EncryptProvicer() { }

        /// <summary>
        /// SHA1 encrypt mehtod
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, Encoding encoding = null) => Encrypt<SHA1CryptoServiceProvider>(data, encoding);
    }
}