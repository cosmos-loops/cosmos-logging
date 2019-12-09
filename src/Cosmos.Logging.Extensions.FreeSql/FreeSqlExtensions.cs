using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.FreeSql.Core;
using FreeSql.Aop;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class FreeSqlExtensions {
        public static TFreeSql UseCosmosLogging<TFreeSql>(
            this TFreeSql freeSql,
            FreeSqlInterceptorDescriptor descriptor,
            Action<CurdBeforeEventArgs> executingAct = null,
            Func<CurdAfterEventArgs, object> executedAct = null,
            Func<Exception, CurdAfterEventArgs, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null) where TFreeSql : IFreeSql {
            FreeSqlAopActivation.RegisterToFreeSql(freeSql, descriptor, executingAct, executedAct, errorAct, filter);
            return freeSql;
        }
    }
}