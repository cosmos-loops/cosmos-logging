using System;
using System.Diagnostics.CodeAnalysis;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.EntityFrameworkCore;
using Cosmos.Logging.Extensions.EntityFrameworkCore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class DbContextOptionsBuilderExtensions {
        private static ILoggingServiceProvider _loggingServiceProvider => EfCoreInterceptorDescriptor.Instance.ExposeLoggingServiceProvider;
        private static Func<string, LogEventLevel, bool> _globalFilter => EfCoreInterceptorDescriptor.Instance.ExposeSettings.Filter;
        private static RendingConfiguration UpstreamRenderingOptions => EfCoreInterceptorDescriptor.Instance.ExposeSettings.GetRenderingOptions();

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(_loggingServiceProvider, UpstreamRenderingOptions, _globalFilter));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, Func<string, LogEventLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(_loggingServiceProvider, UpstreamRenderingOptions,
                (s, l) => (_globalFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, Func<string, LogLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(_loggingServiceProvider, UpstreamRenderingOptions,
                (s, l) => (_globalFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, LogLevelSwitcher.Switch(l)) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider, UpstreamRenderingOptions));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider,
            Func<string, LogEventLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider, UpstreamRenderingOptions,
                (s, l) => (_globalFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, l) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }

        public static DbContextOptionsBuilder UseCosmosLogging(this DbContextOptionsBuilder builder, ILoggingServiceProvider loggingServiceProvider,
            Func<string, LogLevel, bool> filter) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EfCoreLoggerWrapperProvider(loggingServiceProvider, UpstreamRenderingOptions,
                (s, l) => (_globalFilter?.Invoke(s, l) ?? true) && (filter?.Invoke(s, LogLevelSwitcher.Switch(l)) ?? true)));
            builder.UseLoggerFactory(loggerFactory);

            return builder;
        }
    }
}