using System.Data;

namespace Cosmos.Data.Dapper {
    public static class DapperUnitOfWorkExtensions {
        public static DapperUnitOfWork CreateUnitOfWork(this IDapperDbSession session) {
            return new DapperUnitOfWork(session);
        }

        public static DapperUnitOfWork CreateUnitOfWork(this IDapperDbSession session, IsolationLevel li) {
            return new DapperUnitOfWork(session, li);
        }
    }
}