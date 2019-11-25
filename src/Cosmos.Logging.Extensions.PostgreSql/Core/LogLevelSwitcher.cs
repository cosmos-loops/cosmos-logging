using Cosmos.Logging.Events;
using Npgsql.Logging;

namespace Cosmos.Logging.Extensions.PostgreSql.Core
{
    internal static class LogLevelSwitcher
    {
        public static NpgsqlLogLevel Switch(LogEventLevel level)
        {
            switch (level)
            {
                case LogEventLevel.Verbose: return NpgsqlLogLevel.Trace;
                case LogEventLevel.Debug: return NpgsqlLogLevel.Debug;
                case LogEventLevel.Information: return NpgsqlLogLevel.Info;
                case LogEventLevel.Warning: return NpgsqlLogLevel.Warn;
                case LogEventLevel.Error: return NpgsqlLogLevel.Error;
                case LogEventLevel.Fatal: return NpgsqlLogLevel.Fatal;
                case LogEventLevel.Off: return NpgsqlLogLevel.Fatal;
                default: return NpgsqlLogLevel.Fatal;
            }
        }

        public static LogEventLevel Switch(NpgsqlLogLevel? level)
        {
            if (level == null)
                return LogEventLevel.Off;

            switch (level.Value)
            {
                case NpgsqlLogLevel.Trace: return LogEventLevel.Verbose;
                case NpgsqlLogLevel.Debug: return LogEventLevel.Debug;
                case NpgsqlLogLevel.Info: return LogEventLevel.Information;
                case NpgsqlLogLevel.Warn: return LogEventLevel.Warning;
                case NpgsqlLogLevel.Error: return LogEventLevel.Error;
                case NpgsqlLogLevel.Fatal: return LogEventLevel.Fatal;
                default: return LogEventLevel.Off;
            }
        }
    }
}