using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using EnumsNET;
using OracleInternal.SqlAndPlsqlParser.LocalParsing;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public class OracleLpExceptionDestructurer: ExceptionDestructurer<OracleLpException>
    {
        protected override void DestructureException(OracleLpException exception, IExceptionPropertyBag propertyBag, Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            propertyBag.AddProperty(nameof(OracleLpException.Type), exception.Type.GetName());
            propertyBag.AddProperty(nameof(OracleLpException.Error), exception.Error.GetName());
        }
    }
}