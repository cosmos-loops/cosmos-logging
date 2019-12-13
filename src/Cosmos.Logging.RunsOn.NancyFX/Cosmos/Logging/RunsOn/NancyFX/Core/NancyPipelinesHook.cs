using System;
using System.Diagnostics;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.MessageTemplates.PresetTemplates;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Extensions;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    /// <summary>
    /// NancyFX pipeline hook
    /// </summary>
    public static class NancyPipelinesHook {

        // ReSharper disable once InconsistentNaming
        private static readonly ILogger _logger = StaticServiceResolver.Instance.GetLogger<IPipelines>();

        /// <summary>
        /// Register logging handlers
        /// </summary>
        /// <param name="pipelines"></param>
        public static void RegisterLoggingHandlers(IPipelines pipelines) {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(BeforeHandler);
            pipelines.AfterRequest.AddItemToEndOfPipeline(AfterHandler);
        }

        /// <summary>
        /// Stop watch key
        /// </summary>
        public const string StopWatchKey = "__COSMOS_NANFYFX_CTXTSW";

        /// <summary>
        /// NancyFX name
        /// </summary>
        public const string NancyFxName = "NancyFX";


        private static Func<NancyContext, Response> BeforeHandler = ctx => {
            ctx.Items.Add(StopWatchKey, new Stopwatch());
            return null;
        };

        private static Action<NancyContext> AfterHandler = ctx => {
            var timePin = 0L;
            if (ctx.Items.ContainsKey(StopWatchKey)) {
                var time = ctx.Items[StopWatchKey] as Stopwatch;
                time?.Stop();
                timePin = time?.ElapsedMilliseconds ?? 0L;
            }

            var statusCode = (int) ctx.Response.StatusCode;

            if (statusCode >= 400 && statusCode < 500) {
                Exception exception;
                string exceptionDetail = string.Empty;
                if (ctx.TryGetException(out exception)) {
                    exceptionDetail = ctx.GetExceptionDetails();
                }

                var paramObj = new {
                    FxName = NancyFxName,
                    UsedTime = $"{timePin} ms",
                    StatusCode = statusCode,
                    ExceptionDetails = exceptionDetail
                };
                _logger.LogWarning(exception, WebTemplateStandard.WebLog400, paramObj, o => o.AddNancyContext(ctx));
            }
            else if (statusCode >= 500) {
                Exception exception;
                string exceptionDetail = string.Empty;
                if (ctx.TryGetException(out exception)) {
                    exceptionDetail = ctx.GetExceptionDetails();
                }

                var realException = exception.Unwrap();
                var paramObj = new {
                    FxName = NancyFxName,
                    UsedTime = $"{timePin} ms",
                    StatusCode = statusCode,
                    ExceptionDetails = exceptionDetail,
                    ExceptionType = exception.GetType(),
                    ExceptionMessage = exception.Message,
                    RealExceptionType = realException.GetType(),
                    RealExceptionMessage = realException.Message,
                };
                _logger.LogFatal(exception, WebTemplateStandard.WebLog500, paramObj, o => o.AddNancyContext(ctx));
            }
            else {
                var paramObj = new {
                    FxName = NancyFxName,
                    UsedTime = $"{timePin} ms",
                    StatusCode = statusCode
                };
                _logger.LogInformation(WebTemplateStandard.Normal, paramObj, o => o.AddNancyContext(ctx));
            }
        };
    }
}