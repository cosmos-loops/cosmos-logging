using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotOutOfLengthAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public int Length { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Type.Is(TypeClass.StringClass))
                context.Parameter.TryTo(TypeDefault.StringEmpty).CheckOutOfLenth(Length, context.Parameter.Name, Message);
            return next(context);
        }
    }
}