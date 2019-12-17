using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.FreeSql.Core;
using FreeSql.Aop;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for FreeSql
    /// </summary>
    public static class FreeSqlExtensions {
        /// <summary>
        /// Use Cosmos Logging for FreeSql
        /// </summary>
        /// <param name="freeSql"></param>
        /// <param name="descriptor"></param>
        /// <param name="executingAct"></param>
        /// <param name="executedAct"></param>
        /// <param name="errorAct"></param>
        /// <param name="filter"></param>
        /// <typeparam name="TFreeSql"></typeparam>
        /// <returns></returns>
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