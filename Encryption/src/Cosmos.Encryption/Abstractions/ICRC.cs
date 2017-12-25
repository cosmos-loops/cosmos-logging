using System.IO;

namespace Cosmos.Encryption.Abstractions {
    public interface ICRC<TCRC, T1, T2>
        where TCRC : class, ICRC<TCRC, T1, T2>, new()
        where T1 : struct
        where T2 : struct {
        T1 Value { get; set; }
        TCRC Reset();
        TCRC Update(T2 value);
        TCRC Update(byte[] buffer, int offset = 0, int count = 1);
        TCRC Update(Stream stream, long count = -1);
    }
}