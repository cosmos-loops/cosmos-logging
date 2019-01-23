using System.Collections.Generic;

namespace Cosmos.Verba.Time
{
    public class DefaultTraditionalChineseTimeVerba : ITimeVerba
    {
        private static readonly DefaultTraditionalChineseTimeVerba m_singletonInstance;
        public const string TaiwanTraditionalChinese = "zh_TW";
        public const string HongKongTraditionalChinese = "zh_HK";

        static DefaultTraditionalChineseTimeVerba()
        {
            m_singletonInstance = new DefaultTraditionalChineseTimeVerba();
        }

        /// <summary>
        /// Get a traditional chinese time verba instance
        /// </summary>
        public static DefaultTraditionalChineseTimeVerba Instance => m_singletonInstance;

        private DefaultTraditionalChineseTimeVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultTraditionalChineseTimeVerba";

        /// <summary>
        /// Language Keys
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {TaiwanTraditionalChinese, HongKongTraditionalChinese};

        public string Now { get; } = "現在";
        public string JustNow { get; } = "剛剛";
        public string Future { get; } = "未來";
        public string Yesterday { get; } = "昨天";
        public string Milliseconds { get; } = "毫秒";
        public string Seconds { get; } = "秒";
        public string Minutes { get; } = "分鐘";
        public string Hours { get; } = "小時";
        public string Days { get; } = "天";
        public string Weeks { get; } = "週";
        public string Weekends { get; } = "週末";
        public string Weekdays { get; } = "工作日";
        public string Months { get; } = "月";
        public string Season { get; } = "季";
        public string Year { get; } = "年";
        public string Ago { get; } = "前";
        public string ComplexString { get; } = "";
        public string SpaceString { get; } = "";
    }
}