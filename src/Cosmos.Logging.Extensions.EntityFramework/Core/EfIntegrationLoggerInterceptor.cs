using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Cosmos.Logging.Extensions.EntityFramework.Core {
    public partial class EfIntegrationLoggerInterceptor : IDbCommandInterceptor {
        private readonly ILoggingServiceProvider _loggingServiceProvider;
        private readonly EfInterceptorDescriptor _descriptor;

        internal EfIntegrationLoggerInterceptor(EfInterceptorDescriptor descriptor) {
            _descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
            _loggingServiceProvider = descriptor.ExposeLoggingServiceProvider;
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            OnExecuted(command, interceptionContext,
                _descriptor.ExposeNonQueryExecutedInterceptor,
                _descriptor.ExposeNonQueryLongTimeExecutedInterceptor,
                _descriptor.ExposeNonQueryErrorInterceptor,
                "NonQueryExecuted");
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            OnExecuting(command, _descriptor.ExposeNonQueryExecutingInterceptor);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
            OnExecuted(command, interceptionContext,
                _descriptor.ExposeReaderExecutedInterceptor,
                _descriptor.ExposeReaderLongTimeExecutedInterceptor,
                _descriptor.ExposeReaderErrorInterceptor,
                "ReaderExecuted");
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
            OnExecuting(command, _descriptor.ExposeReaderExecutingInterceptor);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            OnExecuted(command, interceptionContext,
                _descriptor.ExposeScalarExecutedInterceptor,
                _descriptor.ExposeScalarLongTimeExecutedInterceptor,
                _descriptor.ExposeScalarErrorInterceptor,
                "ScalarExecuted");
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            OnExecuting(command, _descriptor.ExposeScalarExecutingInterceptor);
        }
    }
}