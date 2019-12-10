using System;
using System.Data.Entity;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFramework.Core;

namespace Cosmos.Logging {
    /// <summary>
    /// Database extensions
    /// </summary>
    public static class DatabaseExtensions {
        internal static ILoggingServiceProvider LoggingServiceProvider { get; set; }
        internal static EfEnricherOptions Settings { get; set; }
        internal static Func<string, object> GlobalSimpleLoggingInterceptor { get; set; }

        /// <summary>
        /// Use Cosmos Logging
        /// </summary>
        /// <param name="db"></param>
        /// <param name="loggerAct"></param>
        public static void UseCosmosLogging(this Database db, Func<string, object> loggerAct = null) {
            UseCosmosLogging(db, null, loggerAct);
        }

        /// <summary>
        /// Use Cosmos Logging
        /// </summary>
        /// <param name="db"></param>
        /// <param name="filter"></param>
        /// <param name="loggerAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UseCosmosLogging(this Database db, Func<string, LogEventLevel, bool> filter, Func<string, object> loggerAct = null) {
            if (db is null) throw new ArgumentNullException(nameof(db));

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