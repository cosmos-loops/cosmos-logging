using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    /// <summary>
    /// Argument exception destructurer
    /// </summary>
    public class ArgumentExceptionDestructurer : ExceptionDestructurer
    {
        public override Type[] TargetTypes => new[]
        {
            typeof(ArgumentException),
            typeof(ArgumentNullException)
        };

        public override void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            base.Destructure(exception, propertyBag, destructureExceptionHandle);

            var argumentException = (ArgumentException) exception;

            propertyBag.AddProperty(nameof(ArgumentException.ParamName), argumentException.ParamName);
        }
    }
}