using System;
using System.IO;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    // ReSharper disable once InconsistentNaming
    public sealed class CRC32 : ICRC<CRC32, uint, int> {
        public uint Value { get; set; } = CRC32CheckingProvider.Seed;
        private uint[] CRCTable { get; } = CRCTableGenerator.GenerationCRC32Table();

        public CRC32 Reset() {
            Value = CRC32CheckingProvider.Seed;
            return this;
        }

        public CRC32 Update(int value) {
            Value = CRCTable[(Value ^ value) & 0xFF] ^ (Value >> 8);
            return this;
        }

        public CRC32 Update(byte[] buffer, int offset = 0, int count = -1) {
            if (buffer == null) {
                throw new ArgumentNullException("buffer");
            }

            if (count <= 0) {
                count = buffer.Length;
            }

            if (offset < 0 || offset + count > buffer.Length) {
                throw new ArgumentOutOfRangeException("offset");
            }

            while (--count >= 0) {
                Value = CRCTable[(Value ^ buffer[offset++]) & 0xFF] ^ (Value >> 8);
            }

            return this;
        }

        public CRC32 Update(Stream stream, long count = -1) {
            if (stream == null) {
                throw new ArgumentNullException(nameof(stream));
            }

            if (count <= 0) {
                count = long.MaxValue;
            }

            while (--count >= 0) {
                var b = stream.ReadByte();
                if (b == -1) break;

                Value = CRCTable[(Value ^ b) & 0xFF] ^ (Value >> 8);
            }

            return this;
        }
    }
}