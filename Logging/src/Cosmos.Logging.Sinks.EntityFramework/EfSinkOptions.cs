using System;
using System.Collections.Generic;
using System.Data.Common;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.EntityFramework.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class EfSinkOptions : ILoggingSinkOptions<EfSinkOptions>, ILoggingSinkOptions {

        public EfSinkOptions() { }

        public string Key => Constants.SinkKey;

        #region Append log minimum level

        internal readonly Dictionary<string, LogEventLevel> InternalNavigatorLogEventLevels = new Dictionary<string, LogEventLevel>();

        internal LogEventLevel? MinimumLevel { get; set; }

        public EfSinkOptions UseMinimumLevelForType<T>(LogEventLevel level) => UseMinimumLevelForType(typeof(T), level);

        public EfSinkOptions UseMinimumLevelForType(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var typeName = TypeNameHelper.GetTypeDisplayName(type);
            if (InternalNavigatorLogEventLevels.ContainsKey(typeName)) {
                InternalNavigatorLogEventLevels[typeName] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(typeName, level);
            }

            return this;
        }

        public EfSinkOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level) => UseMinimumLevelForCategoryName(typeof(T), level);

        public EfSinkOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var @namespace = type.Namespace;
            return UseMinimumLevelForCategoryName(@namespace, level);
        }

        public EfSinkOptions UseMinimumLevelForCategoryName(string @namespace, LogEventLevel level) {
            if (string.IsNullOrWhiteSpace(@namespace)) throw new ArgumentNullException(nameof(@namespace));
            @namespace = $"{@namespace}.*";
            if (InternalNavigatorLogEventLevels.ContainsKey(@namespace)) {
                InternalNavigatorLogEventLevels[@namespace] = level;
            } else {
                InternalNavigatorLogEventLevels.Add(@namespace, level);
            }

            return this;
        }

        public EfSinkOptions UseMinimumLevel(LogEventLevel? level) {
            MinimumLevel = level;
            return this;
        }

        #endregion

        #region Append log level alias

        internal readonly Dictionary<string, LogEventLevel> InternalAliases = new Dictionary<string, LogEventLevel>();

        public EfSinkOptions UseAlias(string alias, LogEventLevel level) {
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

        internal Func<string, object> SimgleLoggingAction { get; set; }

        public EfSinkOptions AddSimpleLoggingInterceptor(Func<string, object> simpleLoggingInterceptor) {
            SimgleLoggingAction += simpleLoggingInterceptor;
            return this;
        }


        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ErrorInterceptorAction { get; set; }
        internal Action<string, DbParameterCollection, DateTime> ExecutingInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ExecutedInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> LongTimeExecutedInterceptorAction { get; set; }

        public EfSinkOptions AddExecutingInterceptor(Action<string, DbParameterCollection, DateTime> executingInterceptor) {
            ExecutingInterceptorAction += executingInterceptor ?? throw new ArgumentNullException(nameof(executingInterceptor));
            return this;
        }

        public EfSinkOptions AddExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor) {
            ExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            return this;
        }

        public EfSinkOptions AddLongTimeExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor, bool asAppend = false) {
            LongTimeExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            if (asAppend) {
                AddExecutedInterceptor(executedInterceptor);
            }

            return this;
        }

        public EfSinkOptions AddErrorInterceptor(Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> errorInterceptor) {
            ErrorInterceptorAction += errorInterceptor ?? throw new ArgumentNullException(nameof(errorInterceptor));
            return this;
        }


        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> NonQueryErrorInterceptorAction { get; set; }
        internal Action<string, DbParameterCollection, DateTime> NonQueryExecutingInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> NonQueryExecutedInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> NonQueryLongTimeExecutedInterceptorAction { get; set; }

        public EfSinkOptions AddNonQueryExecutingInterceptor(Action<string, DbParameterCollection, DateTime> executingInterceptor) {
            NonQueryExecutingInterceptorAction += executingInterceptor ?? throw new ArgumentNullException(nameof(executingInterceptor));
            return this;
        }

        public EfSinkOptions AddNonQueryExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor) {
            NonQueryExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            return this;
        }

        public EfSinkOptions AddNonQueryLongTimeExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor, bool asAppend = false) {
            NonQueryLongTimeExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            if (asAppend) {
                AddNonQueryExecutedInterceptor(executedInterceptor);
            }

            return this;
        }

        public EfSinkOptions AddNonQueryErrorInterceptor(Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> errorInterceptor) {
            NonQueryErrorInterceptorAction += errorInterceptor ?? throw new ArgumentNullException(nameof(errorInterceptor));
            return this;
        }


        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ReaderErrorInterceptorAction { get; set; }
        internal Action<string, DbParameterCollection, DateTime> ReaderExecutingInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ReaderExecutedInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ReaderLongTimeExecutedInterceptorAction { get; set; }

        public EfSinkOptions AddReaderExecutingInterceptor(Action<string, DbParameterCollection, DateTime> executingInterceptor) {
            ReaderExecutingInterceptorAction += executingInterceptor ?? throw new ArgumentNullException(nameof(executingInterceptor));
            return this;
        }

        public EfSinkOptions AddReaderExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor) {
            ReaderExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            return this;
        }

        public EfSinkOptions AddReaderLongTimeExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor, bool asAppend = false) {
            ReaderLongTimeExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            if (asAppend) {
                AddReaderExecutedInterceptor(executedInterceptor);
            }

            return this;
        }

        public EfSinkOptions AddReaderErrorInterceptor(Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> errorInterceptor) {
            ReaderErrorInterceptorAction += errorInterceptor ?? throw new ArgumentNullException(nameof(errorInterceptor));
            return this;
        }


        internal Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> ScalarErrorInterceptorAction { get; set; }
        internal Action<string, DbParameterCollection, DateTime> ScalarExecutingInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ScalarExecutedInterceptorAction { get; set; }
        internal Func<string, DbParameterCollection, DateTime, DateTime, object> ScalarLongTimeExecutedInterceptorAction { get; set; }

        public EfSinkOptions AddScalarExecutingInterceptor(Action<string, DbParameterCollection, DateTime> executingInterceptor) {
            ScalarExecutingInterceptorAction += executingInterceptor ?? throw new ArgumentNullException(nameof(executingInterceptor));
            return this;
        }

        public EfSinkOptions AddScalarExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor) {
            ScalarExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            return this;
        }

        public EfSinkOptions AddScalarLongTimeExecutedInterceptor(Func<string, DbParameterCollection, DateTime, DateTime, object> executedInterceptor, bool asAppend = false) {
            ScalarLongTimeExecutedInterceptorAction += executedInterceptor ?? throw new ArgumentNullException(nameof(executedInterceptor));
            if (asAppend) {
                AddScalarExecutedInterceptor(executedInterceptor);
            }

            return this;
        }

        public EfSinkOptions AddScalarErrorInterceptor(Func<Exception, string, DbParameterCollection, DateTime, DateTime, object> errorInterceptor) {
            ScalarErrorInterceptorAction += errorInterceptor ?? throw new ArgumentNullException(nameof(errorInterceptor));
            return this;
        }

        #endregion
        
        #region Appeng filter

        internal Func<string, LogEventLevel, bool> Filter { get; set; }

        public EfSinkOptions UseFilter(Func<string, LogEventLevel, bool> filter) {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var temp = Filter;
            Filter = (s, l) => (temp?.Invoke(s, l) ?? true) && filter(s, l);

            return this;
        }

        #endregion

    }
}