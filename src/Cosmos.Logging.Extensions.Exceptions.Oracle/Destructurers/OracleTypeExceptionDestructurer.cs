using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Oracle.ManagedDataAccess.Types;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public class OracleTypeExceptionDestructurer : ExceptionDestructurer
    {
        public override Type[] TargetTypes => new[]
        {
            typeof(OracleTypeException),
            typeof(OracleTruncateException),
            typeof(OracleNullValueException)
        };

        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var typeException = (OracleTypeException) exception;

            propertyBag.AddProperty(nameof(OracleTypeException.Number), typeException.Number);
        }
    }
}