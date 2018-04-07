using System;

namespace Cosmos.Judgements {
    /// <summary>
    /// Datetime Judgement Utilities
    /// </summary>
    public static class DateTimeJudgement {
        /// <summary>
        /// To judge whether the day is today
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsToday(DateTime dt) {
            return dt.Date == DateTime.Today;
        }

        /// <summary>
        /// To judge whether the day is today
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsToday(DateTime? dt) {
            return IsToday(dt.GetValueOrDefault());
        }

        /// <summary>
        /// To judge whether the day is today
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        public static bool IsToday(DateTimeOffset dtOffset) {
            return IsToday(dtOffset.Date);
        }

        /// <summary>
        /// To judge whether the day is today
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        public static bool IsToday(DateTimeOffset? dtOffset) {
            return IsToday(dtOffset.GetValueOrDefault());
        }

        /// <summary>
        /// To judge whether the day is weekend
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekend(DateTime dt) {
            return dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// To judge whether the day is weekend
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekend(DateTime? dt) {
            return IsWeekend(dt.GetValueOrDefault());
        }

        /// <summary>
        /// To judge whether the day is weekday
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekday(DateTime dt) {
            return !IsWeekend(dt);
        }

        /// <summary>
        /// To judge whether the day is weekday
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekday(DateTime? dt) {
            return IsWeekday(dt.GetValueOrDefault());
        }

        /// <summary>
        /// To judge whether the day is valid
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsValid(DateTime dt) {
            var min = new DateTime(1900, 1, 1);
            var max = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            return dt >= min && dt <= max;
        }
    }
}