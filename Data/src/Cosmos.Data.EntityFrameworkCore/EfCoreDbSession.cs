using System;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cosmos.Data.EntityFrameworkCore {
    public abstract class EfCoreDbSession<TDbSession> : DbContext, IEfCoreDbSession
        where TDbSession : DbContext {

        protected EfCoreDbSession(DbContextOptions<TDbSession> options) : base(options) { }

        public IDbConnection Connection => Database.GetDbConnection();

        public IDbTransaction Transaction {
            get => Database.CurrentTransaction.GetDbTransaction();
            set => Database.UseTransaction(value as DbTransaction);
        }

        public IDbTransaction BeginTransaction(IsolationLevel il) {
            throw new System.NotImplementedException();
        }

        public void Commit() {
            Commit(null);
        }

        public void Commit(Action callback) {
            try {
                SaveChanges();
                Database.CommitTransaction();
            }
            catch {
                Rollback();
                throw;
            }
            finally {
                callback?.Invoke();
            }
        }

        public void Rollback() {
            Database.RollbackTransaction();
        }

        public bool AutoTransactionsEnabled {
            get => Database.AutoTransactionsEnabled;
            set => Database.AutoTransactionsEnabled = value;
        }
    }
}