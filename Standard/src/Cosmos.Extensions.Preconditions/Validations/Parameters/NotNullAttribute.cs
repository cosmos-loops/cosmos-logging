using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotNullAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Type.Is(TypeClass.StringClass))
                context.Parameter.TryTo(TypeDefault.StringEmpty).CheckNull(context.Parameter.Name, Message);
            else
                context.Parameter.Value.CheckNull(context.Parameter.Name, Message);
            return next(context);
        }
    }
}