// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    // ReSharper disable once InconsistentNaming
    public class AESKey {
        /// <summary>
        /// ase key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// ase IV
        /// </summary>
        public string IV { get; set; }
        
        /// <summary>
        /// key size
        /// </summary>
        public AESKeySizeTypes Size { get; set; }
    }
}