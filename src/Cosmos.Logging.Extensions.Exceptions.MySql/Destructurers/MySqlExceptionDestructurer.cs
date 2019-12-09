using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using MySql.Data.MySqlClient;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public class MySqlExceptionDestructurer : ExceptionDestructurer<MySqlException> {
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