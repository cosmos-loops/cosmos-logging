using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cosmos.Logging.Extensions.Exceptions.Core;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public class ReflectionTypeLoadExceptionDestructurer : ExceptionDestructurer<ReflectionTypeLoadException> {
        protected override void DestructureException(
            ReflectionTypeLoadException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            propertyBag.AddProperty(
                nameof(ReflectionTypeLoadException.LoaderExceptions),
                exception.LoaderExceptions.Select(destructureExceptionHandle).ToList());
        }
    }
}