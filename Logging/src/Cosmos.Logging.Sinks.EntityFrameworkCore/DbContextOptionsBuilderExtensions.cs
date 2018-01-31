using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.EntityFrameworkCore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Sinks.EntityFrameworkCore {
    public static class DbContextOptionsBuilderExtensions {
        private static ILoggingServiceProvider _loggingServiceProvider => EfCoreInterceptorDescriptor.Instance.ExposeLoggingServiceProvider;
        private static Func<string, LogEventLevel, bool> _gloablFilter => EfCoreInterceptorDescriptor.Instance.ExposeSettings.Filter;

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(_loggingServiceProvider, _gloablFilter));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, Func<string, LogEventLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(_loggingServiceProvider,
                (s, l) => (_gloablFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, Func<string, LogLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(_loggingServiceProvider,
                (s, l) => (_gloablFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, LogLevelSwitcher.Switch(l)) ?? true)));
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
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider, 
                (s, l) => (_gloablFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider,
            Func<string, LogLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider,
                (s, l) => (_gloablFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, LogLevelSwitcher.Switch(l)) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }
    }
}