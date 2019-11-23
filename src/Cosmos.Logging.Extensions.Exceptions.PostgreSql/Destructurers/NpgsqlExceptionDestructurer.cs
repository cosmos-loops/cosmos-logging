using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Npgsql;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public class NpgsqlExceptionDestructurer : ExceptionDestructurer<NpgsqlException>
    {
        protected override void DestructureException(NpgsqlException exception, IExceptionPropertyBag propertyBag, Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            propertyBag.AddProperty(nameof(NpgsqlException.IsTransient), exception.IsTransient);
        }
    }
}