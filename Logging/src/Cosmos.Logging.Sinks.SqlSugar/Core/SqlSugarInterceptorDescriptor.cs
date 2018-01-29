using System;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace Cosmos.Logging.Sinks.SqlSugar.Core {
    public class SqlSugarInterceptorDescriptor {
        private readonly SqlSugarOptions _settings;
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public SqlSugarInterceptorDescriptor(ILoggingServiceProvider loggingServiceProvider, IOptions<SqlSugarOptions> settings) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _settings = settings?.Value;
        }

        internal Action<Exception> ExposeErrorInterceptor => _settings?.ErrorInterceptorAction;
        internal Action<string, SugarParameter[]> ExposeExecutingInterceptor => _settings?.ExecutingInterceptorAction;
        internal Action<string, SugarParameter[]> ExposeExecutedInterceptor => _settings?.ExecutedInterceptorAction;

        internal ILoggingServiceProvider ExposeLoggingServiceProvider => _loggingServiceProvider;
    }
}