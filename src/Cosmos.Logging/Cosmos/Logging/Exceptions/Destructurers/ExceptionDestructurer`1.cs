using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Destructurers {
    /// <inheritdoc />
    public abstract class ExceptionDestructurer<TSingleException> : ExceptionDestructurer where TSingleException : Exception {
        /// <inheritdoc />
        public override Type[] TargetTypes => new[] {typeof(TSingleException)};

        /// <inheritdoc />
        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var typedException = (TSingleException) exception;

            DestructureException(typedException, propertyBag, destructureExceptionHandle);
        }

        /// <summary>
        /// Destructure exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="propertyBag"></param>
        /// <param name="destructureExceptionHandle"></param>
        protected abstract void DestructureException(
            TSingleException exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle);
    }
}