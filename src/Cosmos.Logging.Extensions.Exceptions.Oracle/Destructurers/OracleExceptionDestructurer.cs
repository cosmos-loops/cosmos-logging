using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Oracle.ManagedDataAccess.Client;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public class OracleExceptionDestructurer : ExceptionDestructurer<OracleException> {
        protected override void DestructureException(
            OracleException exception, 
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(nameof(OracleException.Number), exception.Number);
            propertyBag.AddProperty(nameof(OracleException.Procedure), exception.Procedure);
            propertyBag.AddProperty(nameof(OracleException.DataSource), exception.DataSource);
            propertyBag.AddProperty(nameof(OracleException.Errors), null);
            propertyBag.AddProperty(nameof(OracleException.IsRecoverable), exception.IsRecoverable);
        }
    }
}