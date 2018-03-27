using System.Collections.Generic;
using Cosmos.Abstractions;

namespace Cosmos.Verba.Time {
    /// <summary>
    /// Interface for time verba
    /// </summary>
    public interface ITimeVerba : IVerba {
        /// <summary>
        /// Language Keys
        /// </summary>
        List<string> LanguageKeys { get; }

        /// <summary>
        /// 现在
        /// </summary>
        string Now { get; }

        /// <summary>
        /// 刚刚
        /// </summary>
        string JustNow { get; }

        /// <summary>
        /// 未来
        /// </summary>
        string Future { get; }

        /// <summary>
        /// 昨天
        /// </summary>
        string Yesterday { get; }

        /// <summary>
        /// 毫秒
        /// </summary>
        string Milliseconds { get; }

        /// <summary>
        /// 秒
        /// </summary>
        string Seconds { get; }

        /// <summary>
        /// 分钟
        /// </summary>
        string Minutes { get; }

        /// <summary>
        /// 小时
        /// </summary>
        string Hours { get; }

        /// <summary>
        /// 天
        /// </summary>
        string Days { get; }

        /// <summary>
        /// 周
        /// </summary>
        string Weeks { get; }

        /// <summary>
        /// 周末
        /// </summary>
        string Weekends { get; }

        /// <summary>
        /// 工作日
        /// </summary>
        string Weekdays { get; }

        /// <summary>
        /// 月
        /// </summary>
        string Months { get; }

        /// <summary>
        /// 季
        /// </summary>
        string Season { get; }

        /// <summary>
        /// 年
        /// </summary>
        string Year { get; }

        /// <summary>
        /// 前
        /// </summary>
        string Ago { get; }

        /// <summary>
        /// 复数后缀
        /// </summary>
        string ComplexString { get; }

        /// <summary>
        /// 单词之间的空格符
        /// </summary>
        string SpaceString { get; }
    }
}