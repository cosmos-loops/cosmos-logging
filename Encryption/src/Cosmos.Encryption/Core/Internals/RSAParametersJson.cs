namespace Cosmos.Encryption.Core.Internals {
    /// <summary>
    /// Author:myloveCc
    ///     https://github.com/myloveCc/NETCore.Encrypt/blob/master/src/NETCore.Encrypt/Internal/RSAParametersJson.cs
    /// </summary>
    internal class RSAParametersJson {
        //Public key Modulus
        public string Modulus { get; set; }

        //Public key Exponent
        public string Exponent { get; set; }

        public string P { get; set; }

        public string Q { get; set; }

        public string DP { get; set; }

        public string DQ { get; set; }

        public string InverseQ { get; set; }

        public string D { get; set; }
    }
}