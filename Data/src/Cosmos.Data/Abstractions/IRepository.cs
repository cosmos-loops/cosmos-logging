using System.Threading.Tasks;

namespace Cosmos.Data.Abstractions {
    public interface IRepository {
        /// <summary>
        /// Repository's name
        /// 仓储名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Commit
        /// 提交
        /// </summary>
        void Commit();

        /// <summary>
        /// Commit async
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// Rollback
        /// 回滚
        /// </summary>
        void Rollback();

        /// <summary>
        /// Flag if need to commit
        /// 标记是否需要提交
        /// </summary>
        bool NeedToCommit { get; }
    }
}