using System.IO;
using Cosmos.Encryption.Abstractions;

namespace Cosmos.Encryption.Core {
    // ReSharper disable once InconsistentNaming
    public abstract class CRCCheckingBase<T1, T2>
        where T1 : struct
        where T2 : struct {
        protected static T1 Compute<TCRC>(byte[] buf, int offset = 0, int count = -1)
            where TCRC : class, ICRC<TCRC, T1, T2>, new() {
            var crc = new TCRC();
            crc.Update(buf, offset, count);
            return crc.Value;
        }

        protected static T1 Compute<TCRC>(Stream stream, int count = -1)
            where TCRC : class, ICRC<TCRC, T1, T2>, new() {
            var crc = new TCRC();
            crc.Update(stream, count);
            return crc.Value;
        }

        protected static T1 Compute<TCRC>(Stream stream, long position = -1, int count = -1)
            where TCRC : class, ICRC<TCRC, T1, T2>, new() {
            if (position >= 0) {
                if (count > 0) count = -count;
                count += (int) (stream.Position - position);
                if (count == 0) return default(T1);
                stream.Position = position;
            }

            var crc = new TCRC();
            crc.Update(stream, count);
            return crc.Value;
        }
    }
}