using System;
using System.Data;

namespace Cosmos.Data.Dapper {
    public class DapperException : CosmosException {
        protected const string DEFAULT_DBCTX_FLAG = "__DAPPER_DBCTX_FLG";
        protected const string DEFAULT_DBCTX_ERROR_MESSAGE = "_DEFAULT_DAPPER_DBCONTEXT_ERROR";
        protected const long DEFAULT_DBCTX_ERROR_CODE = 200101;

        public DapperException()
            : this(null, DEFAULT_DBCTX_ERROR_CODE, DEFAULT_DBCTX_ERROR_MESSAGE, DEFAULT_DBCTX_FLAG) { }

        public DapperException(string errorMessage, Exception innerException = null)
            : this(null, DEFAULT_DBCTX_ERROR_CODE, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public DapperException(string errorMessage, string flag, Exception innerException = null)
            : this(null, DEFAULT_DBCTX_ERROR_CODE, errorMessage, flag, innerException) { }

        public DapperException(long errorCode, string errorMessage, Exception innerException = null)
            : this(null, errorCode, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public DapperException(long errorCode, string errorMessage, string flag, Exception innerException)
            : this(null, errorCode, errorMessage, flag, innerException) { }

        public DapperException(IDbConnection connection)
            : this(connection, DEFAULT_DBCTX_ERROR_CODE, DEFAULT_DBCTX_ERROR_MESSAGE, DEFAULT_DBCTX_FLAG) { }

        public DapperException(IDbConnection connection, string errorMessage, Exception innerException = null)
            : this(connection, DEFAULT_DBCTX_ERROR_CODE, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public DapperException(IDbConnection connection, string errorMessage, string flag, Exception innerException = null)
            : this(connection, DEFAULT_DBCTX_ERROR_CODE, errorMessage, flag, innerException) { }

        public DapperException(IDbConnection connection, long errorCode, string errorMessage, Exception innerException = null)
            : this(connection, errorCode, errorMessage, DEFAULT_DBCTX_FLAG, innerException) { }

        public DapperException(IDbConnection connection, long errorCode, string errorMessage, string flag, Exception innerException = null)
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