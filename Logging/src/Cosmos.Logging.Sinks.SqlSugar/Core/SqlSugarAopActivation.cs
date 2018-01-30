using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.TemplateStandards;
using SqlSugar;

namespace Cosmos.Logging.Sinks.SqlSugar.Core {
    internal static class SqlSugarAopActivation {
        private const string TimestampKey = "COSMOSLOOPS::logging-extra-sqlsugar";

        public static void RegisterToSqlSugar(SimpleClient client, SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null,
            Func<string, SugarParameter[], object> executedAct = null,
            Func<Exception, object> errorAct = null) {
            RegisterToSqlSugar(client.FullClient, descriptor, executingAct, executedAct, errorAct);
        }

        public static void RegisterToSqlSugar(SqlSugarClient client, SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null,
            Func<string, SugarParameter[], object> executedAct = null,
            Func<Exception, object> errorAct = null) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));

            var pinLogEventStarting = client.Context.Ado.LogEventStarting;
            var pinLogEventCompleted = client.Context.Ado.LogEventCompleted;
            var pinErrorEvent = client.Context.Ado.ErrorEvent;

            pinLogEventStarting += descriptor.ExposeExecutingInterceptor;
            pinLogEventCompleted += descriptor.ExposeExecutedInterceptor;
            pinErrorEvent += descriptor.ExposeErrorInterceptor;

            pinLogEventStarting += (sql, @params) => InternalExecutingOpt(descriptor.ExposeLoggingServiceProvider, client, sql, @params, executingAct);
            pinLogEventCompleted += (sql, @params) => InternalExecutedOpt(descriptor.ExposeLoggingServiceProvider, client, sql, @params, executedAct);
            pinErrorEvent += (exception) => InternalErrorOpt(descriptor.ExposeLoggingServiceProvider, exception, errorAct);

            client.Context.Ado.LogEventStarting = pinLogEventStarting;
            client.Context.Ado.LogEventCompleted = pinLogEventCompleted;
            client.Context.Ado.ErrorEvent = pinErrorEvent;
        }

        private static void InternalExecutingOpt(ILoggingServiceProvider loggingServiceProvider, SqlSugarClient client, string sql,
            SugarParameter[] @params, Action<string, SugarParameter[]> executingAct = null) {
            if (client.TempItems == null) client.TempItems = new Dictionary<string, object>();
            executingAct?.Invoke(sql, @params);
            client.TempItems.Add(TimestampKey, DateTime.Now);
        }

        private static void InternalExecutedOpt(ILoggingServiceProvider loggingServiceProvider, SqlSugarClient client, string sql,
            SugarParameter[] @params, Func<string, SugarParameter[], object> executedAct = null) {
            var ms = 0D;
            if (client.TempItems.TryGetValue(TimestampKey, out var startStamp) && startStamp is DateTime stamp) {
                client.TempItems.Remove(TimestampKey);
                ms = DateTime.Now.Subtract(stamp).TotalMilliseconds;
            }

            object loggingParams;
            var userInfo = executedAct?.Invoke(sql, @params) ?? string.Empty;
            var logger = loggingServiceProvider.GetLogger<SqlSugarClient>();

            if (ms > 1000) {
                loggingParams = new {
                    OrmName = Constants.SinkKey,
                    ContextId = client.ContextID,
                    Sql = sql,
                    SqlParams = @params.Select(param => new DbParam(param.ParameterName, param.Value, param.DbType)).ToList(),
                    UsedTime = ms,
                    UserInfo = userInfo
                };
                logger.LogWarning(OrmTemplateStandard.LongNormal, loggingParams);
            } else {
                loggingParams = new {
                    OrmName = Constants.SinkKey,
                    ContextId = client.ContextID,
                    Sql = sql,
                    UsedTime = ms,
                    UserInfo = userInfo
                };
                logger.LogInformation(OrmTemplateStandard.Normal, loggingParams);
            }
        }

        private static void InternalErrorOpt(ILoggingServiceProvider loggingServiceProvider, Exception exception,
            Func<Exception, object> errorAct = null) {
            object userInfo = errorAct?.Invoke(exception) ?? string.Empty;
            var logger = loggingServiceProvider.GetLogger<SqlSugarClient>();
            var realExcepton = exception.Unwrap();
            var loggingParams = new {
                OrmName = Constants.SinkKey,
                ContextId = "unknown",
                Sql = "unknown",
                SqlParams = "unknown",
                ExceptionType = exception.GetType(),
                ExceptionMessage = exception.Message,
                RealExceptionType = realExcepton.GetType(),
                RealExceptionMessage = realExcepton.Message,
                UsedTime = "unknown",
                UserInfo = userInfo
            };
            logger.LogError(exception, OrmTemplateStandard.Error, loggingParams);

        }
    }
}