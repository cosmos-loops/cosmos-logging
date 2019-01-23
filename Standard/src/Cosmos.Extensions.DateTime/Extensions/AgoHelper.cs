using System;
using Cosmos.Verba.Time;

namespace Cosmos.Extensions
{
    using VERBA = Verba.Time.GlobalTimeVerbaManager;

    /// <summary>
    /// Ago Helper
    /// </summary>
    public static class AgoHelper
    {
        /// <summary>
        /// 格式化时间间隔
        /// </summary>
        /// <param name="timeSpan">时间间隔</param>
        public static string ToAgo(TimeSpan timeSpan)
        {
            if (timeSpan < TimeSpan.Zero)
            {
                return VERBA.Future; //未来
            }

            if (timeSpan < TimeVerbaConstant.OneMinute)
            {
                return VERBA.Now; //现在
            }

            if (timeSpan < TimeVerbaConstant.TwoMinutes)
            {
                return $"1 {VERBA.Minutes}{VERBA.SpaceString}{VERBA.Ago}"; //1 分钟前
            }

            if (timeSpan < TimeVerbaConstant.OneHour)
            {
                return $"{timeSpan.Minutes} {VERBA.Minutes}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 分钟前
            }

            if (timeSpan < TimeVerbaConstant.TwoHours)
            {
                return $"1 {VERBA.Hours}{VERBA.SpaceString}{VERBA.Ago}"; //1 小时前
            }

            if (timeSpan < TimeVerbaConstant.OneDay)
            {
                return $"{timeSpan.Hours} {VERBA.Hours}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 小时前
            }

            if (timeSpan < TimeVerbaConstant.TwoDays)
            {
                return VERBA.Yesterday; //昨天
            }

            if (timeSpan < TimeVerbaConstant.OneWeek)
            {
                return $"{timeSpan.Days} {VERBA.Days}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 天前
            }

            if (timeSpan < TimeVerbaConstant.TwoWeeks)
            {
                return $"1 {VERBA.Weeks}{VERBA.SpaceString}{VERBA.Ago}"; //1 周前
            }

            if (timeSpan < TimeVerbaConstant.OneMonth)
            {
                return $"{timeSpan.Days / 7} {VERBA.Weeks}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 周前
            }

            if (timeSpan < TimeVerbaConstant.TwoMonths)
            {
                return $"1 {VERBA.Months}{VERBA.SpaceString}{VERBA.Ago}"; //1 月前
            }

            if (timeSpan < TimeVerbaConstant.OneYear)
            {
                return $"{timeSpan.Days / 31} {VERBA.Months}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 月前
            }

            if (timeSpan < TimeVerbaConstant.TwoYears)
            {
                return $"1 {VERBA.Year}{VERBA.SpaceString}{VERBA.Ago}"; //1 年前
            }

            return $"{timeSpan.Days / 365} {VERBA.Year}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 年前
        }

        /// <summary>
        /// 格式化时间间隔
        /// </summary>
        /// <param name="date">對比的時間</param>
        /// <returns></returns>
        public static string ToAgo(this DateTime date)
        {
            return ToAgo(DateTime.Now - date);
        }
    }
}