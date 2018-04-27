using System;
using System.Data;
using Cosmos.Data.Abstractions;

namespace Cosmos.Data.Dapper {
    public class DapperUnitOfWork : IUnitOfWork {
        private IDapperDbSession _session { get; set; }
        private readonly IDbTransaction _transaction;
        private bool HasCommited { get; set; }

        public DapperUnitOfWork(IDapperDbSession session) {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
            HasCommited = false;
        }

        public DapperUnitOfWork(IDapperDbSession session, IsolationLevel li) {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _transaction = _session.BeginTransaction(li);
            HasCommited = false;
        }

        #region operation proxy

        public IDapperDbSessionQueryProxy DbOperation => _session.OperationProxy;

        #endregion

        #region transaction

        public void Commit() => _session.Commit(() => HasCommited = true);

        public void Rollback() => _session.Rollback();

        public IDbTransaction ExporTransaction() => _transaction;

        #endregion

        #region dispose

        private bool _disposd = false;

        public void Dispose() {
            Dispose(true);
        }

        protected void Dispose(bool disposing) {
            if (_disposd) {
                return;
            }

            if (disposing && !HasCommited) {
                Commit();
                HasCommited = true;
            }

            _disposd = true;
        }

        #endregion

    }
}