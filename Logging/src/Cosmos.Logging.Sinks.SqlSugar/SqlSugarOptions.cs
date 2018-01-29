using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.SqlSugar.Core;
using SqlSugar;

namespace Cosmos.Logging.Sinks.SqlSugar {
    public class SqlSugarOptions : ILoggingSinkOptions<SqlSugarOptions>, ILoggingSinkOptions {

        public SqlSugarOptions() { }

        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public SqlSugarOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public SqlSugarOptions UseMinimumLevelForNamespace(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForNamespace(@namespace, level);
        }

        public SqlSugarOptions UseMinimumLevelForNamespace(string @namespace, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
            @namespace = $"{@namespace}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(@namespace)) {
                InternalNavigatorLogEventLevels[@namespace] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(@namespace, level);
            }

            return this;
        }

        public SqlSugarOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public SqlSugarOptions UseAlias(string alias, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(alias)) return this;
            if (InternalAliases.ContainsKey(alias)) {
                InternalAliases[alias] = level;
            } else {
                InternalAliases.Add(alias, level);
            }

            return this;
        }

        #endregion

        #region Append Interceptor

        internal Action<Exception> ErrorInterceptorAction { get; set; }
        internal Action<string, SugarParameter[]> ExecutingInterceptorAction { get; set; }
        internal Action<string, SugarParameter[]> ExecutedInterceptorAction { get; set; }
        
        public SqlSugarOptions AddExecutingInterceptor(Action<string, SugarParameter[]> executingInterceptor) {
            ExecutingInterceptorAction += executingInterceptor ?? throw new ArgumentNullException(nameof(executingInterceptor));
            return this;
        }

        public SqlSugarOptions AddExecutedInterceptor(Action<string, SugarParameter[]> executedInterceptor) {
            ExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            return this;
        }

        public SqlSugarOptions AddErrorInterceptor(Action<Exception> errorInterceptor) {
            ErrorInterceptorAction += errorInterceptor ?? throw new ArgumentNullException(nameof(errorInterceptor));
            return this;
        }

        #endregion

    }
}