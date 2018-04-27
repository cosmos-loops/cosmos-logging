using Cosmos.Data.Abstractions;

namespace Cosmos.Data.EntityFrameworkCore {
    public interface IEfCoreRepository<out TDbSession> : IRepository
        where TDbSession : EfCoreDbSession<TDbSession>, IEfCoreDbSession {
        /// <summary>
        /// Current DbSession
        /// 当前会话
        /// </summary>
        TDbSession CurrentSession { get; }

        /// <summary>
        /// Flag whether use uow or not
        /// 标记是否启用 UoW 模式，若启用，则本标记置为 true
        /// </summary>
        bool Suppress { get; set; }
    }
}