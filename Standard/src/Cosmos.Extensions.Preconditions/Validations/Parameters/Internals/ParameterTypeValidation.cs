using System;

namespace Cosmos.Validations.Parameters.Internals
{
    public class ParameterTypeValidation
    {
        public ParameterTypeValidation(bool result, Type parameterType)
        {
            Result = result;
            ParameterType = parameterType;
        }

        public bool Result { get; }

        public Type ParameterType { get; }

        public static implicit operator bool(ParameterTypeValidation result)
        {
            return result.Result;
        }
    }
}