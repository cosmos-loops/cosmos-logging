using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustIntAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public bool MayBeNullable { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? context.Parameter.IsNot(TypeClass.IntClass).OrNot(TypeClass.IntNullableClass)
                : context.Parameter.Type.IsNot(TypeClass.IntClass);
            if (condition)
                throw new ArgumentException(Message, context.Parameter.Name);
            return next(context);
        }
    }
}