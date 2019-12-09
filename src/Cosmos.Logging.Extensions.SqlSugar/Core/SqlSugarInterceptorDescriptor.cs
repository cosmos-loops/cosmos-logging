using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace Cosmos.Logging.Extensions.SqlSugar.Core {
    public class SqlSugarInterceptorDescriptor {
        private readonly SqlSugarEnricherOptions _settings;
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public SqlSugarInterceptorDescriptor(ILoggingServiceProvider loggingServiceProvider, IOptions<SqlSugarEnricherOptions> settings) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _settings = settings?.Value;
        }

        internal Action<Exception> ExposeErrorInterceptor => _settings?.ErrorInterceptorAction;
        internal Action<string, SugarParameter[]> ExposeExecutingInterceptor => _settings?.ExecutingInterceptorAction;
        internal Action<string, SugarParameter[]> ExposeExecutedInterceptor => _settings?.ExecutedInterceptorAction;

        internal Func<string, LogEventLevel, bool> ExposeGlobalFilter => _settings?.Filter;

        internal ILoggingServiceProvider ExposeLoggingServiceProvider => _loggingServiceProvider;

        internal RenderingConfiguration RenderingOptions => _settings?.GetRenderingOptions() ?? new RenderingConfiguration();
    }
}