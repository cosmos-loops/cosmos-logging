using System;
using Cosmos.Domain.EntityDescriptors;

namespace Cosmos.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static TEntity AppendCreatedTime<TEntity, TKey>(this TEntity entity) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is ICreatedTime target)) return entity;

            target.CreatedTime = DateTime.Now;

            return entity;
        }

        public static TEntity AppendCreatingAduitedInfo<TEntity, TKey>(this TEntity entity, string deleteOperatorId) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is ICreatingAudited target)) return entity;

            target.CreatedOperatorId = deleteOperatorId;

            target.CreatedTime = DateTime.Now;

            return entity;
        }

        public static TEntity AppendUpdatingAduitedInfo<TEntity, TKey>(this TEntity entity, string deleteOperatorId) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is IUpdatingAudited target)) return entity;

            target.LastUpdatedOperatorId = deleteOperatorId;

            target.LastUpdatedTime = DateTime.Now;

            return entity;
        }

        public static TEntity AppendDeletedInfo<TEntity, TKey>(this TEntity entity, DeleteOperationTypes optType) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is IDeletable target)) return entity;

            switch (optType)
            {
                case DeleteOperationTypes.LogicDelete:
                    target.IsDeleted = true;
                    break;

                case DeleteOperationTypes.Restore:
                    target.IsDeleted = false;
                    break;

                case DeleteOperationTypes.PhysicalDelete:
                    if (!target.IsDeleted)
                        throw new InvalidOperationException("Entity cannot be hard-delete because for delete-status is false.");
                    break;
            }

            return entity;
        }
    }
}