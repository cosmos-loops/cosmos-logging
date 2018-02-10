using System;
using System.Web;
using Cosmos.Logging.Core;
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
            var logger = StaticInstanceOfLoggingServiceProvider.Instance.GetLogger<HttpApplication>();
            var paramObj = new {
                FxName = Constants.AspNetMvcName,
                UsedTime = Constants.Unknown,
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