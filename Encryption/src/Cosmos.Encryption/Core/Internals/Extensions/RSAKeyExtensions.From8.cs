using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace Cosmos.Encryption.Core.Internals.Extensions
{
    // ReSharper disable once InconsistentNaming
    internal static partial class RSAKeyExtensions
    {
        public static void FromPkcs8PublicString(this RSA rsa, string publicKey, out RSAParameters parameters)
        {
            publicKey = RSAPemFormatHelper.PublicKeyFormatRemove(publicKey);
            var publicKeyParam = (RsaKeyParameters) PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));

            parameters = new RSAParameters
            {
                Modulus = publicKeyParam.Modulus.ToByteArrayUnsigned(),
                Exponent = publicKeyParam.Exponent.ToByteArrayUnsigned()
            };

            rsa.ImportParameters(parameters);
        }

        public static void FromPkcs8PrivateString(this RSA rsa, string privateKey, out RSAParameters parameters)
        {
            privateKey = RSAPemFormatHelper.Pkcs8PrivateKeyFormatRemove(privateKey);
            var privateKeyParam = (RsaPrivateCrtKeyParameters) PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));

            parameters = new RSAParameters
            {
                Modulus = privateKeyParam.Modulus.ToByteArrayUnsigned(),
                Exponent = privateKeyParam.PublicExponent.ToByteArrayUnsigned(),
                P = privateKeyParam.P.ToByteArrayUnsigned(),
                Q = privateKeyParam.Q.ToByteArrayUnsigned(),
                DP = privateKeyParam.DP.ToByteArrayUnsigned(),
                DQ = privateKeyParam.DQ.ToByteArrayUnsigned(),
                InverseQ = privateKeyParam.QInv.ToByteArrayUnsigned(),
                D = privateKeyParam.Exponent.ToByteArrayUnsigned()
            };

            rsa.ImportParameters(parameters);
        }
    }
}