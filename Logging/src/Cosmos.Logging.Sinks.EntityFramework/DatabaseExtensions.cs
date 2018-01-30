using System;
using System.Data.Entity;
using Cosmos.Logging.Sinks.EntityFramework.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class DatabaseExtensions {
        internal static ILoggingServiceProvider LoggingServiceProvider { get; set; }
        internal static Func<string, object> GlobalSimpleLogingInterceptor { get; set; }

        public static void UseSimgleSqlLogger(this Database db, Func<string, object> simgleLoggingAct = null) {
            if (db == null) throw new ArgumentNullException(nameof(db));

            var internalLogger = LoggingServiceProvider?.GetLogger<Database>();
            if (internalLogger == null) return;

            var localFunc = GlobalSimpleLogingInterceptor;
            localFunc += simgleLoggingAct;

            var logger = new SimpleLogger(internalLogger, localFunc);

            db.Log += logger.WriteLog;
        }
    }
}