using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Exceptions.Core;
using Cosmos.Logging.Exceptions.Destructurers;
using Microsoft.EntityFrameworkCore;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// EntityFrameworkCore DbUpdateException destructurer
    /// </summary>
    public class EfCoreDbUpdateExceptionDestructurer : ExceptionDestructurer {
        /// <inheritdoc />
        public override Type[] TargetTypes => new[] {typeof(DbUpdateException), typeof(DbUpdateConcurrencyException)};

        /// <inheritdoc />
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