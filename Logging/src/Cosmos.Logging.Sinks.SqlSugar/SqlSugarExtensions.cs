using System;
using Cosmos.Logging.Sinks.SqlSugar.Core;

// ReSharper disable once CheckNamespace
namespace SqlSugar {
    public static class SqlSugarExtensions {
        public static SimpleClient UseCosmosLogging(this SimpleClient client, SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null, Func<string, SugarParameter[], object> executedAct = null, Func<Exception, object> errorAct = null) {
            SqlSugarAopActivation.RegisterToSqlSugar(client, descriptor, executingAct, executedAct, errorAct);
            return client;
        }

        public static SqlSugarClient UseCosmosLogging(this SqlSugarClient client, SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null, Func<string, SugarParameter[], object> executedAct = null, Func<Exception, object> errorAct = null) {
            SqlSugarAopActivation.RegisterToSqlSugar(client, descriptor, executingAct, executedAct, errorAct);
            return client;
        }
    }
}