using System;
using System.Data.Common;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Extensions.EntityFramework.Core {
    internal class EfInterceptorDescriptor {
        private readonly EfEnricherOptions _settings;
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public EfInterceptorDescriptor(ILoggingServiceProvider loggingServiceProvider, IOptions<EfEnricherOptions> settings) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _settings = settings?.Value;
        }

        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ExposeErrorInterceptor => _settings?.ErrorInterceptorAction;
        internal Action<string, DbParameterCollection, DateTime> ExposeExecutingInterceptor => _settings?.ExecutingInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeExecutedInterceptor => _settings?.ExecutedInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeLongTimeExecutedInterceptor => _settings?.LongTimeExecutedInterceptorAction;

        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ExposeNonQueryErrorInterceptor => _settings?.NonQueryErrorInterceptorAction;
        internal Action<string, DbParameterCollection, DateTime> ExposeNonQueryExecutingInterceptor => _settings?.NonQueryExecutingInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeNonQueryExecutedInterceptor => _settings?.NonQueryExecutedInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeNonQueryLongTimeExecutedInterceptor => _settings?.NonQueryLongTimeExecutedInterceptorAction;

        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ExposeReaderErrorInterceptor => _settings?.ReaderErrorInterceptorAction;
        internal Action<string, DbParameterCollection, DateTime> ExposeReaderExecutingInterceptor => _settings?.ReaderExecutingInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeReaderExecutedInterceptor => _settings?.ReaderExecutedInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeReaderLongTimeExecutedInterceptor => _settings?.ReaderLongTimeExecutedInterceptorAction;

        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ExposeScalarErrorInterceptor => _settings?.ScalarErrorInterceptorAction;
        internal Action<string, DbParameterCollection, DateTime> ExposeScalarExecutingInterceptor => _settings?.ScalarExecutingInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeScalarExecutedInterceptor => _settings?.ScalarExecutedInterceptorAction;
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExposeScalarLongTimeExecutedInterceptor => _settings?.ScalarLongTimeExecutedInterceptorAction;

        internal ILoggingServiceProvider ExposeLoggingServiceProvider => _loggingServiceProvider;

        internal EfEnricherOptions ExposeSettings => _settings;
    }
}