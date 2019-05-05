using System.Data;

namespace Cosmos.Logging.Extensions.EntityFramework.Core {
    public struct DbParam {
        public DbParam(string name, object value, DbType type) {
            ParameterName = name;
            Value = value;
            DbType = type;
        }

        public string ParameterName { get; }
        public object Value { get; }
        public DbType DbType { get; }
    }
}