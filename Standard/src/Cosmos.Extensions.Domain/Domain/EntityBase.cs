using System;
using System.ComponentModel.DataAnnotations;
using Cosmos.IdUtils;
using Cosmos.Validations;

namespace Cosmos.Domain
{
    public abstract class EntityBase<TEntity, TKey> : DomainObject<TEntity>, IEntity<TEntity, TKey>
        where TEntity : class, IEntity, IValidatable<TEntity>
    {
        protected EntityBase() => Init();

        protected EntityBase(TKey id) => Id = id;

        [Key, Required]
        public TKey Id { get; set; }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            var entity = other as EntityBase<TEntity, TKey>;
            if (entity == null)
                return false;
            return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return ReferenceEquals(Id, null) ? 0 : Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right)
        {
            if ((object) left == null && (object) right == null)
                return true;
            if (!(left is TEntity) || !(right is TEntity))
                return false;
            if (Equals(left.Id, null) || left.Id.Equals(default(TKey)))
                return false;
            return left.Id.Equals(right.Id);
        }

        public static bool operator !=(EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right)
        {
            return !(left == right);
        }

        public void Init()
        {
            if (Types.Of<TKey>() == Types.Of<Guid>())
            {
                Id = GenerateCombKey().CastTo<TKey>();
            }
            else if (Id.Equals(default(TKey)))
            {
                Id = GenerateKey();
            }
        }

        #region Misc

        protected virtual TKey GenerateKey()
        {
            return Guid.NewGuid().CastTo<TKey>();
        }

        protected virtual Guid GenerateCombKey()
        {
            return GuidProvider.Create(GuidStyle.CombStyle);
        }

        #endregion

    }
}