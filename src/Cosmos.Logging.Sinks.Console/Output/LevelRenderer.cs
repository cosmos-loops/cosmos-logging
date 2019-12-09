using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Output;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output
{
    public class LevelRenderer : BaseOutputRenderer<LogEventLevel>
    {
        public LevelRenderer(PropertyToken token, LogEventLevel body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        private PropertyToken _levelToken { get; }

        public override int Render(LogEvent logEvent)
        {
            var moniker = LevelOutputFormat.GetLevelMoniker(logEvent.Level, _levelToken.Format);

            if (!Levels.TryGetValue(logEvent.Level, out var levelStyle))
                levelStyle = ConsoleThemeStyle.Invalid;

            var _ = 0;

            //todo something


            return _;
        }

        static readonly Dictionary<LogEventLevel, ConsoleThemeStyle> Levels = new Dictionary<LogEventLevel, ConsoleThemeStyle>
        {
            {LogEventLevel.Verbose, ConsoleThemeStyle.LevelVerbose},
            {LogEventLevel.Debug, ConsoleThemeStyle.LevelDebug},
            {LogEventLevel.Information, ConsoleThemeStyle.LevelInformation},
            {LogEventLevel.Warning, ConsoleThemeStyle.LevelWarning},
            {LogEventLevel.Error, ConsoleThemeStyle.LevelError},
            {LogEventLevel.Fatal, ConsoleThemeStyle.LevelFatal},
        };
    }
}