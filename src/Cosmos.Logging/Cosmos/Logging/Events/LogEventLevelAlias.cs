using System.Collections.Generic;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Descriptive aliases for <see cref="LogEventLevel"/>.
    /// </summary>
    public static class LogEventLevelAlias {
        /// <summary>
        /// The least significant level of event.
        /// </summary>
        public const LogEventLevel Minimum = LogEventLevel.Verbose;

        /// <summary>
        /// The most significant level of event.
        /// </summary>
        public const LogEventLevel Maximum = LogEventLevel.Fatal;

        internal static Dictionary<LogEventLevel, string[]> InlineAlias = new Dictionary<LogEventLevel, string[]> {
            {LogEventLevel.Verbose, new[] {"V", "Vb", "Vrb", "Verb", LogEventLevelConstants.Verbose}},
            {LogEventLevel.Debug, new[] {"D", "De", "Dbg", "Dbug", LogEventLevelConstants.Debug}},
            {LogEventLevel.Information, new[] {"I", "In", "Inf", "Info", LogEventLevelConstants.Information}},
            {LogEventLevel.Warning, new[] {"W", "Wn", "Wrn", "Warn", LogEventLevelConstants.Warning}},
            {LogEventLevel.Error, new[] {"E", "Er", "Err", "Eror", LogEventLevelConstants.Error}},
            {LogEventLevel.Fatal, new[] {"F", "Fa", "Ftl", "Fatl", LogEventLevelConstants.Fatal}},
            {LogEventLevel.Off, new[] {"O", "Of", LogEventLevelConstants.Off}}
        };
    }
}