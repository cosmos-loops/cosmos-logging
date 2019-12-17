using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.Microsoft.Core;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Extensions.Microsoft {
    /// <summary>
    /// Microsoft Logging Wrapper Provider
    /// </summary>
    public class MicrosoftLoggerWrapperProvider : ILoggerProvider {

        private readonly ILoggingServiceProvider _loggingServiceProvider;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (cat, level) => true;
        private static readonly Func<string, LogEventLevel, bool> FalseFilter = (cat, level) => false;

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggerWrapperProvider"/>.
        /// </summary>
        /// <param name="loggingServiceProvider"></param>
        public MicrosoftLoggerWrapperProvider(ILoggingServiceProvider loggingServiceProvider) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
        }

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggerWrapperProvider"/>.
        /// </summary>
        /// <param name="loggingServiceProvider"></param>
        /// <param name="filter"></param>
        public MicrosoftLoggerWrapperProvider(ILoggingServiceProvider loggingServiceProvider, Func<string, LogEventLevel, bool> filter) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _filter = filter ?? TrueFilter;
        }

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggerWrapperProvider"/>.
        /// </summary>
        /// <param name="loggingServiceProvider"></param>
        /// <param name="filter"></param>
        public MicrosoftLoggerWrapperProvider(ILoggingServiceProvider loggingServiceProvider, Func<string, LogLevel, bool> filter) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _filter = As(filter) ?? TrueFilter;
        }

        /// <inheritdoc />
        public global::Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName) {
            return new MicrosoftLoggerWrapper(_loggingServiceProvider.GetLogger(categoryName));
        }

        /// <inheritdoc />
        public void Dispose() { }

        private static Func<string, LogEventLevel, bool> As(Func<string, LogLevel, bool> originFilter) {
            if (originFilter == null) return null;
            return (s, l) => originFilter(s, LogLevelSwitcher.Switch(l));
        }
    }
}