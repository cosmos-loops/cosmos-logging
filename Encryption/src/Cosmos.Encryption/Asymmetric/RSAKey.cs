// ReSharper disable once CheckNamespace

namespace Cosmos.Encryption {
    /// <summary>
    /// RSA Key
    /// Reference: myloveCc
    ///     https://github.com/myloveCc/NETCore.Encrypt/blob/master/src/NETCore.Encrypt/Internal/RSAKey.cs
    /// </summary>
    public class RSAKey {
        /// <summary>
        /// Rsa public key
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Rsa private key
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Rsa public key Exponent
        /// </summary>
        public string Exponent { get; set; }

        /// <summary>
        /// Rsa public key Modulus
        /// </summary>
        public string Modulus { get; set; }
    }
}