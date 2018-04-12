using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pomelo.EntityFrameworkCore.Lolita;

namespace Cosmos.Data.EntityFrameworkCore {
    public abstract partial class EfCoreRepository<TDbSession, TDbEntity, TPrimaryKey> {
        public EntityEntry<TDbEntity> Add(TDbEntity entity) {
            SetNeedToCommit();
            return CurrentSession.Add(entity);
        }

        public Task<EntityEntry<TDbEntity>> AddAsync(TDbEntity entity) {
            SetNeedToCommit();
            return CurrentSession.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TDbEntity> entityColl) {
            SetNeedToCommit();
            CurrentSession.AddRange(entityColl);
        }

        public Task AddRangeAsync(IEnumerable<TDbEntity> entityColl) {
            SetNeedToCommit();
            return CurrentSession.AddRangeAsync(entityColl);
        }

        public void Update(TDbEntity entity) {
            SetNeedToCommit();
            CurrentSession.Update(entity);
        }

        public void UpdateRange(IEnumerable<TDbEntity> entityColl) {
            SetNeedToCommit();
            CurrentSession.Set<TDbEntity>().UpdateRange(entityColl);
        }

        public int BulkUpdate(Expression<Func<TDbEntity, bool>> predicate,
            Func<IQueryable<TDbEntity>, LolitaSetting<TDbEntity>> updateFunc,
            params Func<LolitaSetting<TDbEntity>, LolitaSetting<TDbEntity>>[] moreUpdateFunc) {
            SetNeedToCommit();
            var entry = CurrentSession.Set<TDbEntity>().Where(predicate);
            var lolitaEntry = updateFunc(entry);
            if (moreUpdateFunc != null && moreUpdateFunc.Any()) {
                lolitaEntry = moreUpdateFunc.Aggregate(lolitaEntry, (current, func) => func(current));
            }

            return lolitaEntry.Update();
        }

        public Task<int> BulkUpdateAsync(Expression<Func<TDbEntity, bool>> predicate,
            Func<IQueryable<TDbEntity>, LolitaSetting<TDbEntity>> updateFunc,
            params Func<LolitaSetting<TDbEntity>, LolitaSetting<TDbEntity>>[] moreUpdateFunc) {
            SetNeedToCommit();
            var entry = CurrentSession.Set<TDbEntity>().Where(predicate);
            var lolitaEntry = updateFunc(entry);
            if (moreUpdateFunc != null && moreUpdateFunc.Any()) {
                lolitaEntry = moreUpdateFunc.Aggregate(lolitaEntry, (current, func) => func(current));
            }

            return lolitaEntry.UpdateAsync();
        }

        public int BulkDelete(Expression<Func<TDbEntity, bool>> predicate,
            params Expression<Func<TDbEntity, bool>>[] morePreficates) {
            SetNeedToCommit();
            var entry = CurrentSession.Set<TDbEntity>().Where(predicate);
            if (morePreficates != null && morePreficates.Any()) {
                entry = morePreficates.Aggregate(entry, (current, del) => current.Where(del));
            }

            return entry.Delete();
        }

        public Task<int> BulkDeleteAsync(Expression<Func<TDbEntity, bool>> predicate,
            params Expression<Func<TDbEntity, bool>>[] morePreficates) {
            SetNeedToCommit();
            var entry = CurrentSession.Set<TDbEntity>().Where(predicate);
            if (morePreficates != null && morePreficates.Any()) {
                entry = morePreficates.Aggregate(entry, (current, del) => current.Where(del));
            }

            return entry.DeleteAsync();
        }
    }
}