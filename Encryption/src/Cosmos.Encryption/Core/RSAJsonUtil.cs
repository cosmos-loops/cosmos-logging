using System;
using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core.Internals.Extensions;

namespace Cosmos.Encryption.Core
{
    // ReSharper disable once InconsistentNaming
    public class RSAJsonUtil : RSABase
    {
        /// <summary>
        /// RSA encryption
        /// SHA256 hash algorithm to use the key length of at least 2048
        /// </summary>
        /// <param name="keySize">Key length in bits:</param>
        /// <param name="privateKey">private Key</param>
        /// <param name="publicKey">public Key</param>
        public RSAJsonUtil(string publicKey, string privateKey = null, int keySize = 2048)
            : this(Encoding.UTF8, publicKey, privateKey, keySize) { }

        /// <summary>
        /// RSA encryption
        /// SHA256 hash algorithm to use the key length of at least 2048
        /// </summary>
        /// <param name="dataEncoding">Data coding</param>
        /// <param name="keySize">Key length in bits:</param>
        /// <param name="privateKey">private Key</param>
        /// <param name="publicKey">public Key</param>
        public RSAJsonUtil(Encoding dataEncoding, string publicKey, string privateKey = null, int keySize = 2048)
        {
            if (string.IsNullOrEmpty(privateKey) && string.IsNullOrEmpty(publicKey))
            {
                throw new ArgumentException("Public and private keys must not be empty at the same time");
            }

            if (!string.IsNullOrEmpty(privateKey))
            {
                PrivateRsa = RSA.Create();
                PrivateRsa.KeySize = keySize;
                PrivateRsa.FromJsonString(privateKey);
            }

            if (!string.IsNullOrEmpty(publicKey))
            {
                PublicRsa = RSA.Create();
                PublicRsa.KeySize = keySize;
                PublicRsa.FromJsonString(publicKey);
            }

            DataEncoding = dataEncoding ?? Encoding.UTF8;
        }
    }
}