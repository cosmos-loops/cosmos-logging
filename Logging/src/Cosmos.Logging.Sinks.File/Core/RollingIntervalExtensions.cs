using System;

namespace Cosmos.Logging.Sinks.File.Core {
    internal static class RollingIntervalExtensions {
        public static string GetFormat(this RollingInterval interval) {
            switch (interval) {
                case RollingInterval.Infinite:
                    return "";
                case RollingInterval.Year:
                    return "yyyy";
                case RollingInterval.Month:
                    return "yyyyMM";
                case RollingInterval.Day:
                    return "yyyyMMdd";
                case RollingInterval.Hour:
                    return "yyyyMMddHH";
                case RollingInterval.Minute:
                    return "yyyyMMddHHmm";
                default:
                    throw new ArgumentException("Invalid rolling interval");
            }
        }

        public static DateTime? GetCurrentCheckpoint(this RollingInterval interval, DateTime instant) {
            switch (interval) {
                case RollingInterval.Infinite:
                    return null;
                case RollingInterval.Year:
                    return new DateTime(instant.Year, 1, 1, 0, 0, 0, instant.Kind);
                case RollingInterval.Month:
                    return new DateTime(instant.Year, instant.Month, 1, 0, 0, 0, instant.Kind);
                case RollingInterval.Day:
                    return new DateTime(instant.Year, instant.Month, instant.Day, 0, 0, 0, instant.Kind);
                case RollingInterval.Hour:
                    return new DateTime(instant.Year, instant.Month, instant.Day, instant.Hour, 0, 0, instant.Kind);
                case RollingInterval.Minute:
                    return new DateTime(instant.Year, instant.Month, instant.Day, instant.Hour, instant.Minute, 0, instant.Kind);
                default:
                    throw new ArgumentException("Invalid rolling interval");
            }
        }

        public static DateTime? GetNextCheckpoint(this RollingInterval interval, DateTime instant) {
            var current = GetCurrentCheckpoint(interval, instant);
            if (current == null)
                return null;

            switch (interval) {
                case RollingInterval.Year:
                    return current.Value.AddYears(1);
                case RollingInterval.Month:
                    return current.Value.AddMonths(1);
                case RollingInterval.Day:
                    return current.Value.AddDays(1);
                case RollingInterval.Hour:
                    return current.Value.AddHours(1);
                case RollingInterval.Minute:
                    return current.Value.AddMinutes(1);
                default:
                    throw new ArgumentException("Invalid rolling interval");
            }
        }
    }
}