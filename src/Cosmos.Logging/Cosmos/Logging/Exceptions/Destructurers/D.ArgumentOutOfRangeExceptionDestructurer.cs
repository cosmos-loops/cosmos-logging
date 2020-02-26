using System;
using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Core;

namespace Cosmos.Logging.Exceptions.Destructurers {
    /// <summary>
    /// ArgumentOutOfRange exception destructurer
    /// </summary>
    public class ArgumentOutOfRangeExceptionDestructurer : ArgumentExceptionDestructurer {
        /// <inheritdoc />
        public override Type[] TargetTypes => new[] {typeof(ArgumentOutOfRangeException)};

        /// <inheritdoc />
        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle) {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var argumentException = (ArgumentOutOfRangeException) exception;

            propertyBag.AddProperty(nameof(ArgumentOutOfRangeException.ActualValue), argumentException.ActualValue);
        }
    }
}