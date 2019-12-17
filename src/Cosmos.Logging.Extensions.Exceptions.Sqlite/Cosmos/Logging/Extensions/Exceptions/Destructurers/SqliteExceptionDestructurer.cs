using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Cosmos.Logging.Extensions.Exceptions.Core;
using EnumsNET;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// Sqlite exception destructurer
    /// </summary>
    public class SqliteExceptionDestructurer : ExceptionDestructurer<SQLiteException> {
        /// <inheritdoc />
        protected override void DestructureException(
            SQLiteException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(SQLiteException.ResultCode), exception.ResultCode.GetName());
        }
    }
}