using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Extensions.Exceptions.Core;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    /// <summary>
    /// Aggregate exception destructurer 
    /// </summary>
    public class AggregateExceptionDestructurer : ExceptionDestructurer<AggregateException> {
        protected override void DestructureException(AggregateException exception, IExceptionPropertyBag propertyBag,
                                                     Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(
                nameof(AggregateException.InnerException),
                exception.InnerExceptions.Select(destructureExceptionHandle).ToList());
        }
    }
}