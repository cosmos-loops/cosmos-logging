using System;
using Cosmos.Domain.EntityDescriptors;
using Cosmos.Validations;

namespace Cosmos.Domain
{
    public abstract class ExpirableEntityBase<TEntity, TKey> : EntityBase<TEntity, TKey>, IExpireable
        where TEntity : class, IEntity, IValidatable<TEntity>
    {
        protected ExpirableEntityBase() : base() { }

        protected ExpirableEntityBase(TKey id) : base(id) { }

        public DateTime? ExpireLimitedFromTime { get; set; }
        public DateTime? ExpireLimitedToTime { get; set; }

        public void RaiseExceptionIfTimeInvalid()
        {
            if (!ExpireLimitedFromTime.HasValue) return;
            if (!ExpireLimitedToTime.HasValue) return;
            if (ExpireLimitedFromTime.Value < ExpireLimitedToTime.Value) return;
            throw new IndexOutOfRangeException("ExpireLimitedFromTime for expire limied cannot be greater than ExpireLimitedToTime.");
        }

        public bool IsStart() => IsStart(DateTime.Now);

        public bool IsExpired() => IsExpired(DateTime.Now);

        public bool IsActive() => IsActive(DateTime.Now);

        public virtual bool IsStart(DateTime targetTime)
        {
            if (ExpireLimitedFromTime.HasValue)
                return targetTime >= ExpireLimitedFromTime.Value;
            return false;
        }

        public virtual bool IsExpired(DateTime targetTime)
        {
            if (ExpireLimitedToTime.HasValue)
                return targetTime > ExpireLimitedToTime.Value;
            return false;
        }

        public virtual bool IsActive(DateTime targetTime)
        {
            if (ExpireLimitedFromTime.HasValue && ExpireLimitedToTime.HasValue)
                return targetTime >= ExpireLimitedFromTime.Value && targetTime < ExpireLimitedToTime.Value;
            if (ExpireLimitedFromTime.HasValue)
                return targetTime >= ExpireLimitedFromTime.Value;
            if (ExpireLimitedToTime.HasValue)
                return targetTime < ExpireLimitedToTime.Value;
            return false;
        }
    }
}