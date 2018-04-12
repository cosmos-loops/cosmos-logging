using System;
using System.Data;
using Cosmos.Data.Abstractions;

namespace Cosmos.Data.Dapper {
    public interface IDapperDbSession : IDbSession, IDisposable {
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction(IsolationLevel il);
        void Commit();
        void Commit(Action callback);
        void Rollback();

        IDapperDbSessionQueryProxy OperationProxy { get; }
    }
}