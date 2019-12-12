using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.SqlSugar.Core;
using SqlSugar;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for SqlSugar
    /// </summary>
    public static class SqlSugarExtensions {
        /// <summary>
        /// Use Cosmos Logging for SqlSugar
        /// </summary>
        /// <param name="client"></param>
        /// <param name="descriptor"></param>
        /// <param name="executingAct"></param>
        /// <param name="executedAct"></param>
        /// <param name="errorAct"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static SimpleClient UseCosmosLogging(
            this SimpleClient client,
            SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null,
            Func<string, SugarParameter[], object> executedAct = null,
            Func<Exception, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null) {
            SqlSugarAopActivation.RegisterToSqlSugar(client, descriptor, executingAct, executedAct, errorAct, filter);
            return client;
        }

        /// <summary>
        /// Use Cosmos Logging for SqlSugar
        /// </summary>
        /// <param name="client"></param>
        /// <param name="descriptor"></param>
        /// <param name="executingAct"></param>
        /// <param name="executedAct"></param>
        /// <param name="errorAct"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static SqlSugarClient UseCosmosLogging(
            this SqlSugarClient client,
            SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null,
            Func<string, SugarParameter[], object> executedAct = null,
            Func<Exception, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null) {
            SqlSugarAopActivation.RegisterToSqlSugar(client, descriptor, executingAct, executedAct, errorAct, filter);
            return client;
        }
    }
}