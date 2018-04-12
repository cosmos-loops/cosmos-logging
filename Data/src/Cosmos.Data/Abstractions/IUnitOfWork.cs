using System;
using System.Data;

namespace Cosmos.Data.Abstractions {
    public interface IUnitOfWork : IDisposable {
        void Commit();
        void Rollback();
        IDbTransaction ExporTransaction();
    }
}