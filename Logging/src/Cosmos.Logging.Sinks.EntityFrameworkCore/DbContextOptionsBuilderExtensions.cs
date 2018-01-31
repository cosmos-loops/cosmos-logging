using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.EntityFrameworkCore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Sinks.EntityFrameworkCore {
    public static class DbContextOptionsBuilderExtensions {
        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(Logging.Core.StaticInstanceOfLoggingServiceProvider.Instance));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, Func<string, LogEventLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(Logging.Core.StaticInstanceOfLoggingServiceProvider.Instance, filter));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, Func<string, LogLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(Logging.Core.StaticInstanceOfLoggingServiceProvider.Instance, filter));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider,
            Func<string, LogEventLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider, filter));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider,
            Func<string, LogLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider, filter));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }
    }
}