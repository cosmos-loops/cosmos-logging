using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Configurations {
    public interface ILoggingSinkOptions {
        string Key { get; }

        RendingConfiguration GetRenderingOptions();
    }

    public interface ILoggingSinkOptions<out TOptions> where TOptions : class, ILoggingSinkOptions, new() {

        #region Append log minimum level

        TOptions UseMinimumLevelForType<T>(LogEventLevel level);

        TOptions UseMinimumLevelForType(Type type, LogEventLevel level);

        TOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level);

        TOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level);

        TOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level);

        TOptions UseMinimumLevel(LogEventLevel? level);

        #endregion

        #region Append log level alias

        TOptions UseAlias(string alias, LogEventLevel level);

        #endregion

        #region Append output

        TOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled);

        TOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled);
        
        TOptions EnableDisplayingNewLineEom(bool? displayingNewLineEomEnabled);

        #endregion

    }
}