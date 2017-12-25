using System.IO;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// CRC16 checking provider
    /// Author: X-New-Life
    ///     https://github.com/NewLifeX/X/blob/master/NewLife.Core/Security/Crc16.cs
    // ReSharper disable once InconsistentNaming
    public sealed class CRC16CheckingProvider : CRCCheckingBase<ushort, short> {
        public const ushort Seed = 0xFFFF;
        private CRC16CheckingProvider() { }

        public static ushort Compute(byte[] buf, int offset = 0, int count = -1) {
            return Compute<CRC16>(buf, offset, count);
        }

        public static ushort Compute(Stream stream, int count = -1) {
            return Compute<CRC16>(stream, count);
        }

        public static ushort Compute(Stream stream, long position = -1, int count = -1) {
            return Compute<CRC16>(stream, position, count);
        }
    }
}