using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;
using Cosmos.Logging.Exceptions.Destructurers;
using MySql.Data.MySqlClient;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// MySql exception destructurer
    /// </summary>
    public class MySqlExceptionDestructurer : ExceptionDestructurer<MySqlException> {
        /// <inheritdoc />
        protected override void DestructureException(
            MySqlException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(MySqlException.Number), exception.Number);
            propertyBag.AddProperty(nameof(MySqlException.SqlState), exception.SqlState);
            propertyBag.AddProperty(nameof(MySqlException.ErrorCode), exception.ErrorCode);
        }
    }
}