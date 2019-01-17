using System;

namespace Cosmos.Verba.Time
{
    public static class TimeVerbaConstant
    {
        /// <summary>
        /// 一分钟
        /// </summary>
        public static readonly TimeSpan OneMinute = new TimeSpan(0, 1, 0);

        /// <summary>
        /// 两分钟
        /// </summary>
        public static readonly TimeSpan TwoMinutes = new TimeSpan(0, 2, 0);

        /// <summary>
        /// 一小时
        /// </summary>
        public static readonly TimeSpan OneHour = new TimeSpan(1, 0, 0);

        /// <summary>
        /// 两小时
        /// </summary>
        public static readonly TimeSpan TwoHours = new TimeSpan(2, 0, 0);

        /// <summary>
        /// 一天
        /// </summary>
        public static readonly TimeSpan OneDay = new TimeSpan(1, 0, 0, 0);

        /// <summary>
        /// 两天
        /// </summary>
        public static readonly TimeSpan TwoDays = new TimeSpan(2, 0, 0, 0);

        /// <summary>
        /// 一周
        /// </summary>
        public static readonly TimeSpan OneWeek = new TimeSpan(7, 0, 0, 0);

        /// <summary>
        /// 两周
        /// </summary>
        public static readonly TimeSpan TwoWeeks = new TimeSpan(14, 0, 0, 0);

        /// <summary>
        /// 一月
        /// </summary>
        public static readonly TimeSpan OneMonth = new TimeSpan(31, 0, 0, 0);

        /// <summary>
        /// 两月
        /// </summary>
        public static readonly TimeSpan TwoMonths = new TimeSpan(62, 0, 0, 0);

        /// <summary>
        /// 一年
        /// </summary>
        public static readonly TimeSpan OneYear = new TimeSpan(365, 0, 0, 0);

        /// <summary>
        /// 两年
        /// </summary>
        public static readonly TimeSpan TwoYears = new TimeSpan(730, 0, 0, 0);
    }
}