using System;
using System.Data;
using System.Threading.Tasks;
using Cosmos.Data.Abstractions;

namespace Cosmos.Data.Dapper {
    public abstract class DapperRepository<TDbSession> : DisposableObjects, IRepository
        where TDbSession : class, IDapperDbSession, IDapperDbSessionQueryProxy, IDbSession {

        protected DapperRepository(TDbSession session, string sessionName)
            : this(() => session, sessionName) { }

        protected DapperRepository(IDbConnection connection, string sessionName)
            : this(() => DapperDbSessionCreator.Create<TDbSession>(connection), sessionName) { }

        private DapperRepository(Func<TDbSession> func, string sessionName) {
            if (string.IsNullOrWhiteSpace(sessionName)) throw new ArgumentNullException(nameof(sessionName));
            Name = sessionName;
            CurrentSession = func() ?? throw new ArgumentNullException(nameof(TDbSession));
        }

        /// <summary>
        /// Repository's name
        /// 仓储名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Current DbSession
        /// 当前会话
        /// </summary>
        protected TDbSession CurrentSession { get; }

        /// <summary>
        /// Commit
        /// 提交
        /// </summary>
        public void Commit() {
            CurrentSession.Commit();
        }

        /// <summary>
        /// Commit async
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public Task CommitAsync() {
            Commit();
            return Task.CompletedTask;
        }

        public void Rollback() {
            CurrentSession.Rollback();
        }

        /// <summary>
        /// Flag if need to commit
        /// 标记是否需要提交
        /// </summary>
        public bool NeedToCommit { get; protected set; } = false;
    }
}