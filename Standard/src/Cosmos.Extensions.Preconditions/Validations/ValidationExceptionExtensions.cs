using System;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Validations
{
    public static class ValidationExceptionExtensions
    {
        public static TException ToException<TException>(this ValidationResultCollection resultCollection,
            Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            if (resultCollection == null)
                throw new ArgumentNullException(nameof(resultCollection));
            var exception = NewBasicException<TException>(resultCollection);
            appendAction?.Invoke(exception, resultCollection);
            return exception;
        }

        public static TException ToException<TException>(this IValidationResult result,
            Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            switch (result)
            {
                case ValidationResultCollection fluentResult:
                    return ToException(fluentResult, appendAction);
                
                case null:
                    throw new ArgumentNullException(nameof(result));
                
                default:
                    throw new ArgumentException("ValidationResultCollection's type is invalid.");
            }
        }

        private static TException NewBasicException<TException>(IValidationResult result)
            where TException : CosmosException, new()
        {
            var type = typeof(TException);
            var exception = (TException) Activator.CreateInstance(type);
            type.GetField("Message").GetReflector().SetValue(exception, result.ToMessage());
            type.GetField("Code").GetReflector().SetValue(exception, result.ErrorCode);
            type.GetField("Flag").GetReflector().SetValue(exception, result.Flag);

            exception.ExtraData.Add("ValidationResultCollection", result);

            return exception;
        }

        public static void RaiseException<TException>(this ValidationResultCollection resultCollection,
            Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new()
        {
            throw resultCollection.ToException(appendAction);
        }
    }
}