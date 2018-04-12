using System;
using System.Data;

namespace Cosmos.Data.EntityFrameworkCore {
    public class EfCoreException : CosmosException {
        protected const string DEFAULT_DBCTX_FLAG = "__EFCORE_DBCTX_FLG";
        protected const string DEFAULT_DBCTX_ERROR_MESSAGE = "_DEFAULT_EFCORE_DBCONTEXT_ERROR";
        protected const long DEFAULT_DBCTX_ERROR_CODE = 200101;

        public EfCoreException()
            : this(null, DEFAULT_DBCTX_ERROR_CODE, DEFAULT_DBCTX_ERROR_MESSAGE, DEFAULT_DBCTX_FLAG) { }

        public EfCoreException(string errorMessage, Exception innerException = null)
            : this(null, DEFAULT_DBCTX_ERROR_CODE, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public EfCoreException(string errorMessage, string flag, Exception innerException = null)
            : this(null, DEFAULT_DBCTX_ERROR_CODE, errorMessage, flag, innerException) { }

        public EfCoreException(long errorCode, string errorMessage, Exception innerException = null)
            : this(null, errorCode, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public EfCoreException(long errorCode, string errorMessage, string flag, Exception innerException)
            : this(null, errorCode, errorMessage, flag, innerException) { }

        public EfCoreException(IDbConnection connection)
            : this(connection, DEFAULT_DBCTX_ERROR_CODE, DEFAULT_DBCTX_ERROR_MESSAGE, DEFAULT_DBCTX_FLAG) { }

        public EfCoreException(IDbConnection connection, string errorMessage, Exception innerException = null)
            : this(connection, DEFAULT_DBCTX_ERROR_CODE, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public EfCoreException(IDbConnection connection, string errorMessage, string flag, Exception innerException = null)
            : this(connection, DEFAULT_DBCTX_ERROR_CODE, errorMessage, flag, innerException) { }

        public EfCoreException(IDbConnection connection, long errorCode, string errorMessage, Exception innerException = null)
            : this(connection, errorCode, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public EfCoreException(IDbConnection connection, long errorCode, string errorMessage, string flag, Exception innerException = null)
            : base(errorCode, errorMessage, flag, innerException) {
            if (connection != null) {
                Database = connection.Database;
                ConnectionString = connection.ConnectionString;
                ConnectionState = connection.State;
            }
        }

        public string Database { get; }

        public string ConnectionString { get; }

        public ConnectionState ConnectionState { get; }
    }
}