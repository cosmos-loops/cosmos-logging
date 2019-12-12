using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Extensions.Exceptions.Core;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// Sql exception destructurer
    /// </summary>
    public class SqlExceptionDestructurer : ExceptionDestructurer<SqlException> {

        /// <inheritdoc />
        protected override void DestructureException(
            SqlException exception, 
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(SqlException.ClientConnectionId), exception.ClientConnectionId);
            propertyBag.AddProperty(nameof(SqlException.Class), exception.Class);
            propertyBag.AddProperty(nameof(SqlException.LineNumber), exception.LineNumber);
            propertyBag.AddProperty(nameof(SqlException.Number), exception.Number);
            propertyBag.AddProperty(nameof(SqlException.Server), exception.Server);
            propertyBag.AddProperty(nameof(SqlException.State), exception.State);
            propertyBag.AddProperty(nameof(SqlException.Errors), exception.Errors.Cast<SqlError>().ToArray());
        }
    }
}