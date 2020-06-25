using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;
using Cosmos.Logging.Exceptions.Destructurers;
using EnumsNET;
using Npgsql;

namespace Cosmos.Logging.Extensions.PostgreSql.Exceptions.Destructurers {
    /// <summary>
    /// Postgres exception destructurer
    /// </summary>
    public class PostgresExceptionDestructurer : ExceptionDestructurer<PostgresException> {
        /// <inheritdoc />
        protected override void DestructureException(
            PostgresException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(PostgresException.Line), exception.Line);
            propertyBag.AddProperty(nameof(PostgresException.Position), exception.Position);
            propertyBag.AddProperty(nameof(PostgresException.Severity), exception.Severity);
            propertyBag.AddProperty(nameof(PostgresException.SchemaName), exception.SchemaName);
            propertyBag.AddProperty(nameof(PostgresException.TableName), exception.TableName);
            propertyBag.AddProperty(nameof(PostgresException.ColumnName), exception.ColumnName);
            propertyBag.AddProperty(nameof(PostgresException.DataTypeName), exception.DataTypeName);
            propertyBag.AddProperty(nameof(PostgresException.ConstraintName), exception.ConstraintName);
            propertyBag.AddProperty(nameof(PostgresException.Where), exception.Where);
            propertyBag.AddProperty(nameof(PostgresException.Statement.StatementType), exception.Statement.StatementType.GetName());
            propertyBag.AddProperty(nameof(PostgresException.Statement.SQL), exception.Statement.SQL);
            propertyBag.AddProperty(nameof(PostgresException.Statement.OID), exception.Statement.OID);
            propertyBag.AddProperty(nameof(PostgresException.Statement.Rows), exception.Statement.Rows);
            propertyBag.AddProperty(nameof(PostgresException.SqlState), exception.SqlState);
            propertyBag.AddProperty(nameof(PostgresException.Detail), exception.Detail);
            propertyBag.AddProperty(nameof(PostgresException.Hint), exception.Hint);
            propertyBag.AddProperty(nameof(PostgresException.IsTransient), exception.IsTransient);
            propertyBag.AddProperty(nameof(PostgresException.File), exception.File);
            propertyBag.AddProperty(nameof(PostgresException.Routine), exception.Routine);

        }
    }
}