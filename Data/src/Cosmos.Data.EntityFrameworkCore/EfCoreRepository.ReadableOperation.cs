using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCore.Collections.Paginable;
using Microsoft.EntityFrameworkCore;

namespace Cosmos.Data.EntityFrameworkCore {
    public abstract partial class EfCoreRepository<TDbSession, TDbEntity, TPrimaryKey> {
        public TDbEntity Get(TPrimaryKey key) {
            return CurrentSession.Set<TDbEntity>().Find(key);
        }

        public Task<TDbEntity> GetAsync(TPrimaryKey key) {
            return CurrentSession.Set<TDbEntity>().FindAsync(key);
        }

        public IQueryable<TDbEntity> Get(Expression<Func<TDbEntity, bool>> predicate) {
            return CurrentSession.Set<TDbEntity>().Where(predicate);
        }

        public IEnumerable<TDbEntity> Get(Expression<Func<TDbEntity, bool>> predicate, int pageNumber, int pageSize) {
            return CurrentSession.Set<TDbEntity>().Where(predicate).GetPage(pageNumber, pageSize).ToOrigonItems();
        }

        public Task<IEnumerable<TDbEntity>> GetAsync(Expression<Func<TDbEntity, bool>> predicate, int pageNumber, int pageSize) {
            return Task.FromResult(Get(predicate, pageNumber, pageSize));
        }

        public IPage<TDbEntity> GetPage(Expression<Func<TDbEntity, bool>> predicate, int pageNumber, int pageSize) {
            return CurrentSession.Set<TDbEntity>().Where(predicate).GetPage(pageNumber, pageSize);
        }

        public Task<IPage<TDbEntity>> GetPageAsync(Expression<Func<TDbEntity, bool>> predicate, int pageNumber, int pageSize) {
            return Task.FromResult(GetPage(predicate, pageNumber, pageSize));
        }

        public TDbEntity FirstOrDefault(Expression<Func<TDbEntity, bool>> predicate) {
            return CurrentSession.Set<TDbEntity>().FirstOrDefault(predicate);
        }

        public Task<TDbEntity> FirstOrDefaultAsync(Expression<Func<TDbEntity, bool>> predicate) {
            return CurrentSession.Set<TDbEntity>().FirstOrDefaultAsync(predicate);
        }
    }
}