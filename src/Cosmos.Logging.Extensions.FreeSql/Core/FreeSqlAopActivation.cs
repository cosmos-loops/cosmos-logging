using System;
using System.Linq;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates.PresetTemplates;
using FreeSql;
using FreeSql.Aop;

namespace Cosmos.Logging.Extensions.FreeSql.Core
{
    internal static class FreeSqlAopActivation
    {
        public static void RegisterToFreeSql(IFreeSql freeSql, FreeSqlInterceptorDescriptor descriptor,
            Action<CurdBeforeEventArgs> executingAct = null,
            Func<CurdAfterEventArgs, object> executedAct = null,
            Func<Exception, CurdAfterEventArgs, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null)
        {
            if (freeSql == null)
                throw new ArgumentNullException(nameof(freeSql));

            var pinBefore = freeSql.Aop.CurdBefore;
            var pinAfter = freeSql.Aop.CurdAfter;

            pinBefore += (s, e) => descriptor.ExposeExecutingInterceptor?.Invoke(e);
            pinAfter += (s, e) =>
            {
                if (e.Exception == null)
                    descriptor.ExposeExecutedInterceptor?.Invoke(e);
                else
                    descriptor.ExposeErrorInterceptor?.Invoke(e.Exception, e);
            };

            Func<string, LogEventLevel, bool> localFilter = (s, l) => (descriptor.ExposeGlobalFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true);

            pinBefore += (s, e) => InternalExecutingOpt(e, executingAct);
            pinAfter += (s, e) => InternalExecutedOpt(descriptor, e, executedAct, errorAct, localFilter);

            freeSql.Aop.CurdBefore = pinBefore;
            freeSql.Aop.CurdAfter = pinAfter;
        }

        private static void InternalExecutingOpt(CurdBeforeEventArgs args,
            Action<CurdBeforeEventArgs> executingAct = null)
        {
            executingAct?.Invoke(args);
        }

        private static void InternalExecutedOpt(FreeSqlInterceptorDescriptor descriptor, CurdAfterEventArgs args,
            Func<CurdAfterEventArgs, object> executedAct = null,
            Func<Exception, CurdAfterEventArgs, object> errorAct = null,
            Func<string, LogEventLevel, bool> filter = null)
        {
            object loggingParams;
            var errorFlag = args.Exception != null;
            var userInfo = errorFlag
                ? errorAct?.Invoke(args.Exception, args) ?? string.Empty
                : executedAct?.Invoke(args) ?? string.Empty;
            var logger = descriptor.ExposeLoggingServiceProvider.GetLogger<IAdo>(filter, LogEventSendMode.Automatic, descriptor.RenderingOptions);

            if (!errorFlag && args.ElapsedMilliseconds > 1000)
            {
                if (!logger.IsEnabled(LogEventLevel.Warning))
                    return;

                var eventId = new LogEventId(args.Identifier, EventIdKeys.LongTimeExecuted);
                loggingParams = new
                {
                    OrmName = Constants.SinkKey,
                    ContextId = args.Identifier,
                    args.Sql,
                    SqlParams = args.DbParms.Select(param => new DbParam(param.ParameterName, param.Value, param.DbType)).ToList(),
                    UsedTime = args.ElapsedMilliseconds,
                    UserInfo = userInfo
                };
                logger.LogWarning(eventId, OrmTemplateStandard.LongNormal, loggingParams);
            }
            else if (!errorFlag)
            {
                if (!logger.IsEnabled(LogEventLevel.Information))
                    return;

                var eventId = new LogEventId(args.Identifier, EventIdKeys.Executed);
                loggingParams = new
                {
                    OrmName = Constants.SinkKey,
                    ContextId = args.Identifier,
                    args.Sql,
                    UsedTime = args.ElapsedMilliseconds,
                    UserInfo = userInfo
                };
                logger.LogInformation(eventId, OrmTemplateStandard.Normal, loggingParams);
            }
            else
            {
                if (!logger.IsEnabled(LogEventLevel.Error))
                    return;

                var eventId = new LogEventId(args.Identifier, EventIdKeys.Error);
                var exception = args.Exception;
                var realException = exception.Unwrap();

                loggingParams = new
                {
                    OrmName = Constants.SinkKey,
                    ContextId = args.Identifier,
                    args.Sql,
                    SqlParams = args.DbParms.Select(param => new DbParam(param.ParameterName, param.Value, param.DbType)).ToList(),
                    ExceptionType = exception.GetType(),
                    ExceptionMessage = exception.Message,
                    RealExceptionType = realException.GetType(),
                    RealExceptionMessage = realException.Message,
                    UsedTime = args.ElapsedMilliseconds,
                    UserInfo = userInfo
                };
                logger.LogError(eventId, exception, OrmTemplateStandard.Error, loggingParams);
            }
        }
    }
}