﻿using System;
using Alexinea.EntityFrameworkCore.LoggingExposure;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFrameworkCore.Core;
using Microsoft.EntityFrameworkCore;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for DbContext
    /// </summary>
    public static class DatabaseExtensions {
        private static ILoggingServiceProvider LoggingServiceProvider => EfCoreInterceptorDescriptor.Instance.ExposeLoggingServiceProvider;
        private static EfCoreEnricherOptions Settings => EfCoreInterceptorDescriptor.Instance.ExposeSettings;
        private static Func<string, object> GlobalSimpleLoggingInterceptor => EfCoreInterceptorDescriptor.Instance.ExposeSettings.SimgleLoggingAction;
        private static RenderingConfiguration UpstreamRenderingOptions => EfCoreInterceptorDescriptor.Instance.ExposeSettings.GetRenderingOptions();

        /// <summary>
        /// Use Cosmos Logging for EntityFrameworkCore
        /// </summary>
        /// <param name="db"></param>
        /// <param name="loggerAct"></param>
        public static void UseCosmosLogging(this DbContext db, Func<string, object> loggerAct = null) {
            UseCosmosLogging(db, null, loggerAct);
        }

        /// <summary>
        /// Use Cosmos Logging for EntityFrameworkCore
        /// </summary>
        /// <param name="db"></param>
        /// <param name="filter"></param>
        /// <param name="loggerAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UseCosmosLogging(this DbContext db, Func<string, LogEventLevel, bool> filter, Func<string, object> loggerAct = null) {
            if (db is null) throw new ArgumentNullException(nameof(db));

            Func<string, LogEventLevel, bool> localFilter = (s, l) => (Settings?.Filter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true);

            var internalLogger = LoggingServiceProvider?.GetLogger<DbContext>(localFilter, LogEventSendMode.Automatic, UpstreamRenderingOptions);
            if (internalLogger == null) return;

            var localFunc = GlobalSimpleLoggingInterceptor;
            localFunc += loggerAct;

            var logger = new SimpleLogger(internalLogger, localFunc);

            db.ConfigureLogging(s => logger.WriteLog(s, db.Database.GetDbConnection().Database), (s, l) => localFilter.Invoke(s, LogLevelSwitcher.Switch(l)));
        }
    }
}