using System.Web;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.TemplateStandards;

namespace Cosmos.Logging.RunsOn.AspNet.Core.Handlers {
    internal static class InternalServerErrorLoggingHandler {
        public static void Handle(HttpApplication application) {
            if (application == null) return;

            var logger = StaticServiceResolver.Instance.GetLogger<HttpApplication>();

            var exception = application.Server.GetLastError();
            var statusCode = application.Response.StatusCode;
            if (statusCode >= 500) {
                var realException = exception.Unwrap();
                var paramObj = new {
                    FxName = Constants.AspNetMvcName,
                    UsedTime = Constants.Unknown,
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
                    UsedTime = Constants.Unknown,
                    StatusCode = statusCode,
                    ExceptionDetails = exception.Message
                };
                logger.LogError(exception, WebTemplateStandard.WebLog400, paramObj);
            } else {
                InternalLogger.WriteLine("Status code should not less than 400 when occurred error.");
            }

        }
    }
}