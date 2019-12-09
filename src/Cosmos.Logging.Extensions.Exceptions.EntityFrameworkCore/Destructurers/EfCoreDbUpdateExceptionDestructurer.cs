using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public class EfCoreDbUpdateExceptionDestructurer : ExceptionDestructurer {
        public override Type[] TargetTypes => new[] {typeof(DbUpdateException), typeof(DbUpdateConcurrencyException)};

        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var current = (DbUpdateException) exception;

            var entryColl = current.Entries?.Select(x => new {
                EntryProperties = x.Properties.Select(p => new {
                    PropertyName = p.Metadata.Name,
                    p.OriginalValue,
                    p.CurrentValue,
                    p.IsTemporary,
                    p.IsModified
                }),
                x.State
            }).ToList();

            propertyBag.AddProperty(nameof(DbUpdateException.Entries), entryColl);
        }
    }
}