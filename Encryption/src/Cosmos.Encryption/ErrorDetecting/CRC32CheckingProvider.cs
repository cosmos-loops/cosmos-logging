using System.IO;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    // ReSharper disable once InconsistentNaming
    public sealed class CRC32CheckingProvider : CRCCheckingBase<uint, int> {
        public const uint Seed = 0xFFFFFFFF;
        private CRC32CheckingProvider() { }

        public static uint Compute(byte[] buf, int offset = 0, int count = -1) {
            return Compute<CRC32>(buf, offset, count);
        }

        public static uint Compute(Stream stream, int count = -1) {
            return Compute<CRC32>(stream, count);
        }

        public static uint Compute(Stream stream, long position = -1, int count = -1) {
            return Compute<CRC32>(stream, position, count);
        }
    }
}