using System;
using System.Web;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.TemplateStandards;

namespace Cosmos.Logging.RunsOn.AspNet.Core.Handlers {
    internal static class MvcTraceLoggingHandler {
        private const string TimeKey = "__CosmosLoops.AspNetMvcExtraScope_Current__";
        public static void OnStartHandle(HttpApplication application) {
            if (application == null) return;
            application.Context.Items[TimeKey] = DateTime.Now;
        }

        public static void OnEndHandle(HttpApplication application) {
            if (application == null) return;
            var ms = application.Context.Items[TimeKey] is DateTime stamp ? DateTime.Now.Subtract(stamp).TotalMilliseconds : 0L;
            application.Context.Items.Remove(TimeKey);
            var logger = StaticServiceResolver.Instance.GetLogger<HttpApplication>();
            var exception = application.Server.GetLastError();
            if (exception != null) {
                var statusCode = application.Response.StatusCode;
                if (statusCode >= 500) {
                    var realException = exception.Unwrap();
                    var paramObj = new {
                        FxName = Constants.AspNetMvcName,
                        UsedTime =  $"{ms} ms",
                        StatusCode = statusCode,
                        ExceptionDetails = exception.Message,
                        ExceptionType = exception.GetType(),
                        ExceptionMessage = exception.Message,
                        RealExceptionType = realException.GetType(),
                        RealExceptionMessage = realException.Message,
                    };
                    logger.LogFatal(exception, WebTemplateStandard.WebLog500, paramObj);
                } else if (statusCode >= 400) {
                    var paramObj = new {
                        FxName = Constants.AspNetMvcName,
                        UsedTime =  $"{ms} ms",
                        StatusCode = statusCode,
                        ExceptionDetails = exception.Message
                    };
                    logger.LogError(exception, WebTemplateStandard.WebLog400, paramObj);
                } else {
                    InternalLogger.WriteLine("Status code should not less than 400 when occurred error.");
                }
            } else {
                var paramObj = new {
                    FxName = Constants.AspNetMvcName,
                    UsedTime = $"{ms} ms",
                    StatusCode = application.Response.StatusCode,
                    ExceptionDetails = Constants.Null
                };
                if (ms > 1000) {
                    logger.LogWarning(WebTemplateStandard.LongNormal, paramObj);
                } else {
                    logger.LogDebug(WebTemplateStandard.Normal, paramObj);
                }
            }
        }
    }
}