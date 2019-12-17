using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Npgsql;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// Npgsql exception destructurer
    /// </summary>
    public class NpgsqlExceptionDestructurer : ExceptionDestructurer<NpgsqlException> {
        /// <inheritdoc />
        protected override void DestructureException(
            NpgsqlException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(NpgsqlException.IsTransient), exception.IsTransient);
        }
    }
}