using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.TemplateStandards;
using SqlSugar;

namespace Cosmos.Logging.Extensions.SqlSugar.Core {
    internal static class SqlSugarAopActivation {
        private const string TimestampKey = "COSMOSLOOPS::logging-extra-sqlsugar";

        public static void RegisterToSqlSugar(SimpleClient client, SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null,
            Func<string, SugarParameter[], object> executedAct = null,
            Func<Exception, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null) {
            RegisterToSqlSugar(client.FullClient, descriptor, executingAct, executedAct, errorAct, filter);
        }

        public static void RegisterToSqlSugar(SqlSugarClient client, SqlSugarInterceptorDescriptor descriptor,
            Action<string, SugarParameter[]> executingAct = null,
            Func<string, SugarParameter[], object> executedAct = null,
            Func<Exception, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));

            var pinLogEventStarting = client.Context.Ado.LogEventStarting;
            var pinLogEventCompleted = client.Context.Ado.LogEventCompleted;
            var pinErrorEvent = client.Context.Ado.ErrorEvent;
            Func<string, LogEventLevel, bool> localFilter = (s, l) => (descriptor.ExposeGlobalFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true);

            pinLogEventStarting += descriptor.ExposeExecutingInterceptor;
            pinLogEventCompleted += descriptor.ExposeExecutedInterceptor;
            pinErrorEvent += descriptor.ExposeErrorInterceptor;

            pinLogEventStarting += (sql, @params) => InternalExecutingOpt(client, sql, @params, executingAct);
            pinLogEventCompleted += (sql, @params) => InternalExecutedOpt(descriptor, client, sql, @params, executedAct, localFilter);
            pinErrorEvent += (exception) => InternalErrorOpt(descriptor, client, exception, errorAct, localFilter);

            client.Context.Ado.LogEventStarting = pinLogEventStarting;
            client.Context.Ado.LogEventCompleted = pinLogEventCompleted;
            client.Context.Ado.ErrorEvent = pinErrorEvent;
        }

        private static void InternalExecutingOpt(SqlSugarClient client, string sql, SugarParameter[] @params, Action<string, SugarParameter[]> executingAct = null) {
            if (client.TempItems == null) client.TempItems = new Dictionary<string, object>();
            executingAct?.Invoke(sql, @params);
            client.TempItems.Add(TimestampKey, DateTime.Now);
        }

        private static void InternalExecutedOpt(SqlSugarInterceptorDescriptor descriptor, SqlSugarClient client, string sql,
            SugarParameter[] @params, Func<string, SugarParameter[], object> executedAct = null, Func<string, LogEventLevel, bool> filter = null) {
            var ms = 0D;
            if (client.TempItems.TryGetValue(TimestampKey, out var startStamp) && startStamp is DateTime stamp) {
                client.TempItems.Remove(TimestampKey);
                ms = DateTime.Now.Subtract(stamp).TotalMilliseconds;
            }

            object loggingParams;
            var userInfo = executedAct?.Invoke(sql, @params) ?? string.Empty;
            var logger = descriptor.ExposeLoggingServiceProvider.GetLogger<SqlSugarClient>(filter, LogEventSendMode.Automatic, descriptor.RenderingOptions);

            if (ms > 1000) {
                var eventId = new LogEventId(client.ContextID, EventIdKeys.LongTimeExecuted);
                loggingParams = new {
                    OrmName = Constants.SinkKey,
                    ContextId = client.ContextID,
                    Sql = sql,
                    SqlParams = @params.Select(param => new DbParam(param.ParameterName, param.Value, param.DbType)).ToList(),
                    UsedTime = ms,
                    UserInfo = userInfo
                };
                logger.LogWarning(eventId, OrmTemplateStandard.LongNormal, loggingParams);
            } else {
                var eventId = new LogEventId(client.ContextID, EventIdKeys.Executed);
                loggingParams = new {
                    OrmName = Constants.SinkKey,
                    ContextId = client.ContextID,
                    Sql = sql,
                    UsedTime = ms,
                    UserInfo = userInfo
                };
                logger.LogInformation(eventId, OrmTemplateStandard.Normal, loggingParams);
            }
        }

        private static void InternalErrorOpt(SqlSugarInterceptorDescriptor descriptor, SqlSugarClient client, Exception exception,
            Func<Exception, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null) {
            object userInfo = errorAct?.Invoke(exception) ?? string.Empty;
            var logger = descriptor.ExposeLoggingServiceProvider.GetLogger<SqlSugarClient>(filter, LogEventSendMode.Automatic, descriptor.RenderingOptions);
            var eventId = new LogEventId(client?.ContextID ?? Guid.NewGuid(), EventIdKeys.Error);
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
            logger.LogError(eventId, exception, OrmTemplateStandard.Error, loggingParams);
        }
    }
}