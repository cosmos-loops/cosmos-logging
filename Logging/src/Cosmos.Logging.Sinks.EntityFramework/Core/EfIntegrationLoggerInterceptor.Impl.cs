using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.TemplateStandards;

namespace Cosmos.Logging.Sinks.EntityFramework.Core {
    public partial class EfIntegrationLoggerInterceptor {
        private void OnExecuting(DbCommand command, Action<string, DbParameterCollection, DateTime> specificAction) {
            InternalLoggingSharedContext.AddStartTime(command, out var now);
            var localAction = _descriptor.ExposeExecutingInterceptor;
            localAction += specificAction;
            localAction?.Invoke(command.CommandText, command.Parameters, now);
        }

        private void OnExecuted<TState>(DbCommand command, DbCommandInterceptionContext<TState> interceptionContext,
            Func<string, DbParameterCollection, DateTime, DateTime, object> specificExecutedAction,
            Func<string, DbParameterCollection, DateTime, DateTime, object> specificLongTimeExecutedAction,
            Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> specificErrorAction,
            string memberName) {
            InternalLoggingSharedContext.RemoveStartTime(command, out var stamp);
            var now = DateTime.Now;
            var ms = 0D;
            if (stamp != default(DateTime)) {
                ms = now.Subtract(stamp).TotalMilliseconds;
            }

            var contextId = Guid.NewGuid();

            if (interceptionContext.Exception != null) {
                OnError(interceptionContext.Exception, command, contextId, stamp, now, ms, specificErrorAction, memberName);
            } else if (ms > 1000) {
                OnLongTimeExecuted(command, contextId, stamp, now, ms, specificLongTimeExecutedAction, memberName);
            } else {
                OnExecuted(command, contextId, stamp, now, ms, specificExecutedAction, memberName);
            }
        }

        private void OnError(Exception exception, DbCommand command, Guid contextId, DateTime start, DateTime now, double milliseconds,
            Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> specificErrorAction, string memberName) {
            var localFunc = _descriptor.ExposeErrorInterceptor;
            localFunc += specificErrorAction;
            var userInfo = localFunc?.Invoke(exception, command.CommandText, command.Parameters, start, now) ?? string.Empty;

            var logger = _loggingServiceProvider.GetLogger<DbContext>();
            var dbParams = new List<DbParam>();
            foreach (DbParameter param in command.Parameters) {
                dbParams.Add(new DbParam(param.ParameterName, param.Value, param.DbType));
            }

            var realExcepton = exception.Unwrap();
            var loggingParams = new {
                OrmName = Constants.SinkKey,
                ContextId = contextId,
                Sql = command.CommandText,
                SqlParams = dbParams,
                ExceptionType = exception.GetType(),
                ExceptionMessage = exception.Message,
                RealExceptionType = realExcepton.GetType(),
                RealExceptionMessage = realExcepton.Message,
                UsedTime = milliseconds,
                UserInfo = userInfo
            };
            logger.LogError(exception, OrmTemplateStandard.Error, loggingParams, memberName: memberName);
        }

        private void OnExecuted(DbCommand command, Guid contextId, DateTime start, DateTime now, double milliseconds,
            Func<string, DbParameterCollection, DateTime, DateTime, object> specificExecutedAction, string memberName) {
            var localFunc = _descriptor.ExposeExecutedInterceptor;
            localFunc += specificExecutedAction;
            var userInfo = localFunc?.Invoke(command.CommandText, command.Parameters, start, now) ?? string.Empty;

            var logger = _loggingServiceProvider.GetLogger<DbContext>();
            var loggingParams = new {
                OrmName = Constants.SinkKey,
                ContextId = contextId,
                Sql = command.CommandText,
                UsedTime = milliseconds,
                UserInfo = userInfo
            };
            logger.LogWarning(OrmTemplateStandard.Normal, loggingParams, memberName: memberName);
        }

        private void OnLongTimeExecuted(DbCommand command, Guid contextId, DateTime start, DateTime now, double milliseconds,
            Func<string, DbParameterCollection, DateTime, DateTime, object> specificLongTimeExecutedAction, string memberName) {
            var localFunc = _descriptor.ExposeLongTimeExecutedInterceptor;
            localFunc += specificLongTimeExecutedAction;
            var userInfo = localFunc?.Invoke(command.CommandText, command.Parameters, start, now) ?? string.Empty;

            var logger = _loggingServiceProvider.GetLogger<DbContext>();
            var dbParams = new List<DbParam>();
            foreach (DbParameter param in command.Parameters) {
                dbParams.Add(new DbParam(param.ParameterName, param.Value, param.DbType));
            }

            var loggingParams = new {
                OrmName = Constants.SinkKey,
                ContextId = contextId,
                Sql = command.CommandText,
                SqlParams = dbParams,
                UsedTime = milliseconds,
                UserInfo = userInfo
            };

            logger.LogInformation(OrmTemplateStandard.LongNormal, loggingParams, memberName: memberName);
        }
    }
}