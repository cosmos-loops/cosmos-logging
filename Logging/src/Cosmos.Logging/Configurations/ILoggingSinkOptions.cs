using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public interface ILoggingSinkOptions {
        string Key { get; }
    }

    public interface ILoggingSinkOptions<out TOptions> where TOptions : class, ILoggingSinkOptions, new() {

        #region Append log minimum level

        TOptions UseMinimumLevelForType(Type type, LogEventLevel level);

        TOptions UseMinimumLevelForNamespace(Type type, LogEventLevel level);

        TOptions UseMinimumLevelForNamespace(string @namespace, LogEventLevel level);

        TOptions UseMinimumLevel(LogEventLevel? level);

        #endregion
        
        #region Append log level alias

        TOptions UseAlias(string alias, LogEventLevel level);

        #endregion

    }
}