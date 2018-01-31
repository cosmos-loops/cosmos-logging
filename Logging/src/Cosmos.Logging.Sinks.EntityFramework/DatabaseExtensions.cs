using System;
using System.Data.Entity;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.EntityFramework.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class DatabaseExtensions {
        internal static ILoggingServiceProvider LoggingServiceProvider { get; set; }
        internal static Func<string, object> GlobalSimpleLogingInterceptor { get; set; }

        public static void UseSimgleSqlLogger(this Database db, Func<string, object> simgleLoggingAct = null) {
            UseSimgleSqlLogger(db, null, simgleLoggingAct);
        }

        public static void UseSimgleSqlLogger(this Database db, Func<string, LogEventLevel, bool> filter, Func<string, object> simgleLoggingAct = null) {
            if (db == null) throw new ArgumentNullException(nameof(db));

            var internalLogger = LoggingServiceProvider?.GetLogger<Database>(filter);
            if (internalLogger == null) return;

            var localFunc = GlobalSimpleLogingInterceptor;
            localFunc += simgleLoggingAct;

            var logger = new SimpleLogger(internalLogger, localFunc);

            db.Log += logger.WriteLog;
        }
    }
}