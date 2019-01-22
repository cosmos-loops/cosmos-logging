using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Extensions;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotNegativeOrZeroAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().SafeValue().CheckNegativeOrZero(context.Parameter.Name, Message);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().SafeValue().CheckNegativeOrZero(context.Parameter.Name, Message);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().SafeValue().CheckNegativeOrZero(context.Parameter.Name, Message);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().SafeValue().CheckNegativeOrZero(context.Parameter.Name, Message);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().SafeValue().CheckNegativeOrZero(context.Parameter.Name, Message);
            else if (context.Parameter.IsTimeSpanType())
                context.Parameter.TryTo<TimeSpan?>().SafeValue().CheckNegativeOrZero(context.Parameter.Name, Message);
            return next(context);
        }
    }
}