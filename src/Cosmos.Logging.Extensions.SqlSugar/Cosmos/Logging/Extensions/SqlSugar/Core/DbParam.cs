using System.Data;

namespace Cosmos.Logging.Extensions.SqlSugar.Core {
    /// <summary>
    /// Database parameter
    /// </summary>
    public struct DbParam {
        /// <summary>
        /// Create a new instance of Database parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public DbParam(string name, object value, DbType type) {
            ParameterName = name;
            Value = value;
            DbType = type;
        }

        /// <summary>
        /// Parameter name
        /// </summary>
        public string ParameterName { get; }

        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// DbType
        /// </summary>
        public DbType DbType { get; }
    }
}