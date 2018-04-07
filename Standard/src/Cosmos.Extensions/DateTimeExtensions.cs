using System;
using System.Globalization;

namespace Cosmos {
    /// <summary>
    /// DateTime Extensions
    /// </summary>
    public static class DateTimeExtensions {
        /// <summary>
        /// 获得本月的总天数
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetCountDaysOfMonth(this DateTime date)
            => DateTime.DaysInMonth(date.Year, date.Month);

        /// <summary>
        /// 获得下一个工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateTime GetNextWeekday(this DateTime date, DayOfWeek weekday) {
            while (date.DayOfWeek != weekday) date = date.AddDays(1);
            return date;
        }

        #region GetPreviousWeekday(获得上一个工作日)

        /// <summary>
        /// 获得上一个工作日
        /// </summary>
        /// <param name="date">   </param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateTime GetPreviousWeekday(this DateTime date, DayOfWeek weekday) {
            while (date.DayOfWeek != weekday) date = date.AddDays(-1);
            return date;
        }

        #endregion GetPreviousWeekday(获得上一个工作日)

        #region GetTimeSpan(获得两个时间的间隔)

        /// <summary>
        /// 获得两个时间的间隔
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime">  </param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(this DateTime startTime, DateTime endTime)
            => endTime - startTime;

        #endregion 获得时间间隔

        #region GetFirstDayOfMonth(获得本月第一天/本月第一个周几)

        /// <summary>
        /// 获得本月第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
            => new DateTime(date.Year, date.Month, 1);

        /// <summary>
        /// 获得本月第一个周几的日期
        /// </summary>
        /// <param name="date">     </param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date, DayOfWeek dayOfWeek) {
            var dt = date.GetFirstDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(1);
            }

            return dt;
        }

        #endregion

        #region GetLastDayOfMonth(获得本月最后一天/本月最后一个周几)

        /// <summary>
        /// 获得本月最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
            => new DateTime(date.Year, date.Month, GetCountDaysOfMonth(date));

        /// <summary>
        /// 获得本月最后一个指定的星期几
        /// </summary>
        /// <param name="date">     </param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date, DayOfWeek dayOfWeek) {
            var dt = date.GetLastDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(-1);
            }

            return dt;
        }

        #endregion GetLastDayOfMonth(获得本月最后一天/本月最后一个周几)

        #region GetFirstDayOfWeek(获得本周第一天)

        /// <summary>
        /// 获得本周第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date)
            => date.GetFirstDayOfWeek(null);

        /// <summary>
        /// 获得本周第一天
        /// </summary>
        /// <param name="date">       </param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date, CultureInfo cultureInfo) {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);

            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (date.DayOfWeek != firstDayOfWeek) date = date.AddDays(-1);

            return date;
        }

        #endregion GetFirstDayOfWeek(获得本周第一天)

        #region GetLastDayOfWeek(获得本周最后一天)

        /// <summary>
        /// 获得本周最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(this DateTime date)
            => date.GetLastDayOfWeek(null);

        /// <summary>
        /// 获得本周最后一天
        /// </summary>
        /// <param name="date">       </param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(this DateTime date, CultureInfo cultureInfo)
            => date.GetFirstDayOfWeek(cultureInfo).AddDays(6);

        #endregion GetLastDayOfWeek(获得本周最后一天)

        #region GetWeekday(获得本周第一个工作日)

        /// <summary>
        /// 获得本周第一个工作日
        /// </summary>
        /// <param name="date">   </param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateTime GetWeekday(this DateTime date, DayOfWeek weekday)
            => date.GetWeekday(weekday, null);

        /// <summary>
        /// 获得本周第一个工作日
        /// </summary>
        /// <param name="date">       </param>
        /// <param name="weekday">    </param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime GetWeekday(this DateTime date, DayOfWeek weekday, CultureInfo cultureInfo)
            => date.GetFirstDayOfWeek(cultureInfo).GetNextWeekday(weekday);

        #endregion GetWeekday(获得本周第一个工作日)

        #region GetMonthDiff(获得两个时间之间相隔的月份)

        /// <summary>
        /// Compute dateTime difference
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static int GetMonthDiff(this DateTime dt1, DateTime dt2) {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            return (l.Day == r.Day ? 0 : l.Day > r.Day ? 0 : 1)
                   + (l.Month == r.Month ? 0 : r.Month - l.Month)
                   + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

        /// <summary>
        /// Compute dateTime difference precisely
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static double GetTotalMonthDiff(this DateTime dt1, DateTime dt2) {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            var lDfM = DateTime.DaysInMonth(l.Year, l.Month);
            var rDfM = DateTime.DaysInMonth(r.Year, r.Month);

            var dayFixOne = l.Day == r.Day
                ? 0d
                : l.Day > r.Day
                    ? r.Day * 1d / rDfM - l.Day * 1d / lDfM
                    : (r.Day - l.Day) * 1d / rDfM;

            return dayFixOne
                   + (l.Month == r.Month ? 0 : r.Month - l.Month)
                   + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

        #endregion

        #region GetWeekOfYear(获得指定日期所在的周是第几周)

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekrule"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekrule)
            => GetWeekOfYear(datetime, weekrule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, firstDayOfWeek);

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekrule"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekrule, DayOfWeek firstDayOfWeek)
            => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, weekrule, firstDayOfWeek);

        #endregion 获得周

        #region SetDateTime(设置时间)

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTime SetDateTime(this DateTime date, int hours, int minutes, int seconds)
            => date.SetDateTime(new TimeSpan(hours, minutes, seconds));

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime SetDateTime(this DateTime date, TimeSpan time)
            => date.Date.Add(time);

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDateTime(this DateTimeOffset date, int hours, int minutes, int seconds)
            => date.SetDateTime(new TimeSpan(hours, minutes, seconds));

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDateTime(this DateTimeOffset date, TimeSpan time)
            => date.SetDateTime(time, null);

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDateTime(this DateTimeOffset date, TimeSpan time, TimeZoneInfo localTimeZone)
            => date.ToLocalDateTime(localTimeZone).SetDateTime(time).ToDateTimeOffset(localTimeZone);

        #endregion 设置时间

        #region ToDateTimeString(获取格式化字符串)

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isRemoveSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
            => dateTime.ToString(isRemoveSecond ? "yyyy-MM-dd HH:mm" : "yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isRemoveSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime? dateTime, bool isRemoveSecond = false)
            => dateTime == null ? string.Empty : ToDateTimeString(dateTime.Value, isRemoveSecond);

        #endregion

        #region ToDateString(获取格式化字符串)

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime dateTime)
            => dateTime.ToString("yyyy-MM-dd");

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime? dateTime)
            => dateTime == null ? string.Empty : ToDateString(dateTime.Value);

        #endregion

        #region ToTimeString(获取格式化字符串)

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString(this DateTime dateTime)
            => dateTime.ToString("HH:mm:ss");

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString(this DateTime? dateTime)
            => dateTime == null ? string.Empty : ToTimeString(dateTime.Value);

        #endregion

        #region ToMillisecondString(获取格式化字符串)

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString(this DateTime dateTime)
            => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString(this DateTime? dateTime)
            => dateTime == null ? string.Empty : ToMillisecondString(dateTime.Value);

        #endregion

        /// <summary>
        /// 将时间转换为时间点
        /// </summary>
        /// <param name="localDateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime)
            => localDateTime.ToDateTimeOffset(null);

        /// <summary>
        /// 将时间转换为时间点
        /// </summary>
        /// <param name="localDateTime"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime, TimeZoneInfo localTimeZone) {
            if (localDateTime.Kind != DateTimeKind.Unspecified)
                localDateTime = new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified);

            return TimeZoneInfo.ConvertTime(localDateTime, localTimeZone ?? TimeZoneInfo.Local);
        }

        /// <summary>
        /// 将时间点转换为时间
        /// </summary>
        /// <param name="dateTimeUtc"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc)
            => dateTimeUtc.ToLocalDateTime(null);

        /// <summary>
        /// 将时间点转换为时间
        /// </summary>
        /// <param name="dateTimeUtc"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc, TimeZoneInfo localTimeZone)
            => TimeZoneInfo.ConvertTime(dateTimeUtc, localTimeZone ?? TimeZoneInfo.Local).DateTime;
    }
}