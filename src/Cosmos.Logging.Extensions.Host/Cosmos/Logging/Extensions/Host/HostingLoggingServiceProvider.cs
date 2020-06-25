using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Cosmos.Logging.Extensions.Host {
    /// <summary>
    /// Hosting logging service provider
    /// </summary>
    public class HostingLoggingServiceProvider : StandardLogServiceProvider {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Create a new instance of <see cref="StandardLogServiceProvider"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="loggingConfiguration"></param>
        /// <param name="httpContextAccessor"></param>
        public HostingLoggingServiceProvider(IServiceProvider provider, LoggingConfiguration loggingConfiguration,
            IHttpContextAccessor httpContextAccessor) : base(provider, loggingConfiguration) {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get logger core
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="categoryName"></param>
        /// <param name="level"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        protected override ILogger GetLoggerCore(Type sourceType, string categoryName, LogEventLevel? level, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, RenderingConfiguration renderingOptions = null) {
            var loggerStateNamespace = sourceType == null ? categoryName : TypeNameHelper.GetTypeDisplayName(sourceType);
            var minLevel = level ?? _loggingConfiguration.GetMinimumLevel(loggerStateNamespace);
            return new HostingLogger(sourceType ?? typeof(object), minLevel, loggerStateNamespace, filter, mode,
                _loggingConfiguration.Rendering.ToCalc(renderingOptions),
                new LogPayloadSender(_logPayloadClientProviders), _httpContextAccessor);
        }
    }
}