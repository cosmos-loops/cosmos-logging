using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Cosmos.Logging.Extensions.Exceptions.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public class SqliteExceptionDestructurer : ExceptionDestructurer<SQLiteException> {
        protected override void DestructureException(
            SQLiteException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(SQLiteException.ResultCode), exception.ResultCode.GetName());
        }
    }
}