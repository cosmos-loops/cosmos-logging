using System;
using System.Data;
using Cosmos.Data.Abstractions;

namespace Cosmos.Data.Dapper {
    internal static class DapperDbSessionCreator {
        public static TDbSession Create<TDbSession>(IDbConnection connection)
            where TDbSession : class, IDapperDbSession, IDapperDbSessionQueryProxy, IDbSession {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            Type typeOfCtx = typeof(TDbSession);
            Type[] typeArgs = {typeof(IDbConnection)};
            Type constructed = typeOfCtx.MakeGenericType(typeArgs);
            return Activator.CreateInstance(constructed, connection) as TDbSession;
        }
    }
}