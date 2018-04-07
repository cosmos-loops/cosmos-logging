using System.Collections.Generic;

namespace Cosmos.Verba.Time {
    public class DefaultSimplifiedChineseTimeVerba : ITimeVerba {
        private static readonly DefaultSimplifiedChineseTimeVerba m_singletonInstance;
        public const string SimplifiedChinese = "zh_CN";

        static DefaultSimplifiedChineseTimeVerba() {
            m_singletonInstance = new DefaultSimplifiedChineseTimeVerba();
        }

        /// <summary>
        /// Get a simplified chinese time verba instance
        /// </summary>
        public static DefaultSimplifiedChineseTimeVerba Instance => m_singletonInstance;

        private DefaultSimplifiedChineseTimeVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultSimplifiedChineseTimeVerba";

        /// <summary>
        /// Language Keys
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {SimplifiedChinese};

        public string Now { get; } = "现在";
        public string JustNow { get; } = "刚刚";
        public string Future { get; } = "未来";
        public string Yesterday { get; } = "昨天";
        public string Milliseconds { get; } = "毫秒";
        public string Seconds { get; } = "秒";
        public string Minutes { get; } = "分钟";
        public string Hours { get; } = "小时";
        public string Days { get; } = "天";
        public string Weeks { get; } = "周";
        public string Weekends { get; } = "周末";
        public string Weekdays { get; } = "工作日";
        public string Months { get; } = "月";
        public string Season { get; } = "季";
        public string Year { get; } = "年";
        public string Ago { get; } = "前";
        public string ComplexString { get; } = "";
        public string SpaceString { get; } = "";
    }
}