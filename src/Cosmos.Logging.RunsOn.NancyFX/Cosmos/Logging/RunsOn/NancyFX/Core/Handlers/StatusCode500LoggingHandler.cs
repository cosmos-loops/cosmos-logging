using System;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.RunsOn.NancyFX.Core.Abstractions;
using Nancy;
using Nancy.ErrorHandling;

namespace Cosmos.Logging.RunsOn.NancyFX.Core.Handlers {
    /// <summary>
    /// 500 error logging handler
    /// </summary>
    public class StatusCode500LoggingHandler : IStatusCodeHandler, IErrorHandler {
        private readonly ILogger _logger = HandlerLoggerContainer.ErrorHandlerLogger<StatusCode500LoggingHandler>();

        /// <inheritdoc />
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context) {
            return statusCode >= HttpStatusCode.InternalServerError;
        }

        /// <inheritdoc />
        public void Handle(HttpStatusCode statusCode, NancyContext context) {
            if (context.Items.TryGetValue(NancyEngine.ERROR_EXCEPTION, out var errorObject) && errorObject is Exception exception) {
                _logger.LogFatal(exception, $"{(int) statusCode} - {exception.ToUnwrappedString()}");
            }
        }
    }
}