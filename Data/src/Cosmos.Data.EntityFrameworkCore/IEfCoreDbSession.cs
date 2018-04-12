using System;
using System.Data;
using Cosmos.Data.Abstractions;

namespace Cosmos.Data.EntityFrameworkCore {
    public interface IEfCoreDbSession : IDbSession, IDisposable {
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction(IsolationLevel il);
        void Commit();
        void Commit(Action callback);
        void Rollback();
        bool AutoTransactionsEnabled { get; set; }
    }
}