using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// 判断指定日期是否为今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date) => Judgements.DateTimeJudgement.IsToday(date);

        /// <summary>
        /// 判断指定日期是否为今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime? date) => Judgements.DateTimeJudgement.IsToday(date);

        /// <summary>
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTimeOffset dto) => Judgements.DateTimeJudgement.IsToday(dto);

        /// <summary>
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTimeOffset? dto) => Judgements.DateTimeJudgement.IsToday(dto);

        /// <summary>
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime date) => Judgements.DateTimeJudgement.IsWeekday(date);

        /// <summary>
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime? date) => Judgements.DateTimeJudgement.IsWeekday(date);

        /// <summary>
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date) => Judgements.DateTimeJudgement.IsWeekend(date);

        /// <summary>
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime? date) => Judgements.DateTimeJudgement.IsWeekend(date);

        /// <summary>
        /// 判断时间是否合法
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsValid(this DateTime target) => Judgements.DateTimeJudgement.IsValid(target);

        /// <summary>
        /// 判断是否为上午
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsMorning(this DateTime @this)
        {
            return @this.TimeOfDay < new DateTime(2000, 1, 1, 12, 0, 0).TimeOfDay;
        }

        /// <summary>
        /// 判断是否为下午
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsAfternoon(this DateTime @this)
        {
            return @this.TimeOfDay >= new DateTime(2000, 1, 1, 12, 0, 0).TimeOfDay;
        }

        /// <summary>
        /// 判断是否是未来
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsFuture(this DateTime @this) => @this > DateTime.Now;

        /// <summary>
        /// 判断是否为过去
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsPast(this DateTime @this) => @this < DateTime.Now;

        /// <summary>
        /// 判断两天的日期是否相同
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateToCompare"></param>
        /// <returns></returns>
        public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
        {
            return (date.Date == dateToCompare.Date);
        }

        /// <summary>
        /// 判断两个时间是否相同
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timeToCompare"></param>
        /// <returns></returns>
        public static bool IsTimeEqual(this DateTime time, DateTime timeToCompare)
        {
            return (time.TimeOfDay == timeToCompare.TimeOfDay);
        }
    }
}