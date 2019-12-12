using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings.Helpers;
using EnumsNET;

namespace Cosmos.Logging.Output {
    /// <summary>
    /// Level output format
    /// </summary>
    public static class LevelOutputFormat {
        /// <summary>
        /// Get level moniker
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static string GetLevelMoniker(LogEventLevel value, string format = null, IFormatProvider formatProvider = null) {
            var (f, l) = Char(format);
            var levelName = Name(value);

            if (format == null || format.Length != 2 && format.Length != 3)
                return CasingHelper.Format()(f)(levelName, formatProvider) as string;

            if (l < 1)
                return string.Empty;

            if (l > 4) {
                var stringValue = levelName.Length > l ? levelName.Substring(0, l) : levelName;
                return CasingHelper.Format()(f)(stringValue, formatProvider) as string;
            }

            var levelIndex = Index(value);

            if (levelIndex >= MinIndex && levelIndex <= MaxIndex) {
                switch (f) {
                    case 'w':
                        return LowercaseLevelMap[levelIndex][l - 1];
                    case 'U':
                        return UppercaseLevelMap[levelIndex][l - 1];
                    case 't':
                        return TitleCaseLevelMap[levelIndex][l - 1];
                }
            }

            return CasingHelper.Format()(f)(levelName, formatProvider) as string;
        }

        private static (char f, int l) Char(string format = null) {
            if (format == null)
                return (char.MinValue, 0);
            if (format.Length != 2 && format.Length != 3)
                return (char.MinValue, 0);
            return (format[0], format.Length == 2 ? format[1] : format[2]);
        }

        private static string Name(LogEventLevel level) {
            var ret = level.GetName();
            return string.IsNullOrWhiteSpace(ret) ? level.ToString() : ret;
        }

        static readonly string[][] TitleCaseLevelMap = {
            new[] {"V", "Vb", "Vrb", "Verb"},
            new[] {"D", "De", "Dbg", "Dbug"},
            new[] {"I", "In", "Inf", "Info"},
            new[] {"W", "Wn", "Wrn", "Warn"},
            new[] {"E", "Er", "Err", "Eror"},
            new[] {"F", "Fa", "Ftl", "Fatl"},
            new[] {"-", "--", "---", "----"},
        };

        static readonly string[][] LowercaseLevelMap = {
            new[] {"v", "vb", "vrb", "verb"},
            new[] {"d", "de", "dbg", "dbug"},
            new[] {"i", "in", "inf", "info"},
            new[] {"w", "wn", "wrn", "warn"},
            new[] {"e", "er", "err", "eror"},
            new[] {"f", "fa", "ftl", "fatl"},
            new[] {"-", "--", "---", "----"},
        };

        static readonly string[][] UppercaseLevelMap = {
            new[] {"V", "VB", "VRB", "VERB"},
            new[] {"D", "DE", "DBG", "DBUG"},
            new[] {"I", "IN", "INF", "INFO"},
            new[] {"W", "WN", "WRN", "WARN"},
            new[] {"E", "ER", "ERR", "EROR"},
            new[] {"F", "FA", "FTL", "FATL"},
            new[] {"-", "--", "---", "----"},
        };

        private const int MinIndex = 0;
        private const int MaxIndex = 6;

        private static int Index(LogEventLevel level) {
            switch (level) {
                case LogEventLevel.Verbose: return 0;
                case LogEventLevel.Debug: return 1;
                case LogEventLevel.Information: return 2;
                case LogEventLevel.Warning: return 3;
                case LogEventLevel.Error: return 4;
                case LogEventLevel.Fatal: return 5;
                case LogEventLevel.Off: return 6;
                default: return 6;
            }
        }
    }
}