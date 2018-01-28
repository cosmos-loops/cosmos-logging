using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public interface ILoggingOptions {

        #region Append log minimum level

        LoggingOptions UseMinimumLevelForType(Type type, LogEventLevel level);

        LoggingOptions UseMinimumLevelForNamespace(Type type, LogEventLevel level);

        LoggingOptions UseMinimumLevelForNamespace(string @namespace, LogEventLevel level);

        LoggingOptions UseMinimumLevel(LogEventLevel? level);

        #endregion

        #region Append log level alias

        LoggingOptions UseAlias(string alias, LogEventLevel level);

        #endregion

        Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }
    }
}