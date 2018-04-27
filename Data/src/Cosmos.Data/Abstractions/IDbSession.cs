using System.Data;

namespace Cosmos.Data.Abstractions {
    public interface IDbSession {
        IDbConnection Connection { get; }
    }
}