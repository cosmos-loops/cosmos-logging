using System;
using System.Data.Entity;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFramework.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class DatabaseExtensions {
        internal static ILoggingServiceProvider LoggingServiceProvider { get; set; }
        internal static EfEnricherOptions Settings { get; set; }
        internal static Func<string, object> GlobalSimpleLoggingInterceptor { get; set; }

        public static void UseCosmosLogging(this Database db, Func<string, object> loggerAct = null) {
            UseCosmosLogging(db, null, loggerAct);
        }

        public static void UseCosmosLogging(this Database db, Func<string, LogEventLevel, bool> filter, Func<string, object> loggerAct = null) {
            if (db == null) throw new ArgumentNullException(nameof(db));

            Func<string, LogEventLevel, bool> localFilter = (s, l) => (Settings?.Filter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true);

            var internalLogger = LoggingServiceProvider?.GetLogger<Database>(localFilter);
            if (internalLogger == null) return;

            var localFunc = GlobalSimpleLoggingInterceptor;
            localFunc += loggerAct;

            var logger = new SimpleLogger(internalLogger, localFunc);

            db.Log += s => logger.WriteLog(s, db.Connection.Database);
        }
    }
}