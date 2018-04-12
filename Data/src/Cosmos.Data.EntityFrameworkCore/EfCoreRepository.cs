using System;
using System.Threading.Tasks;
using Cosmos.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cosmos.Data.EntityFrameworkCore {
    public abstract partial class EfCoreRepository<TDbSession, TDbEntity, TPrimaryKey> : DisposableObjects, IRepository
        where TDbSession : EfCoreDbSession<TDbSession>, IEfCoreDbSession
        where TDbEntity : class, IDbEntity<TPrimaryKey>, new() {

        protected EfCoreRepository(TDbSession session, string sessionName) {
            if (string.IsNullOrWhiteSpace(sessionName)) throw new ArgumentNullException(nameof(sessionName));
            Name = sessionName;
            CurrentSession = session;
            NeedToCommit = false;
            Suppress = false;
        }

        /// <summary>
        /// Repository's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Current DbSession
        /// 当前会话
        /// </summary>
        protected internal TDbSession CurrentSession { get; }

        /// <summary>
        /// Commit
        /// 提交
        /// </summary>
        public virtual void Commit() {
            if (!Suppress && NeedToCommit) {
                try {
                    CurrentSession.Commit();
                }
                finally {
                    NeedToCommit = false;
                }
            }
        }

        /// <summary>
        /// Commit async
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public virtual Task CommitAsync() {
            Commit();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Rollback
        /// 回滚
        /// </summary>
        public virtual void Rollback() {
            if (!Suppress && NeedToCommit) {
                try {
                    CurrentSession.Rollback();
                }
                finally {
                    NeedToCommit = false;
                }
            }
        }

        /// <summary>
        /// Flag if need to commit
        /// 标记是否需要提交
        /// </summary>
        public bool NeedToCommit { get; protected internal set; }

        /// <summary>
        /// Flag whether use uow or not
        /// 标记是否启用 UoW 模式，若启用，则本标记置为 true
        /// </summary>
        public bool Suppress { get; protected internal set; }

        /// <summary>
        /// Set true value to need-to-commit flag
        /// </summary>
        private void SetNeedToCommit() => NeedToCommit = true;
    }
}