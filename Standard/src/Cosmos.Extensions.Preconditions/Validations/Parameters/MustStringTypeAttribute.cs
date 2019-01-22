using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustStringTypeAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Type.IsNot(TypeClass.StringClass))
                throw new ArgumentException(Message, context.Parameter.Name);
            return next(context);
        }
    }
}