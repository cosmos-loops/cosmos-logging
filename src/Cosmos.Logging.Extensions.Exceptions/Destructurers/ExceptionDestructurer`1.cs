using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public abstract class ExceptionDestructurer<TSingleException> : ExceptionDestructurer where TSingleException : Exception
    {
        public override Type[] TargetTypes => new[] {typeof(TSingleException)};

        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var typedException = (TSingleException) exception;

            DestructureException(typedException, propertyBag, destructureExceptionHandle);
        }

        protected abstract void DestructureException(
            TSingleException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle);
    }
}