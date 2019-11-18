using System;
using System.Collections;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Core;
using Cosmos.Logging.Extensions.Exceptions.Core.Internals;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    /// <summary>
    /// Base destructurer
    /// </summary>
    public partial class ExceptionDestructurer : IExceptionDestructurer
    {
        public virtual Type[] TargetTypes => GetTargetTypes().ToArray();

        public virtual void Destructure(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> destructureExceptionHandle)
        {
            if (exception is null)
                throw new ArgumentNullException(nameof(exception));

            if (propertyBag is null)
                throw new ArgumentNullException(nameof(propertyBag));

            if (destructureExceptionHandle is null)
                throw new ArgumentNullException(nameof(destructureExceptionHandle));

            propertyBag.AddProperty("Type", exception.GetType().FullName);

            DestructureCommonExceptionProperties(exception, propertyBag, destructureExceptionHandle,
                data => data.MapToStrObjDictionary());
        }

        internal static void DestructureCommonExceptionProperties(
            Exception exception,
            IExceptionPropertyBag propertyBag,
            Func<Exception, IReadOnlyDictionary<string, object>> innerExceptionDestructurer,
            Func<IDictionary, object> destructureDataProperty)
        {
            if (exception.Data.Count != 0)
            {
                propertyBag.AddProperty(nameof(Exception.Data), destructureDataProperty(exception.Data));
            }

            if (!string.IsNullOrWhiteSpace(exception.HelpLink))
            {
                propertyBag.AddProperty(nameof(Exception.HelpLink), exception.HelpLink);
            }

            if (exception.HResult != 0)
            {
                propertyBag.AddProperty(nameof(Exception.HResult), exception.HResult);
            }

            propertyBag.AddProperty(nameof(Exception.Message), exception.Message);
            propertyBag.AddProperty(nameof(Exception.Source), exception.Source);
            propertyBag.AddProperty(nameof(Exception.StackTrace), exception.StackTrace);

#if NET461 || NET472
            if (exception.TargetSite != null)
            {
                propertyBag.AddProperty(nameof(Exception.TargetSite), exception.TargetSite.ToString());
            }
#endif
            if (exception.InnerException != null)
            {
                propertyBag.AddProperty(nameof(Exception.InnerException), innerExceptionDestructurer(exception.InnerException));
            }

        }
    }
}