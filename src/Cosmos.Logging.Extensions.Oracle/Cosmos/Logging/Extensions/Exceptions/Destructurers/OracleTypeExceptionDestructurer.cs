using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;
using Cosmos.Logging.Exceptions.Destructurers;
using Oracle.ManagedDataAccess.Types;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// OracleType exception destructurer
    /// </summary>
    public class OracleTypeExceptionDestructurer : ExceptionDestructurer {
        /// <inheritdoc />
        public override Type[] TargetTypes => new[] {
            typeof(OracleTypeException),
            typeof(OracleTruncateException),
            typeof(OracleNullValueException)
        };

        /// <inheritdoc />
        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var typeException = (OracleTypeException) exception;

            propertyBag.AddProperty(nameof(OracleTypeException.Number), typeException.Number);
        }
    }
}