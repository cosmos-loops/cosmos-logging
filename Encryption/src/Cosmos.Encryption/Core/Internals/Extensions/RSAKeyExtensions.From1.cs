using System;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;

namespace Cosmos.Encryption.Core.Internals.Extensions
{
    // ReSharper disable once InconsistentNaming
    internal static partial class RSAKeyExtensions
    {
        public static void FromPkcs1PublicString(this RSA rsa, string publicKey, out RSAParameters parameters)
        {
            publicKey = RSAPemFormatHelper.PublicKeyFormat(publicKey);
            var pr = new PemReader(new StringReader(publicKey));
            if (!(pr.ReadObject() is RsaKeyParameters rsaKey))
            {
                throw new Exception("Public key format is incorrect");
            }

            parameters = new RSAParameters
            {
                Modulus = rsaKey.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKey.Exponent.ToByteArrayUnsigned()
            };

            rsa.ImportParameters(parameters);
        }

        public static void FromPkcs1PrivateString(this RSA rsa, string privateKey, out RSAParameters parameters)
        {
            privateKey = RSAPemFormatHelper.Pkcs1PrivateKeyFormat(privateKey);
            var pr = new PemReader(new StringReader(privateKey));
            if (!(pr.ReadObject() is AsymmetricCipherKeyPair asymmetricCipherKeyPair))
            {
                throw new Exception("Private key format is incorrect");
            }

            var rsaPrivateCrtKeyParameters = (RsaPrivateCrtKeyParameters) PrivateKeyFactory.CreateKey(
                PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricCipherKeyPair.Private));

            parameters = new RSAParameters
            {
                Modulus = rsaPrivateCrtKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaPrivateCrtKeyParameters.PublicExponent.ToByteArrayUnsigned(),
                P = rsaPrivateCrtKeyParameters.P.ToByteArrayUnsigned(),
                Q = rsaPrivateCrtKeyParameters.Q.ToByteArrayUnsigned(),
                DP = rsaPrivateCrtKeyParameters.DP.ToByteArrayUnsigned(),
                DQ = rsaPrivateCrtKeyParameters.DQ.ToByteArrayUnsigned(),
                InverseQ = rsaPrivateCrtKeyParameters.QInv.ToByteArrayUnsigned(),
                D = rsaPrivateCrtKeyParameters.Exponent.ToByteArrayUnsigned()
            };

            rsa.ImportParameters(parameters);
        }
    }
}