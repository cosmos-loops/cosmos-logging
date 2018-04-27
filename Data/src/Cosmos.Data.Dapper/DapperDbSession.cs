using System;
using System.Data;
using Dapper;

namespace Cosmos.Data.Dapper {
    public abstract partial class DapperDbSession<TDbConnection> : IDapperDbSession, IDapperDbSessionQueryProxy
        where TDbConnection : class, IDbConnection {

        protected DapperDbSession(TDbConnection connection) {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        #region connection

        public IDbConnection Connection { get; private set; }

        #endregion

        #region transaction

        public IDbTransaction Transaction { get; protected set; }

        public IDbTransaction BeginTransaction(IsolationLevel il) {
            if (!Connection.State.HasFlag(ConnectionState.Open)) {
                Connection.Open();
            }

            Transaction = Connection.BeginTransaction(il);
            return Transaction;
        }

        public void Commit() {
            Commit(null);
        }

        public void Commit(Action callback) {
            try {
                if (Transaction != null) {
                    Transaction.Commit();
                    Transaction.Dispose();
                    Transaction = null;
                }
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
            try {
                if (Transaction != null) {
                    Transaction.Rollback();
                    Transaction.Dispose();
                    Transaction = null;
                }
            }
            catch {
                if (Transaction?.Connection != null) {
                    Transaction.Dispose();
                    Transaction = null;
                }

                throw;
            }
        }

        private CommandDefinition InjectTransaction(CommandDefinition commandDefinition) {
            if (Transaction == null) {
                return commandDefinition;
            }

            var command = new CommandDefinition(
                commandDefinition.CommandText,
                commandDefinition.Parameters,
                Transaction,
                commandDefinition.CommandTimeout,
                commandDefinition.CommandType,
                commandDefinition.Flags,
                commandDefinition.CancellationToken);

            return command;
        }

        #endregion

        #region operation proxy

        public IDapperDbSessionQueryProxy OperationProxy => this;

        #endregion

        #region dispose

        private bool _disposed = false;

        public void Dispose() {
            Dispose(true);
        }

        protected void Dispose(bool disposing) {
            if (_disposed) {
                return;
            }

            if (disposing) {
                if (Connection?.State == ConnectionState.Open) {
                    Connection.Close();
                    Connection.Dispose();
                    Connection = null;
                }

                _disposed = true;
            }

            _disposed = true;
        }

        #endregion

    }
}