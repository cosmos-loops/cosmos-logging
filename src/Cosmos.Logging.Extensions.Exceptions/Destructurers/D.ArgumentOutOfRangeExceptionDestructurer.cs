using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public class ArgumentOutOfRangeExceptionDestructurer : ArgumentExceptionDestructurer {
        public override Type[] TargetTypes => new[] {typeof(ArgumentOutOfRangeException)};

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