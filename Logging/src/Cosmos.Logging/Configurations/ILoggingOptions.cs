using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public interface ILoggingOptions {

        #region Append log minimum level

        LoggingOptions UseMinimumLevelForType<T>(LogEventLevel level);

        LoggingOptions UseMinimumLevelForType(Type type, LogEventLevel level);

        LoggingOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level);

        LoggingOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level);

        LoggingOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level);

        LoggingOptions UseMinimumLevel(LogEventLevel? level);

        #endregion

        #region Append log level alias

        LoggingOptions UseAlias(string alias, LogEventLevel level);

        #endregion

        #region Append output

        LoggingOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled);

        LoggingOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled);

        LoggingOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled);

        #endregion

        Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }
    }
}