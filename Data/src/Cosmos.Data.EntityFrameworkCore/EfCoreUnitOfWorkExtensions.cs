using Cosmos.Data.Abstractions;

namespace Cosmos.Data.EntityFrameworkCore {
    public static class EfCoreUnitOfWorkExtensions {
        public static EfCoreUnitOfWork CreateUnitOfWork<TDbSession, TDbEntity, TPrimaryKey>(
            this EfCoreRepository<TDbSession, TDbEntity, TPrimaryKey> repository)
            where TDbSession : EfCoreDbSession<TDbSession>, IEfCoreDbSession
            where TDbEntity : class, IDbEntity<TPrimaryKey>, new() {
            var origin = repository.CurrentSession.AutoTransactionsEnabled;
            repository.CurrentSession.AutoTransactionsEnabled = false;
            repository.Suppress = true;
            return new EfCoreUnitOfWork(repository.CurrentSession, origin);
        }
    }
}