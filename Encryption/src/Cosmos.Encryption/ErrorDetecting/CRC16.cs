using System;
using System.IO;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// CRC16
    /// Author: X-New-Life
    ///     https://github.com/NewLifeX/X/blob/master/NewLife.Core/Security/Crc16.cs
    /// </summary>
    public sealed class CRC16 : ICRC<CRC16, ushort, short> {
        public ushort Value { get; set; } = CRC16CheckingProvider.Seed;
        private ushort[] CRCTable { get; } = CRCTableGenerator.GenerationCRC16Table();

        public CRC16 Reset() {
            Value = CRC16CheckingProvider.Seed;
            return this;
        }

        public CRC16 Update(short value) {
            Value = (ushort) ((Value << 8) ^ CRCTable[(Value >> 8) ^ value]);
            return this;
        }

        public CRC16 Update(byte[] buffer, int offset = 0, int count = -1) {
            if (buffer == null) {
                throw new ArgumentNullException("buffer");
            }

            if (count <= 0) count = buffer.Length;
            if (offset < 0 || offset + count > buffer.Length) {
                throw new ArgumentOutOfRangeException("offset");
            }

            Value ^= Value;
            for (var i = 0; i < count; i++) {
                Value = (ushort) ((Value << 8) ^ CRCTable[(Value >> 8 ^ buffer[offset + i]) & 0xFF]);
            }

            return this;
        }

        public CRC16 Update(Stream stream, long count = -1) {
            if (stream == null) {
                throw new ArgumentNullException("stream");
            }

            if (count <= 0) count = long.MaxValue;

            while (--count >= 0) {
                var b = stream.ReadByte();
                if (b == -1) break;

                Value ^= (byte) b;
                for (var i = 0; i < 8; i++) {
                    if ((Value & 0x0001) != 0)
                        Value = (ushort) ((Value >> 1) ^ 0xa001);
                    else
                        Value = (ushort) (Value >> 1);
                }
            }

            return this;
        }
    }
}