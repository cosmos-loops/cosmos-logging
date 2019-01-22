using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustLongTypeAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public bool MayBeNullable { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? context.Parameter.IsNot(TypeClass.LongClass).OrNot(TypeClass.LongNullableClass)
                : context.Parameter.Type.IsNot(TypeClass.LongClass);
            if (condition)
                throw new ArgumentException(Message, context.Parameter.Name);
            return next(context);
        }
    }
}