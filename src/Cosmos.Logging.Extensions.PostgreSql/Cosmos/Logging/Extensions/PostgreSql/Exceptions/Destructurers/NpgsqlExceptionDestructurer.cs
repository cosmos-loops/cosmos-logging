using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;
using Cosmos.Logging.Exceptions.Destructurers;
using Npgsql;

namespace Cosmos.Logging.Extensions.PostgreSql.Exceptions.Destructurers {
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