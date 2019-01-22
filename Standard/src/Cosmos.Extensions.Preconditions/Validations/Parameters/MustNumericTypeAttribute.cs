using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Judgements;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    public class MustNumericTypeAttribute : ParameterInterceptorAttribute
    {
        public string Message { get; set; }

        public bool MayBeNullable { get; set; }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? TypeJudgement.IsNumericType(context.Parameter.Type)
                : TypeJudgement.IsNumericType(context.Parameter.Type) && !TypeJudgement.IsNullableType(context.Parameter.Type);
            if (condition)
                throw new ArgumentException(Message, context.Parameter.Name);
            return next(context);
        }
    }
}