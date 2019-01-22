using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Extensions;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotNegativeAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().SafeValue().CheckNegative(context.Parameter.Name, Message);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().SafeValue().CheckNegative(context.Parameter.Name, Message);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().SafeValue().CheckNegative(context.Parameter.Name, Message);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().SafeValue().CheckNegative(context.Parameter.Name, Message);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().SafeValue().CheckNegative(context.Parameter.Name, Message);
            else if (context.Parameter.IsTimeSpanType())
                context.Parameter.TryTo<TimeSpan?>().SafeValue().CheckNegative(context.Parameter.Name, Message);
            return next(context);
        }
    }
}