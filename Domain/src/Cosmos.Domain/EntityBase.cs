using System;
using System.ComponentModel.DataAnnotations;
using Cosmos.Validations;

namespace Cosmos.Domain {
    public abstract class EntityBase<TEntity, TKey> : DomainObject<TEntity>, IEntity<TEntity, TKey>
        where TEntity : class, IEntity, IValidatable<TEntity> {
        protected EntityBase() { }
        protected EntityBase(TKey id) => Id = id;

        [Required]
        [Key]
        public TKey Id { get; set; }

        public override bool Equals(object other) {
            return this == (other as EntityBase<TEntity, TKey>);
        }

        public override int GetHashCode() {
            return ReferenceEquals(Id, null) ? 0 : Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right) {
            if ((object) left == null && (object) right == null)
                return true;
            if (!(left is TEntity) || !(right is TEntity))
                return false;
            if (Equals(left.Id, null) || left.Id.Equals(default(TKey)))
                return false;
            return left.Id.Equals(right.Id);
        }

        public static bool operator !=(EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right) {
            return !(left == right);
        }

        public virtual void Init() {
            if (Id.Equals(default(TKey)))
                Id = GenerateKey();
        }

        #region Misc

        protected virtual TKey GenerateKey() {
            return Guid.NewGuid().CastTo<TKey>();
        }

        #endregion

    }
}