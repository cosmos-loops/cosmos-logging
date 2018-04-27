using System;
using System.Data;
using Cosmos.Data.Abstractions;

namespace Cosmos.Data.EntityFrameworkCore {
    public class EfCoreUnitOfWork : IUnitOfWork {
        private IEfCoreDbSession _session { get; set; }
        private readonly IDbTransaction _transaction;
        private readonly bool _originAutoTransactionsEnabled;
        private bool HasCommited { get; set; }

        public EfCoreUnitOfWork(IEfCoreDbSession session, bool originAutoTransactionsEnabled) {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
            _originAutoTransactionsEnabled = originAutoTransactionsEnabled;
            HasCommited = false;
        }

        public EfCoreUnitOfWork(IEfCoreDbSession session, IsolationLevel li, bool originAutoTransactionsEnabled) {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _transaction = _session.BeginTransaction(li);
            _originAutoTransactionsEnabled = originAutoTransactionsEnabled;
            HasCommited = false;
        }

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

        protected void Dispose(bool bisposing) {

            if (_disposd) {
                return;
            }

            if (bisposing) {

                if (!HasCommited) {
                    Commit();
                    HasCommited = true;
                }

                _session.AutoTransactionsEnabled = _originAutoTransactionsEnabled;
            }

            _disposd = true;
        }

        #endregion

    }
}