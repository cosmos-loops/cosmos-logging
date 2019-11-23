using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Cosmos.Logging.Extensions.Exceptions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public class EfDbUpdateExceptionDestructurer : ExceptionDestructurer
    {
        public override Type[] TargetTypes => new[] {typeof(DbUpdateException), typeof(DbUpdateConcurrencyException)};

        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var current = (DbUpdateException) exception;

            var list = (
                from entry in current.Entries
                let properties = entry.CurrentValues.PropertyNames
                    .Select(entry.Property)
                    .Select(c => new {c.Name, c.OriginalValue, c.CurrentValue, c.IsModified})
                    .ToList()
                select new {EntryProperties = properties, entry.State}
            ).ToList();

            propertyBag.AddProperty(nameof(DbUpdateException.Entries), list.ToList());
        }
    }
}